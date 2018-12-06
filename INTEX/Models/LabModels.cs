using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssayID { get; set; }
        public decimal AssayCost { get; set; }
        public int SampleID { get; set; }
        public virtual Sample Sample { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
    }

    [Table("Compound")]
    public class Compound
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LTNumber { get; set; }
        public int OrderID { get; set; }

        [Required]
        [DisplayName("Compound Name")]
        public string CompoundName { get; set; }

        [DisplayName("Number of Samples")]
        public int numSamples { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }

        public virtual Order Order { get; set; }
    }

    [Table("Sample")]
    public class Sample
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SampleID { get; set; }
        public int LTNumber { get; set; }
        public virtual Compound Compound { get; set; }
        public int SequenceCode { get; set; }

        [Required]
        [DisplayName("Quantity in milligrams")]
        public string sampQuantity { get; set; }

        [Required]
        [DisplayName("Sample Weight")]
        public decimal sampClientWeight { get; set; }

        [Required]
        [DisplayName("Date Arrived")]
        public DateTime sampDateArrived { get; set; }

        [Required]
        [DisplayName("Sample Received By")]
        public string sampReceivedBy { get; set; }

        [Required]
        [DisplayName("Appearance")]
        public string sampAppearance { get; set; }

        [Required]
        [DisplayName("Actual Weight")]
        public decimal sampActualWeight { get; set; }

        [Required]
        [DisplayName("Molecular Mass")]
        public decimal sampMolecMass { get; set; }

        [Required]
        [DisplayName("Minimum Tolerable Dose (MTD)")]
        public string sampMTD { get; set; }
        public DateTime sampDateDue { get; set; }
    }

    [Table("Test")]
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestID { get; set; }
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }
        public int TestTypeCode { get; set; }
        public virtual TestTypes TestType { get; set; }
    }

    [Table("Test Types")]
    public class TestTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestTypeCode { get; set; }
        public string TestTypeName { get; set; }
        public string TestTypeDescription { get; set; }
        public bool TestRequired { get; set; }
    }
}