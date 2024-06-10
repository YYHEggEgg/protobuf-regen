namespace ProtobufRegen.Localization;

internal class LocaleFile
{
    public string Locale { get; }
    private readonly Dictionary<string, string> _localeMap;

    public LocaleFile(string filePath, string locale)
    {
        Locale = locale;
        _localeMap = new();
        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var idx = line.IndexOf('=');
            _localeMap.Add(line[..idx], line[(idx + 1)..]);
        }
    }

    public string? Get(string key)
    {
        if (_localeMap.ContainsKey(key))
            return _localeMap[key];
        return null;
    }
}