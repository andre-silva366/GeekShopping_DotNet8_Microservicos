﻿namespace GeekShoppingProduct.API.Data.ValueObjects;

public class ProductVO
{
    public long id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string ImageURL { get; set; }
}
