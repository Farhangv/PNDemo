using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        [Index(IsUnique = true), MaxLength(50), MinLength(5), Display(Name = "نام کاربری")]
        public string Username { get; set; }
        [Display(Name = "کلمه عبور"), MinLength(8)]
        public string Password { get; set; }
        [MaxLength(50), Display(Name = "نام")]
        public string Name { get; set; }
        [MaxLength(50), Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
    }
}