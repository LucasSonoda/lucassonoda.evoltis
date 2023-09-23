using BusinessLogic.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Employee
{
    public class EmployeeDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public Salary Salary { get; private set; }
        public EmployeeDTO() { }
        public EmployeeDTO(int id, string name, string surname, string email, Salary salary) 
        {
            if (id < 0) throw new ArgumentException(nameof(id));
            if (name.IsNull()) throw new ArgumentException(nameof(name));
            if (surname.IsNull()) throw new ArgumentException(nameof(surname));
            if (email.IsNull() && !EmailValidation.IsValid(email)) throw new ArgumentException(nameof(email));

            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Salary = salary;
        }

        public void UpdateFrom(EmployeeDTO empl)
        {
            Name = empl.Name;
            Email = empl.Email;
            Surname = empl.Surname;
            Salary = empl.Salary;
        }
    }

}
