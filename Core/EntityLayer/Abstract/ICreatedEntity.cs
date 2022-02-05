using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EntityLayer.Abstract
{
    public interface ICreatedEntity
    {
        int CreatedUserId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
