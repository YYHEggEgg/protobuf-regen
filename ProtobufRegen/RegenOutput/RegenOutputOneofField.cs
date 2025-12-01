using YYHEggEgg.ProtoParser;

namespace ProtobufRegen.RegenOutput
{
    static class RegenOutputOneofField
    {
        public static void OutputOneofField(ref BasicCodeWriter fi, 
            ref SortedSet<string> imports, OneofResult oneofResult)
        {
            fi.WriteLine($"oneof {oneofResult.OneofEntryName}");
            fi.EnterCodeRegion();
            var commonFields = from commonField in oneofResult.OneofInnerFields
#if FIELD_ORDERBY_NAME
                               orderby commonField.FieldName
#elif FIELD_ORDERBY_NUMBER
                               orderby commonField.FieldNumber
#endif
                               select commonField;
            foreach (var commonField in commonFields)
            {
                RegenOutputCommonField.OutputCommonField(ref fi, ref imports, commonField);
            }
            fi.ExitCodeRegion();
        }
    }
}