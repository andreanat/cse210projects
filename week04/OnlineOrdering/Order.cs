using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    private Customer _customer;
    private List<OrderLine> _items = new List<OrderLine>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product, int quantity)
    {
        _items.Add(new OrderLine(product, quantity));
    }

    public decimal GetSubtotal()
    {
        decimal sum = 0m;
        foreach (var line in _items)
        {
            sum += line.GetLineTotal();
        }
        return sum;
    }

    public decimal GetShippingCost()
    {
        return _customer.IsDomestic() ? 5m : 35m;
    }

    public decimal GetTotalPrice()
    {
        return GetSubtotal() + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        var lines = new List<string>();
        foreach (var line in _items)
        {
            lines.Add(line.GetPackingLine());
        }
        return string.Join("\n", lines);
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}