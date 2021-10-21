using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id=1,Name="Mary",Department=Dept.IT,Email="Mary@test.com"},
                new Employee() { Id=2,Name="John",Department=Dept.Finance,Email="John@test.com"},
                 new Employee() { Id=3,Name="Sam",Department=Dept.HR,Email="Sam@test.com"}

            };
        }

        public Employee Add(Employee employee)
        {
             employee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = new Employee();
            employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            //Employee employee = _employeeList.Where(id => id.Id == Id);
            //return employee;
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = new Employee();
            employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null) {
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
            }
            return employee;
        }
    }
}
