using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebGridExample.Formatters
{
    public static class CsvHelpers
    {
        public static string ToCsv<T>(this IEnumerable<T> objectlist, string separator)
        {
            Type t = typeof(T);
            PropertyInfo[] props = t.GetProperties();

            string header = String.Join(separator, props.Select(f => f.Name).ToArray());

            StringBuilder csvdata = new StringBuilder();
            csvdata.AppendLine(header);

            foreach (var o in objectlist)
                csvdata.AppendLine(ToCsvFields(separator, props, o));

            return csvdata.ToString();
        }

        private static string ToCsvFields(string separator, PropertyInfo[] properties, object o)
        {
            var line = new StringBuilder();

            foreach (var f in properties)
            {
                if (line.Length > 0)
                    line.Append(separator);

                var x = f.GetValue(o);

                if (x != null)
                    line.Append(x);
            }

            return line.ToString();
        }         
    }
}