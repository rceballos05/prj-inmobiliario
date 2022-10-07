using FluentValidation;
using PjInmobiliaria.Application.Dto_s.Request;

namespace PjInmobiliaria.Application.Validators.Cliente
{
    public class ClienteValidator : AbstractValidator<ClienteDtoRequest>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.NombreCliente)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede estar vacío")
                .MaximumLength(50).WithMessage("El campo no puede tener mas de 50 caracteres");
        }

    }
}
