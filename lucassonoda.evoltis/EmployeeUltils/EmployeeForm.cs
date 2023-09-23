using BusinessLogic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace lucassonoda.evoltis.EmployeeUltils
{
    public class EmployeeForm
    {
        public TextBox Id { get; private set; }
        public TextBox Name { get; private set; }
        public TextBox Surname { get; private set; }
        public TextBox Email { get; private set; }
        public TextBox SalaryText { get; private set; }
        private EmployeeValidation _validataion = new EmployeeValidation();

        public EmployeeForm(TextBox id, TextBox name, TextBox surname, TextBox email, TextBox salary)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            SalaryText = salary;
        }
        public void Clear()
        {
            Id.Text = "0";
            Name.Text = string.Empty;
            Surname.Text = string.Empty;
            Email.Text = string.Empty;
            SalaryText.Text = string.Empty;
        }
        public void Bind(EmployeeDTO empl)
        {
            Id.Text = empl.Id.ToString();
            Name.Text = empl.Name;
            Surname.Text = empl.Surname;
            Email.Text = empl.Email;
            SalaryText.Text = empl.Salary.Amount.ToString();
        }
        public EmployeeDTO Map()
        {
            if (HasErrors().Any())
                throw new InvalidOperationException("Valide el formulario correctamente.");

            return new EmployeeDTO(int.Parse(Id.Text), Name.Text, Surname.Text, Email.Text, GetSalary());
        }

        public IEnumerable<string> HasErrors()
        {
            return _validataion.Validate(this).Errors.Select(e => e.ErrorMessage);    
        }

        public Salary GetSalary()
        {
            decimal val = 0;
            decimal.TryParse(SalaryText.Text, out val);
            return Salary.Of(val);
        }
        public bool IsEdition => int.Parse(Id.Text) > 0;
    }
}