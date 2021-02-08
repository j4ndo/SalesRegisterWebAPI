using SalesRegisterWebAPI.Domain.Models;
using SalesRegisterWebAPI.Domain.Repository;
using SalesRegisterWebAPI.Infra.Contexts;
using System.Threading.Tasks;

namespace SalesRegisterWebAPI.Infra.Repository
{
    public class SalesRegisterRepository : ISalesRegisterRepository
    {
        private readonly SalesRegisterContext _context;

        public SalesRegisterRepository(SalesRegisterContext context)
        {
            this._context = context;
        }

        public async Task<SalesRegister> SaveSalesRegisterAsync(SalesRegister salesRegister)
        {
            _context.SalesRegisters.Add(salesRegister);
            await _context.SaveChangesAsync();

            return salesRegister;
        } 
        
        public async Task<SalesRegister> UpdateSalesRegisterAsync(SalesRegister salesRegister)
        {
            _context.SalesRegisters.Update(salesRegister);
            await _context.SaveChangesAsync();

            return salesRegister;
        } 
        
        public async Task<SalesRegister> GetSalesRegisterAsync(long idSalesRegister)
        {
            var salesRegister = await _context.SalesRegisters.FindAsync(idSalesRegister);

            return salesRegister;
        } 
    }
}
