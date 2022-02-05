using Core.EntityLayer.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class ProductMovement : AuditableEntity
    {
        private int _amount;
        public int ProductId { get; set; }
        public string MovementTypeId { get; set; }
        public int Amount { get {
                if (MovementTypeId=="-")
                {
                    return (-1) * _amount;
                }
                else
                {
                    return _amount;
                }
            
            } set {

                _amount = value;
            } }
        public string Description { get; set; }
        public virtual Product Product { get; set; }
        public virtual MovementType MovementType { get; set; }
    }
}
