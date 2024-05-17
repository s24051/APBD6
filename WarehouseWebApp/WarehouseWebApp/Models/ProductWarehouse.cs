using System.ComponentModel.DataAnnotations;
using WarehouseWebApp.Attributes;

namespace WarehouseWebApp.Models;

public class ProductWarehouse
{
    public int IdProductWarehouse { get; set; }
    public int IdWarehouse { get; set; }
    public int IdProduct { get; set; }
    public int IdOrder { get; set; }
    
    [Required]
    [PositiveInteger]
    public int Amount { get; set; }
    
    [Required]
    [RegularExpression(@"^(0|-?\d{0,25}(\.\d{0,2})?)$")] // numeric(25,2)
    public decimal Price { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public override string ToString()
    {
        return $"ProductWarehouse: " +
               $"IdWarehouse: {IdWarehouse}, IdProduct: {IdProduct}, IdOrder: {IdOrder}" +
               $"Amount: {Amount}, Price: {Price}, CreatedAt: {CreatedAt}";
    }
}