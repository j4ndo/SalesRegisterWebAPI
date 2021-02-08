using System.Collections.Generic;

namespace SalesRegisterWebAPI.Domain.DTO
{
    public class VehicleDTO
    {
        public VehicleDTO()
        {

        }
        public VehicleDTO(string brand, string model, int yearManufacture)
        {
            this.brand = brand;
            this.model = model;
            this.yearManufacture = yearManufacture;
        }

        public string brand { get; set; }
        public string model { get; set; }
        public int yearManufacture { get; set; }

        public ICollection<SalesRegisterDTO> SalesRegistersDTO { get; set; }
    }
}