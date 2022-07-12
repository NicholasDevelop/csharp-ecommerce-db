using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("order")]
internal class Order
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Amount { get; set; }
    public string status { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}
