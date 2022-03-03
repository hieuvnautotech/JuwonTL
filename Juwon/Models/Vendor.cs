﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juwon.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            VendorBuyerRel = new HashSet<VendorBuyerRel>();
        }

        [Key]
        public int VendorId { get; set; }
        [Required]
        [StringLength(20)]
        public string VendorCode { get; set; }
        [Required]
        [StringLength(100)]
        public string VendorName { get; set; }
        [StringLength(100)]
        public string VendorAddress { get; set; }
        [StringLength(20)]
        public string VendorPhone { get; set; }
        public int DestinationId { get; set; }
        public int VendorCategoryId { get; set; }
        [Required]
        public bool? Active { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(UserInfo.Vendor))]
        public virtual UserInfo CreatedByNavigation { get; set; }
        [ForeignKey(nameof(DestinationId))]
        [InverseProperty("Vendor")]
        public virtual Destination Destination { get; set; }
        [InverseProperty("Vendor")]
        public virtual ICollection<VendorBuyerRel> VendorBuyerRel { get; set; }
    }
}