using System;
using System.Collections.Generic;
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
        public string CompoundName { get; set; }
        public int OrderID { get; set; }
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
        public string CompName { get; set; }
        public string CompQuantity { get; set; }
        public DateTime CompDateArrived { get; set; }
        public string CompReceivedBy { get; set; }
        public string CompAppearance { get; set; }
        public decimal CompClientWeight { get; set; }
        public decimal CompMolecMass { get; set; }
        public decimal CompActualWeight { get; set; }
        public string CompMTD { get; set; }
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