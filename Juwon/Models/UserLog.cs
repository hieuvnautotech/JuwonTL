﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juwon.Models
{
    public partial class UserLog
    {
        [Key]
        public long Id { get; set; }
        public int UserInfoId { get; set; }
        [Required]
        [StringLength(24)]
        public string SessionId { get; set; }
        [Required]
        [StringLength(45)]
        public string IpAddress { get; set; }
        public bool Active { get; set; }
        public DateTime DateTimeLog { get; set; }
        public DateTime? DateTimeOut { get; set; }
    }
}