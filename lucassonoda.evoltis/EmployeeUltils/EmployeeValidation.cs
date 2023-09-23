using BusinessLogic.Common;
using BusinessLogic.Employee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lucassonoda.evoltis.EmployeeUltils
{
    public class EmployeeValidation : AbstractValidator<EmployeeForm>
    {
        public EmployeeValidation() 
        {
           RuleFor(e => e.Name.Text)
                .NotEmpty()
                .WithMessage("Ingrese el nombre.");
            RuleFor(e => e.Surname.Text)
                .NotEmpty()
                .WithMessage("Ingrese el apellido.");
            RuleFor(e => e.GetSalary().Amount)
                .GreaterThan(0)
                .WithMessage("Ingrese un salario mayor a 0");
            RuleFor(e => e.Email.Text)
                .Must(em => !string.IsNullOrEmpty(em))
                .WithMessage("Ingrese un mail valido")
                .Must(em => EmailValidation.IsValid(em))
                .WithMessage("Ingrese un mail valido");
        } 
    }
}