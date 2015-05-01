using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Models
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public double? GPA { get; set; }
        public double? Income1 { get; set; }
        public double? Income2 { get; set; }
        public double? Income3 { get; set; }
        public double? Income4 { get; set; }
        public double? Income5 { get; set; }
        public double? Income6 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
