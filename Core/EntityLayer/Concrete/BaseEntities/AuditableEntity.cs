using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EntityLayer.Concrete.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
