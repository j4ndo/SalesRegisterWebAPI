using SalesRegisterWebAPI.Domain.Enums;

namespace SalesRegisterWebAPI.Domain.DTO
{
    public class SalesRegisterPutDTO
    {
        public SalesRegisterPutDTO()
        {

        }
        public long IdSalesRegister { get; set; }
        public SalesStatus Status { get; set; }
    }
}
