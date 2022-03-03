﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juwon.Models
{
    public partial class QCMaster
    {
        public QCMaster()
        {
            BomDetail = new HashSet<BomDetail>();
            QCRel = new HashSet<QCRel>();
        }

        [Key]
        public int QCMasterId { get; set; }
        [Required]
        [StringLength(50)]
        public string QCMasterName { get; set; }
        [StringLength(150)]
        public string QCMasterDescription { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(UserInfo.QCMaster))]
        public virtual UserInfo CreatedByNavigation { get; set; }
        [InverseProperty("QCMaster")]
        public virtual ICollection<BomDetail> BomDetail { get; set; }
        [InverseProperty("QCMaster")]
        public virtual ICollection<QCRel> QCRel { get; set; }
    }
}