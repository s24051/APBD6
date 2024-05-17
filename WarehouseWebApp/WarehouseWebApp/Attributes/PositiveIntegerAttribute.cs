using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace WarehouseWebApp.Attributes;

public class PositiveIntegerAttribute: ValidationAttribute
{
    public override bool IsValid(object value)
    {
        int intValue;
        if (!int.TryParse(value.ToString(), out intValue))
            return false;
        return intValue > 0;
    } 
}