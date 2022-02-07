using Core.EntityLayer.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class ProductMovement : AuditableEntity
    {
        private int _amount;
        public int Id { get; set; }
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

    }
}
