using EntityFrameworkPaginate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;

namespace WebApplication.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="required")]

        public string ProductName { get; set; }
        [Required(ErrorMessage = "required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "required")]
        public int Qty { get; set; }



        public Page<Products> GetFilteredEmployees(int pageSize, int currentPage, string searchText, int sortBy, string jpbTitile)
        {
            Page<Products> products;
            var filters = new Filters<Products>();

            filters.Add(!string.IsNullOrEmpty(searchText), x => x.ProductName.Contains(searchText));

            var sorts = new Sorts<Products>();
            sorts.Add(sortBy == 1, x => x.ProductName);

            using (var context = new Entities())
            {
                products = context.products.Paginate(currentPage, pageSize, sorts, filters);
            }





                return products;
        }

    }
    public class Entities:DbContext
    {
        public DbSet<Products> products { get; set; }




    }

    
}