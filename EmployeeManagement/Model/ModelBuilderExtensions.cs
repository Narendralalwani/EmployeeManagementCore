using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "NewTestName1",
                   Department = Dept.IT,
                   Email = "test@gmail.com"
               },
                    new Employee
                    {
                        Id = 2,
                        Name = "NewTestName2",
                        Department = Dept.Finance,
                        Email = "test@gmail.com"
                    }

               );

        }
    }
}
