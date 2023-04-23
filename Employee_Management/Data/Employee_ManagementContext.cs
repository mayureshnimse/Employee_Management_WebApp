using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employee_Management.Model;

namespace Employee_Management.Data
{
    public class Employee_ManagementContext : DbContext
    {
        public Employee_ManagementContext (DbContextOptions<Employee_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Employee_Management.Model.EmployeeMgmt> EmployeeMgmt { get; set; } = default!;
    }
}
