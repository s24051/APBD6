using System.ComponentModel.DataAnnotations;

namespace WarehouseWebApp.Models;

public class Product
{
    public int IdProduct { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Description { get; set; }
    
    [Required]
    [RegularExpression(@"^(0|-?\d{0,25}(\.\d{0,2})?)$")] // numeric(25,2)
    public decimal Price { get; set; }
    
    public override string ToString()
    {
        return $"Product: IdProduct: {IdProduct}, Name: {Name}, " +
               $"Description: {Description}, Price: {Price}";
    }
}