﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juwon.Models
{
    public partial class Destination
    {
        public Destination()
        {
            Vendor = new HashSet<Vendor>();
        }

        [Key]
        public int DestinationId { get; set; }
        [StringLength(3)]
        public string DestinationCode { get; set; }
        [Required]
        [StringLength(50)]
        public string DestinationName { get; set; }
        [StringLength(100)]
        public string DestinationDescription { get; set; }
        [Required]
        public bool? Active { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(UserInfo.Destination))]
        public virtual UserInfo CreatedByNavigation { get; set; }
        [InverseProperty("Destination")]
        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}