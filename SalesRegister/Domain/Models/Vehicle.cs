using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesRegisterWebAPI.Domain.Models
{
    public class Vehicle
    {
        public Vehicle(string brand, string model, int yearManufacture)
        {
            this.brand = brand;
            this.model = model;
            this.yearManufacture = yearManufacture;
        }
        [Key]
        public int idVehicle { get; set; }
        [Required]
        public string id { get; set; }
        [Required]
        public string brand { get; set; }
        [Required]
        public string model { get; set; }
        [Required]
        public int yearManufacture { get; set; }
        [Required]
        public virtual ICollection<SalesRegister> SalesRegisters { get; set; }
    }
}