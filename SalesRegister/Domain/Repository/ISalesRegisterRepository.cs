using SalesRegisterWebAPI.Domain.Models;
using System.Threading.Tasks;

namespace SalesRegisterWebAPI.Domain.Repository
{
    public interface ISalesRegisterRepository
    {
        Task<SalesRegister> SaveSalesRegisterAsync(SalesRegister salesRegister);
        Task<SalesRegister> UpdateSalesRegisterAsync(SalesRegister salesRegister);
        Task<SalesRegister> GetSalesRegisterAsync(long idSalesRegister);
    }
}
