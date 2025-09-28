using System;

public class Product
{
    private string _name;
    private string _id;
    private decimal _unitPrice;

    public Product(string name, string id, decimal unitPrice)
    {
        _name = name;
        _id = id;
        _unitPrice = unitPrice;
    }

    public string GetName() => _name;
    public string GetId() => _id;
    public decimal GetUnitPrice() => _unitPrice;
}