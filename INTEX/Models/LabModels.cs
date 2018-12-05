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
        public int LTNumber { get; set; }
        public string CompoundName { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
    }

    [Table("Sample")]
    public class Sample
    {
    }

    [Table("Test")]
    public class Test
    {
    }

    [Table("Test Types")]
    public class TestTypes
    {
    }
}