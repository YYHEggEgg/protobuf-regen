using YYHEggEgg.ProtoParser;

namespace ProtobufRegen.RegenOutput
{
    static class RegenOutputEnum
    {
        public static void OutputEnum(ref BasicCodeWriter fi, EnumResult enumResult)
        {
            var options = from tuple in enumResult.EnumOptions
                          orderby tuple.name
                          select tuple;
            var positive_nodes = from tuple in enumResult.EnumNodes
                                 where tuple.number > 0
                                 orderby tuple.number
                                 select tuple;
            var non_positive_nodes = from tuple in enumResult.EnumNodes
                                     where tuple.number <= 0
                                     orderby tuple.number descending
                                     select tuple;
            fi.WriteLine($"enum {enumResult.EnumName}");
            fi.EnterCodeRegion();
            var non_duplicate_nodes_count = 
                positive_nodes.Concat(non_positive_nodes)
                .Distinct(new EnumResult.EnumNodeNumberEqualityComparer()).Count();

            if (non_duplicate_nodes_count < non_positive_nodes.Count() + positive_nodes.Count())
                fi.WriteLine($"option allow_alias = true;");

            foreach (var tuple in non_positive_nodes.Concat(positive_nodes))
            {
#if ENABLE_ENUM_FIELDNAME_MIDDLEWARE
                fi.WriteLine($"{HandlePrefixMiddleware(enumResult.enumName, tuple.name)} = {tuple.number};");
#else
                fi.WriteLine($"{tuple.name} = {tuple.number};");
#endif
            }
            fi.ExitCodeRegion();
        }
    }
}