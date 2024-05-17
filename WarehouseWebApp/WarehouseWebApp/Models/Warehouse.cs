using System.ComponentModel.DataAnnotations;

namespace WarehouseWebApp.Models;

public class Warehouse
{
    public int IdWarehouse { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Address { get; set; }
    
    public override string ToString()
    {
        return $"Warehouse: IdWarehouse: {IdWarehouse}, " +
               $"Name: {Name}, Address: {Address}";
    }
}