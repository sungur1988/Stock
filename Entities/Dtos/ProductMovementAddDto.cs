using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ProductMovementAddDto : IDto
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
