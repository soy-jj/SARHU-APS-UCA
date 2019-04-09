﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Puesto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CuentaId { get; set; }
        public int AreaId { get; set; }
        public decimal SalarioBase { get; set; }
        public bool Estado { get; set; }

    }
}
