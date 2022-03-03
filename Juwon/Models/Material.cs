﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juwon.Models
{
    public partial class Material
    {
        [Key]
        public int MaterialId { get; set; }
        [Required]
        [StringLength(30)]
        public string MaterialCode { get; set; }
        [StringLength(150)]
        public string MaterialName { get; set; }
        public int MaterialTypeId { get; set; }
        public int MaterialInOutId { get; set; }
        public int MaterialSectionId { get; set; }
        public int MaterialUnitId { get; set; }
        public int PartId { get; set; }
        public int ColorId { get; set; }
        [Required]
        public bool? Active { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(ColorId))]
        [InverseProperty("Material")]
        public virtual Color Color { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(UserInfo.Material))]
        public virtual UserInfo CreatedByNavigation { get; set; }
        [ForeignKey(nameof(MaterialInOutId))]
        [InverseProperty(nameof(CommonDetail.MaterialMaterialInOut))]
        public virtual CommonDetail MaterialInOut { get; set; }
        [ForeignKey(nameof(MaterialSectionId))]
        [InverseProperty(nameof(CommonDetail.MaterialMaterialSection))]
        public virtual CommonDetail MaterialSection { get; set; }
        [ForeignKey(nameof(MaterialTypeId))]
        [InverseProperty(nameof(CommonDetail.MaterialMaterialType))]
        public virtual CommonDetail MaterialType { get; set; }
        [ForeignKey(nameof(MaterialUnitId))]
        [InverseProperty(nameof(CommonDetail.MaterialMaterialUnit))]
        public virtual CommonDetail MaterialUnit { get; set; }
        [ForeignKey(nameof(PartId))]
        [InverseProperty("Material")]
        public virtual Part Part { get; set; }
    }
}