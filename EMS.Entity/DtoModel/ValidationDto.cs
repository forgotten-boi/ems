using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Entity.DtoModel
{
    public class ValidationDto<T>
    {
        public bool IsSucess { get; set; }
        public bool IsUpdate { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }

        public bool IsDuplicate { get; set; }

        public bool IsDefault { get; set; }
    }
}
