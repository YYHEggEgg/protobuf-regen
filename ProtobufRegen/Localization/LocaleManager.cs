using System.Globalization;

namespace ProtobufRegen.Localization;

internal class LocaleManager
{
    public const string LocaleResourcesPath = "locales";
    public const string LocaleFallbackOrderPath = $"{LocaleResourcesPath}/locale-fallback-order.txt";

    public string FileName { get; }
    public string CurrentCulture { get;}

    public string GetFilePath(string locale) =>
        $"{LocaleResourcesPath}/{FileName}.{locale}.txt";

    public LocaleManager(string fileName)
    {
        FileName = fileName;
        CurrentCulture = CultureInfo.CurrentCulture.Name;
        _baseFiles = new();
        foreach (var line in File.ReadLines(LocaleFallbackOrderPath))
        {
            var path = GetFilePath(line);
            if (!File.Exists(path)) continue;
            if (line == CurrentCulture) _curLocale = new(path, line);
            else _baseFiles.Add(new(path, line));
        }
    }

    private List<LocaleFile> _baseFiles;
    private LocaleFile? _curLocale;
    public string Get(string key)
    {
        var res = _curLocale?.Get(key);
        if (res != null) return res;
        foreach (var file in _baseFiles)
        {
            res = file.Get(key);
            if (res != null) return res;
        }
        return key;
    }

    public string this[string key] => Get(key);
}