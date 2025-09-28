using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var p1 = new Product("Chocolate Frogs (box of 6)", "CF-1938", 6.95m);
        var p2 = new Product("Nimbus Polish Kit", "NP-2000", 14.50m);
        var p3 = new Product("Extendable Ears", "EE-019", 9.25m);
        var p4 = new Product("Spellbook Notebook", "SB-451", 4.75m);
        var p5 = new Product("Butterbeer Mug", "BB-777", 12.00m);

        var hermione = new Customer(
            "Hermione Granger",
            new Address("Hogwarts Castle", "Hogsmeade", "Highlands", "United Kingdom")
        );

        var ron = new Customer(
            "Ron Weasley",
            new Address("The Burrow, Ottery St Catchpole", "Devon", "England", "United Kingdom")
        );

        var tina = new Customer(
            "Tina Goldstein",
            new Address("310 W 34th St", "New York", "NY", "USA")
        );

        // 📦 Orders
        var order1 = new Order(hermione);
        order1.AddProduct(p4, 3);   // spellbook notebooks
        order1.AddProduct(p1, 2);   // chocolate frogs

        var order2 = new Order(ron);
        order2.AddProduct(p2, 1);   // nimbus polish
        order2.AddProduct(p3, 2);   // extendable ears
        order2.AddProduct(p1, 1);   // chocolate frogs (of course)

        var order3 = new Order(tina);
        order3.AddProduct(p5, 2);   // butterbeer mugs
        order3.AddProduct(p4, 2);   // notebooks

        var orders = new List<Order> { order1, order2, order3 };

        foreach (var order in orders)
        {
            Console.WriteLine("===== PACKING LABEL =====");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("===== SHIPPING LABEL =====");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"Subtotal: ${order.GetSubtotal():0.00}");
            Console.WriteLine($"Shipping: ${order.GetShippingCost():0.00} " +
                              (order.GetShippingCost() == 5m ? "(Domestic)" : "(International)"));
            Console.WriteLine($"Total:    ${order.GetTotalPrice():0.00}");
            Console.WriteLine(new string('-', 36));
            Console.WriteLine();
        }

    }
}
