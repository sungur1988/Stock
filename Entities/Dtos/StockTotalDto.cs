using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class StockTotalDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
    }
}
