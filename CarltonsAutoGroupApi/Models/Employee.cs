using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarltonsAutoGroupApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string EmployeeNumber { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Department { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Position { get; set; }

        public int LocationId { get; set; } 
    }
}
