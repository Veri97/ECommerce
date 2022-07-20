﻿namespace ECommerce.Core.Specifications;

public class ProductSpecParams
{
    private const int MaxPageSize = 50;
    private int _pageSize = 5;
    private string _name;
    public int PageIndex { get; set; } = 1;
    public int PageSize 
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public string Sort { get; set; }
    public string Name
    {
        get => _name;
        set => _name = value.ToLower();
    }
}
