namespace ProtobufRegen.RegenOutput
{
    static class RegenOutputEnum
    {
        public static void OutputEnum(ref BasicCodeWriter fi, EnumResult enumResult)
        {
            var positive_nodes = from tuple in enumResult.enumNodes
                                 where tuple.number > 0
                                 orderby tuple.number
                                 select tuple;
            var non_positive_nodes = from tuple in enumResult.enumNodes
                                     where tuple.number <= 0
                                     orderby tuple.number descending
                                     select tuple;
            fi.WriteLine($"enum {enumResult.enumName}");
            fi.EnterCodeRegion();
            foreach (var tuple in non_positive_nodes)
            {
                fi.WriteLine($"{tuple.name} = {tuple.number};");
            }
            foreach (var tuple in positive_nodes)
            {
                fi.WriteLine($"{tuple.name} = {tuple.number};");
            }
            fi.ExitCodeRegion();
        }
    }
}