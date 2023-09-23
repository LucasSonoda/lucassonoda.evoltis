using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Employee
{
    public interface IEmployeeRepository
    {
        void Create(EmployeeDTO employeeDTO);
        void Update(EmployeeDTO employeeDTO);
        void Delete(int employeeId);
        IEnumerable<EmployeeDTO> FindByName(string name);
        IEnumerable<EmployeeDTO> FindAll();
        EmployeeDTO FindById(int id);
    }
}
