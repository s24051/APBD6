using System.ComponentModel.DataAnnotations;
using WarehouseWebApp.Attributes;

namespace WarehouseWebApp.Models;

public class FulfilledOrder
{
    public int IdWarehouse { get; set; }
    public int IdProduct { get; set; }
    
    [Required]
    [PositiveInteger]
    public int Amount { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public override string ToString()
    {
        return $"FulfilledOrder: " +
               $"IdWarehouse: {IdWarehouse}, IdProduct: {IdProduct} " +
               $"Amount: {Amount}, CreatedAt: {CreatedAt}";
    }
}