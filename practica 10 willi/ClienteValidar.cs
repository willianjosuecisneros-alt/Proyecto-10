using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_10_willi
{
    internal  class ClienteValidar : AbstractValidator<Cliente>
    {
        public ClienteValidar()
        {
            RuleFor(x => x.ID).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("el nombre esta vacio");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("el apellido esta vacio");
            RuleFor(x => x.Direccion).NotEmpty().Length(20,255).WithMessage("su direccion esta mal");
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
