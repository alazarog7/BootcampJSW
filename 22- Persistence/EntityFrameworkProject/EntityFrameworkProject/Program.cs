using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Northwind();

            IQueryable<Category> categories = db.Categories.Include(category => category.Products);

            foreach( Category c in categories)
            {
                Console.WriteLine($"{c.CategoryName} has {c.Products.Count}");
            }
        }
    }
}
