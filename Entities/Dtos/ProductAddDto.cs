﻿using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ProductAddDto : IDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
