using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeService, ILogger logger)
        {
            _employeeRepository = employeeService;
            _logger = logger;
        }

        public void Create(EmployeeDTO employee)
        {
            LogOperation("Create Employee",() => _employeeRepository.Create(employee));
        }

        public void Update(EmployeeDTO employee)
        {
            LogOperation("Update Employee", () => _employeeRepository.Update(employee));
        }
        public void Delete(int employeeId)
        {
            LogOperation("Delete Employee", () => _employeeRepository.Delete(employeeId));
        }

        public IEnumerable<EmployeeDTO> FindAll()
        {
            return _employeeRepository.FindAll();
        }

        public IEnumerable<EmployeeDTO> FindByName(string name)
        {
            return _employeeRepository.FindByName(name);
        }

        public void LogOperation(string operationName, Action action)
        {
            try
            {
                action();
                _logger.Information($"{operationName} - Succedeed");
            }
            catch (Exception ex)
            {
                _logger.Information($"{operationName} - Failed");
                throw;
            }
        }

        public EmployeeDTO FindById(int id)
        {
           return _employeeRepository.FindById(id);
        }
    }
}
