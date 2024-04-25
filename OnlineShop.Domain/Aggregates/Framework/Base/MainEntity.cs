using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Aggregates.Framework.Abstract;

namespace OnlineShop.Domain.Aggregates.Framework.Base
{
    public class MainEntity : IMainEntity
    {
        public string? CreatedDatePersian { get; set; }
        public bool isModified { get; set; }
        public string? ModifyDatePersian { get; set; }
        public bool IsSoftDeleted { get; set; }
        public string? SoftDeleteDatePersian { get; set; }

    }
}
