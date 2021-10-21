using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }



        public Employee Add(Employee employee)
        {
             context.employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.employees.Find(id);
            if (employee != null)
            {
                context.employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.employees;
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = context.employees.Find(Id);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            //Employee employee = context.employees.Find(employeeChanges.Id);
            //if (employee != null)
            //{
            //    employee.Name = employeeChanges.Name;
            //    employee.Department = employeeChanges.Department;
            //    employee.Email = employeeChanges.Email;

            //    context.Update(employee);
            //    context.SaveChanges();
            //}

            var employee = context.employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
