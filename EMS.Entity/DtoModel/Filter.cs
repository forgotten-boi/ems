
using EMS.Entity.BaseEntity;
using EMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Entity.DtoModel
{
    public class Filter : IQueryObject
    {
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
        public string SearchableColumn { get; set; }
        public List<SearchData> searchData { get; set; }
    }
}
