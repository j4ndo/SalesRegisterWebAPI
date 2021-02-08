using FluentValidation;
using SalesRegisterWebAPI.Domain.DTO;
using System.Linq;

namespace SalesRegisterWebAPI.Domain.Validators
{
    public class SalesRegisterValidator : AbstractValidator<SalesRegisterDTO>
    {
        public SalesRegisterValidator()
        {
            RuleFor(s => s.VehicleDTOs).Must(x => x.Count >= 1)
                .WithMessage("Deve haver pelo menos 1 veículo na venda");
        }
    }
}
