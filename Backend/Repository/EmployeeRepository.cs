using BusinessLogic.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public EmployeeRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(EmployeeDTO employeeDTO)
        {
            _repositoryContext.Employees.Add(employeeDTO);  
            _repositoryContext.SaveChanges();   
        }

        public void Update(EmployeeDTO employeeDTO)
        {
            var empl = _repositoryContext.Employees.FirstOrDefault(e => e.Id == employeeDTO.Id);
            if(empl != null)
            {
                empl.UpdateFrom(employeeDTO);
                _repositoryContext.Entry(empl).State = System.Data.Entity.EntityState.Modified;
                _repositoryContext.SaveChanges();
            }
        }

        public void Delete(int employeeId)
        {
            var empl = _repositoryContext.Employees.FirstOrDefault(e => e.Id == employeeId);
            if(empl != null)
            {
                _repositoryContext.Employees.Remove(empl);  
                _repositoryContext.SaveChanges();
            }
        }

        public IEnumerable<EmployeeDTO> FindAll()
        {
            return _repositoryContext.Employees.ToList();
        }

        public IEnumerable<EmployeeDTO> FindByName(string name)
        {
            return _repositoryContext
            .Employees.Where(e => 
                   e.Name.Contains(name)
                || e.Surname.Contains(name))
            .ToList();
        }

        public EmployeeDTO FindById(int id)
        {
            return _repositoryContext.Employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
