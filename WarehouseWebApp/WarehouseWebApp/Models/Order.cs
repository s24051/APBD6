using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WarehouseWebApp.Models;

public class Order
{
    public int IdOrder { get; set; }
    public int IdProduct { get; set; }
    
    [Required]
    public int Amount { get; set; }

    [Required] 
    public DateTime CreatedAt { get; set; }
    
    public DateTime? FulfilledAt { get; set; }

    public override string ToString()
    {
        return $"Order: IdOrder: {IdOrder}, IdProduct: {IdProduct}, " +
               $"CreatedAt: {CreatedAt}, FullfilledAt: {FulfilledAt}";
    }
}