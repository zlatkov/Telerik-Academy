using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class ExcelDocument : OfficeDocument
    {
        public uint? NumberOfRows { get; protected set; }

        public uint? NumberOfColumns { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.NumberOfRows = uint.Parse(value);
            }
            else if (key == "cols")
            {
                this.NumberOfColumns = uint.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
        }
    }
