using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleApplication.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name ="Licence Plate Number")]
        public string LicencePlateNumber { get; set; }

        [RegularExpression("[A-HJ-NPR-Z0-9]{13}[0-9]{4}", ErrorMessage = "Invalid Vehicle Identification Number Format.")]
        public string VIN { get; set; }

        public MarkaNaVozilo MarkaNaVozilo { get; set; }

        [Display(Name ="Model Name")]
        public byte MarkaNaVoziloId { get; set; }
    }
}