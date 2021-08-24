using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Required")]
        public decimal Salary { get; set; }
    }
    public class Crud:DbContext
    {
        public DbSet<Categories> categories { get; set; }
    }
}