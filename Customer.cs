using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("customer")]

internal class Customer
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public List<Order> Orders { get; set; }
}

