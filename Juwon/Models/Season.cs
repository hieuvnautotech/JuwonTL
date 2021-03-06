// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juwon.Models
{
    public partial class Season
    {
        [Key]
        public int SeasonId { get; set; }
        [Required]
        [StringLength(10)]
        public string SeasonCode { get; set; }
        [Required]
        [StringLength(50)]
        public string SeasonName { get; set; }
        [StringLength(150)]
        public string SeasonDescription { get; set; }
        [Required]
        public bool? Active { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(UserInfo.Season))]
        public virtual UserInfo CreatedByNavigation { get; set; }
    }
}