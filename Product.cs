using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("product")]
internal class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(5, 2)")]
    public decimal Price { get; set; }
    public List<Order> Orders { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }


    public static void Create(string name, string description, decimal price)
    {
        using(EcommerceContext context = new EcommerceContext())
        {
            Product product = new Product { Name = name, Description = description, Price = price };
            context.Add(product);
            context.SaveChanges();
        }
    }
}