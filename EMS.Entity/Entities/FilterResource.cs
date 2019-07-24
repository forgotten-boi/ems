using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Entity.Entities
{
    public class FilterResource
    {
        public List<SearchData> searchData { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
        public string SearchableColumn { get; set; }
    }
}
