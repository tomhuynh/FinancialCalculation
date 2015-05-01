using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Models
{
    [Table("Alert", Schema = "dbo")]
    public class Alert
    {
        [Key]
        public int Id { get; set; }
        public Decimal? Income1 { get; set; }
        public Decimal? Income2 { get; set; }
        public Decimal? Income3 { get; set; }
        public Decimal? Income4 { get; set; }
        public Decimal? Income5 { get; set; }
        public Decimal? Income6 { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
