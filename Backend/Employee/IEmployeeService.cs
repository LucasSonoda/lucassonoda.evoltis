using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Employee
{
    public interface IEmployeeService
    {
        void Create(EmployeeDTO employee);
        void Update(EmployeeDTO employee);
        void Delete(int employeeId);
        IEnumerable<EmployeeDTO> FindByName(string name);
        IEnumerable<EmployeeDTO> FindAll();
        EmployeeDTO FindById(int id);
    }
}
