using System.Collections.Generic;

namespace SalesRegisterWebAPI.Domain.DTO
{
    public class SalesRegisterDTO
    {
        public SalesRegisterDTO()
        {

        }
        public SalesRegisterDTO(SellerDTO sellerDTO, ICollection<VehicleDTO> vehicleDTOs)
        {
            this.SellerDTO = sellerDTO;
            this.VehicleDTOs = vehicleDTOs;
        }
        public SellerDTO SellerDTO { get; set; }
        public ICollection<VehicleDTO> VehicleDTOs { get; set; }
    }
}
