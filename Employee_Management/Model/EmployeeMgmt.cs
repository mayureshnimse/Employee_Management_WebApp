using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Model
{
    public class EmployeeMgmt
    {
        [Key]
        public int EmpId { get; set; }

        public string? EmpName { get; set; }

        public int DeptId { get; set; }

        public string? DeptName { get; set; }

        public int Salary { get; set; }
    }
}
