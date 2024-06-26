﻿using WarehouseWebApp.Models;

namespace WarehouseWebApp.Services;

public interface IWarehouseService
{
    public int Fulfill(FulfilledOrder fulfilledOrder);
    public int FulfillWithProcedure(FulfilledOrder fulfilledOrder);
}