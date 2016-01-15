using System.Collections.Generic;

namespace WebGridExample.Query
{
    public class QueryViewModel
    {
        private List<FilterRow> _filterRows = new List<FilterRow>();

        private List<FilterRow> FilterRows
        {
            get { return _filterRows; }
            set { _filterRows = value; }
        }

        public void Renumber()
        {
            var index = 0;
            foreach (var filterRow in FilterRows)
            {
                filterRow.Order = index++; 
            }
        }

        public void Add(FilterRow row)
        {
            _filterRows.Add(row);
        }

        public void Clear()
        {
            _filterRows.Clear();
        }
        public bool Remove(FilterRow row)
        {
            return _filterRows.Remove(row);
        }

    }
}