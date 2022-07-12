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
    public int Customer_id { get; set; }
    public DateOnly Date { get; set; }
    public double Amount { get; set; }
    public bool status { get; set; }
    public List<Order_Product> Orders_Products { get; set; }
}
