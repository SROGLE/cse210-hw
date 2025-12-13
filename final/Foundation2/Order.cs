using System;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.IsInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public void DisplayPackingLabel()
    {
        Console.WriteLine("Packing Label:");
        foreach (Product product in _products)
        {
            product.DisplayPackingInfo();
        }
    }

    public void DisplayShippingLabel()
    {
        Console.WriteLine("Shipping Label:");
        _customer.DisplayShippingLabel();
    }
}