using SalesRegisterWebAPI.Domain.DTO;
using SalesRegisterWebAPI.Domain.ViewModel;
using SalesRegisterWebAPI.Domain.Models;
using System.Threading.Tasks;
using SalesRegisterWebAPI.Domain.Enums;

namespace SalesRegisterWebAPI.Application
{
    public interface ISalesRegisterApplication
    {
        Task<SalesRegister> CreateSalesRegisterAsync(SalesRegisterDTO salesRegisterDTO);
        Task<SalesRegister> UpdateSalesRegisterAsync(SalesRegisterPutDTO salesRegisterPutDTO);
        Task<SalesRegister> GetSalesRegisterByIdAsync(long idSalesRegister);
        Task<bool> ValidateStatusChangeSalesRegister(SalesStatus newStatus, long idSalesRegister);
    }
}
