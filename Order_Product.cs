using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("order_product")]
internal class Order_Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int Order_id { get; set; }
    public int Product_id { get; set; }
    public int Quantity { get; set; }
}

