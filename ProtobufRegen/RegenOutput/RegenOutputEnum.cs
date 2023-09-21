namespace ProtobufRegen.RegenOutput
{
    static class RegenOutputEnum
    {
        public static void OutputEnum(ref BasicCodeWriter fi, EnumResult enumResult)
        {
            var nodes = from tuple in enumResult.enumNodes
                        orderby tuple.number
                        select tuple;
            fi.WriteLine($"enum {enumResult.enumName}");
            fi.EnterCodeRegion();
            foreach (var tuple in nodes)
            {
                fi.WriteLine($"{tuple.name} = {tuple.number};");
            }
            fi.ExitCodeRegion();
        }
    }
}