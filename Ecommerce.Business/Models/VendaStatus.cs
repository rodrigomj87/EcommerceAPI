﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class VendaStatus : Entity
    {
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
    }
}
