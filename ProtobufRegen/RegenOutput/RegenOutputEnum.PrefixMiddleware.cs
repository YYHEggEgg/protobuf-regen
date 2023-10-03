using System.Text;

#if ENABLE_ENUM_FIELDNAME_MIDDLEWARE
namespace ProtobufRegen.RegenOutput
{
    static partial class RegenOutputEnum
    {
        // 在标准情况下，一般 proto 的字段须以其名称开头，
        // 例如 ChangeHpReason 的成员须以 CHANGE_HP_REASON
        // 开头，然而部分 proto 并不遵守此规则，更多仅使用部
        // 分前缀。
        // 
        // 具体流程如下：根据驼峰命名法（忽略数字），可将名称
        // ChangeHpReason 分割为三个部分：Change、Hp、Reason。
        // 据此可得到可被识别的前缀有如下五种：
        // CHANGE_HP_REASON_
        // CHANGE_HP_
        // CHANGE_
        // （追加）REASON_
        // （追加）HP_REASON_
        // 
        // 对于第一种前缀，无需执行任何操作（替换无效果）；
        // 对于后四种前缀，需进行替换；
        // 不符合任何一种的需在头部追加前缀；
        // enum CmdId 除外。
        // 
        // 前缀必须从长到短匹配！因为短前缀本身是长前缀的前缀，
        // 从短开始匹配会使具有长前缀的后半部分被忽略，造成匹配错误。

        private static Dictionary<string, List<string>> _allowed_prefix_collection = new();

        public static string HandlePrefixMiddleware(string enumName, string fieldName)
        {
            if (enumName == "CmdId") return fieldName;

            List<string> allowed_fieldName_prefixs;

            lock (_allowed_prefix_collection)
            {
                if (!_allowed_prefix_collection.TryGetValue(enumName, out allowed_fieldName_prefixs))
                {
                    int startidx = 0;
                    List<string> parts = new();
                    for (int i = 0; i < enumName.Length; i++)
                    {
                        var c = enumName[i];
                        if (c >= 'A' && c <= 'Z')
                        {
                            if (i > 0)
                            {
                                parts.Add(enumName[startidx..i]);
                            }
                            startidx = i;
                        }
                    }
                    parts.Add(enumName[startidx..]);

                    Stack<string> prefixs_uporder = new();
                    StringBuilder prefix_builder = new();
                    foreach (var part in parts)
                    {
                        prefix_builder.Append($"{part.ToUpper()}_");
                        prefixs_uporder.Push(prefix_builder.ToString());
                    }
                    parts.Reverse();
                    prefix_builder = new();
                    foreach (var part in parts)
                    {
                        prefix_builder.Insert(0, $"{part.ToUpper()}_");
                        prefixs_uporder.Push(prefix_builder.ToString());
                    }

                    allowed_fieldName_prefixs = new((from prefix in prefixs_uporder
                                                     orderby prefix.Length descending
                                                     select prefix).Distinct());
                    _allowed_prefix_collection.Add(enumName, allowed_fieldName_prefixs);
                }
            }
        
            var priorPrefix = allowed_fieldName_prefixs[0];
            foreach (var prefix in allowed_fieldName_prefixs)
            {
                if (fieldName.StartsWith(prefix))
                    return $"{priorPrefix}{fieldName[prefix.Length..]}";
            }
            return $"{priorPrefix}{fieldName}";
        }
    }
}
#endif