namespace ProtobufRegen.RegenOutput
{
    static class RegenOutputMessage
    {
        public static void OutputMessage(ref BasicCodeWriter fi, 
            ref SortedSet<string> imports, MessageResult messageResult)
        {
            fi.WriteLine($"message {messageResult.messageName}");
            fi.EnterCodeRegion();
            var commonFields = from commonField in messageResult.commonFields
                               orderby commonField.fieldName
                               select commonField;
            foreach (var commonField in commonFields)
            {
                RegenOutputCommonField.OutputCommonField(ref fi, ref imports, commonField);
            }
            fi.WriteLine();
            var mapFields = from mapField in messageResult.mapFields
                            orderby mapField.fieldName
                            select mapField;
            foreach (var mapField in mapFields)
            {
                RegenOutputMapField.OutputMapField(ref fi, ref imports, mapField);
            }
            fi.WriteLine();
            var oneofFields = from oneofField in messageResult.oneofFields
                              orderby oneofField.oneofEntryName
                              select oneofField;
            foreach (var oneofField in oneofFields)
            {
                RegenOutputOneofField.OutputOneofField(ref fi, ref imports, oneofField);
            }
            fi.WriteLine();
            var enumFields = from enumField in messageResult.enumFields
                              orderby enumField.enumName
                              select enumField;
            foreach (var enumField in enumFields)
            {
                RegenOutputEnum.OutputEnum(ref fi, enumField);
            }
            fi.WriteLine();
            var messageFields = from messageField in messageResult.messageFields
                              orderby messageField.messageName
                              select messageField;
            foreach (var messageField in messageFields)
            {
                OutputMessage(ref fi, ref imports, messageField);
            }

            fi.ExitCodeRegion();
        }
    }
}