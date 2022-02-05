using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CategoryAddDto : IDto
    {
        public string CategoryName { get; set; }
    }
}
