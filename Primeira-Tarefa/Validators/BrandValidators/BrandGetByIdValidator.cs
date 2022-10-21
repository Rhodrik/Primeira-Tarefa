using FluentValidation;
using Primeira_Tarefa.DataBase;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Validators.BrandValidators
{
    public class BrandGetByIdValidator : AbstractValidator<BrandGetByIdPayload>
    {
        public BrandGetByIdValidator(BrandDataBase brandDataBase)
        {
            RuleFor(x => x.GetId())
                .Must(x => brandDataBase.BrandList.Any(y => y.Id == x))
                    .WithMessage("The id provided has not yet been registered")
                .Must(x => brandDataBase.BrandList.Any(y => y.Id >= 0))
                    .WithMessage("The given id cannot be less than zero");
        }
    }
}
