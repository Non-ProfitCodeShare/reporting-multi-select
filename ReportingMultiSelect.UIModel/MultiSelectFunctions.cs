using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbaud.AppFx.UIModeling.Core;

namespace ReportingMultiSelect.UIModel
{
    class MultiSelectFunctions
    {
        public static void UpdateAll (ref List<BooleanField> refFields, bool selected)
        {
            foreach (BooleanField bf in refFields) 
            {
                bf.Value = selected;
            }
        }
        public static string BuildPipeDelimitedString(List<BooleanField> fields)
        {
            StringBuilder sb = new StringBuilder();

            foreach (BooleanField bf in fields)
            {
                if (bf.Value == true)
                {
                    sb.Append(bf.Caption + "|");
                }
            }

            return sb.ToString(0, sb.Length > 0 ? sb.Length -1 : 0);
        }
    }
}
