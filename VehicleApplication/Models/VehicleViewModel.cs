﻿  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleApplication.Models
{
    public class VehicleViewModel
    {
        public IEnumerable<MarkaNaVozilo> MarkaNaVozilo { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}