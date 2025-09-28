using System;

public class OrderLine
{
    private Product _product;
    private int _quantity;

    public OrderLine(Product product, int quantity)
    {
        _product = product;
        _quantity = quantity;
    }

    public decimal GetLineTotal()
    {
        return _product.GetUnitPrice() * _quantity;
    }

    public string GetPackingLine()
    {
        return $"{_product.GetId()} - {_product.GetName()} x {_quantity}";
    }
}
