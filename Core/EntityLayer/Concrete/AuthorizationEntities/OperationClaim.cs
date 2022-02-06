﻿using Core.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EntityLayer.Concrete.AuthorizationEntities
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
