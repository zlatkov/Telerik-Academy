using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
            else
            {
                throw new KeyNotFoundException(key);
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            SaveAllProperties(properties);

            properties.Sort((x, y) => x.Key.CompareTo(y.Key));

            StringBuilder result = new StringBuilder("");
            result.Append(this.GetType().Name);

            bool shouldPrintSemicolon = false;
            result.Append("[");

            for (int i = 0; i < properties.Count; ++i)
            {
                if (properties[i].Value != null)
                {
                    if (shouldPrintSemicolon)
                    {
                        result.Append(";");
                    }

                    result.AppendFormat("{0}={1}", properties[i].Key, properties[i].Value.ToString());
                    shouldPrintSemicolon = true;
                }
            }

            result.Append("]");
            return result.ToString();
        }
    }
