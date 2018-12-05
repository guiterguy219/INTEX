using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string Email { get; set; }
        public string CustPhone { get; set; }
        public string Address { get; set; }
        public string CustCity { get; set; }
        public string CustState { get; set; }
        public string CustZip { get; set; }
        public string CustDiscount { get; set; }
    }

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string EmpPosition { get; set; }
    }

    [Table("Order")]
    public class Order
    {
    }
}