using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ProductAddDto : IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
