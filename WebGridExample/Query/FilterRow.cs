using System.Collections.Generic;
using System.Reflection;

namespace WebGridExample.Query
{
    public class FilterRow
    {
        private List<PropertyInfo> _fields = new List<PropertyInfo>();
        private int _order;

        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public void SetObject<T>(T item) where T : class
        {
            InitializeFields(item);        
        }

        public List<PropertyInfo> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public PropertyInfo SelectedField { get; set; }

        public ConditionType ConditionType { get; set; }

        public string Value { get; set; }

        private void InitializeFields<T>(T item) where T: class
        {
            var properties = item.GetType().GetProperties();
            _fields.Clear();
            foreach (var propertyInfo in properties)
            {
                _fields.Add(propertyInfo);
            }
        }

        public IEnumerable<ConditionType> GetConditionTypes()
        {
            return ConditionType.GetAll<ConditionType>();
        }
    }
}