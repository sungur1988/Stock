using Core.EntityLayer.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Product : AuditableEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
