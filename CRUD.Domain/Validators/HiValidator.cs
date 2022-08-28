using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CRUD.Domain.Validators
{
    public class HiValidator: FluentValidation.AbstractValidator<CRUD.Domain.Validators.Hi>
    {
        public HiValidator() 
        {
            RuleFor(Current => Current.FullNamess)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage("Pls Enter RoleName1")
                
                .NotNull()
                .WithErrorCode("10")
                .WithMessage("Pls Enter RoleName2")
                ;
                
                
        }
    }
}
