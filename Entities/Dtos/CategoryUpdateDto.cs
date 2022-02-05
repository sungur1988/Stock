using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        
    }
}
