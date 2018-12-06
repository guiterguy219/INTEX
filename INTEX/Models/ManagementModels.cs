using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string UserID { get; set; }

        [DisplayName("First Name")]
        [StringLength(30)]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string CustFirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(30)]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string CustLastName { get; set; }

        public string CustEmail { get; set; }

        [DisplayName("Phone Number")]
        [Phone(ErrorMessage = "Please enter valid phone number.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?\(\d+\)\s\d{3}\-\d{4}[\s]?[\d]*$", ErrorMessage = "Phone must be formatted as (###) ###-####.")]
        [Required(ErrorMessage = "Please enter your phone number.")]
        public string CustPhone { get; set; }

        [DisplayName("Address 1")]
        [Required(ErrorMessage = "Please enter your address.")]
        public string CustAddress1 { get; set; }

        [DisplayName("Address 2")]
        public string CustAddress2 { get; set; }

        [DisplayName("City")]
        [StringLength(15)]
        [Required(ErrorMessage = "Please enter city.")]
        public string CustCity { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Please select state.")]
        public int StateID { get; set; }
        public virtual State State { get; set; }

        [DisplayName("ZIP Code")]
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Please enter ZIP code.")]
        [RegularExpression(@"^\d{5}\-?\d{0,4}$", ErrorMessage = "ZIP Code must be formatted ##### or #####-####.")]
        public string CustZip { get; set; }

        public string CustDiscount { get; set; }
    }

    [Table("state")]
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }

    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string UserID { get; set; }
        public string EmpPosition { get; set; }
    }

    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [DisplayName("Number of Compounds")]
        [Required(ErrorMessage ="You must enter a valid number of compounds")]
        public int numCompounds { get; set; }
        public virtual ICollection<Compound> Compounds { get; set; }
        public string OrderStatus { get; set; }
    }

    [Table("Quote")]
    public class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int quoteID { get; set; }
        public int customerID { get; set; }
        public DateTime quoteDateReceived { get; set; }

        [Required]
        [DisplayName("Number of Compounds")]
        public int quoteNumCompounds { get; set; }

        [Required]
        [DisplayName("Total Number of Samples")]
        public int quoteNumSamples { get; set; }
        
        [DisplayName("Order Details")]
        public string quoteDescription { get; set; }
    }
}