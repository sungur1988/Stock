using Core.EntityLayer.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Category : AuditableEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
