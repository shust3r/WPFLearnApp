using WPFLearnApp.Model;

namespace WPFLearnApp.Data;

public interface IProductDataProvider
{
    Task<IEnumerable<Product>?> GetAllAsync();
}

public class ProductDataProvider : IProductDataProvider
{
    public async Task<IEnumerable<Product>?> GetAllAsync()
    {
        await Task.Delay(100);

        return new List<Product>
        {
            new Product{Name="Cheddar", Description="A sharp and tangy cheese with a rich flavor."},
            new Product{Name="Brie", Description="A soft and creamy cheese with a mild, buttery taste."},
            new Product{Name="Gouda", Description="A mild and nutty cheese with a smooth texture."},
            new Product{Name="Blue Cheese", Description="A pungent and flavorful cheese with distinctive blue veins."},
            new Product{Name="Baguette", Description="A long, thin loaf of French bread with a crispy crust."},
            new Product{Name="Croissant", Description="A flaky and buttery pastry with a crescent shape."},
            new Product{Name="Sourdough Bread", Description="A tangy and chewy bread with a characteristic sourdough flavor."},
            new Product{Name="Cinnamon Roll", Description="A sweet and spiraled pastry with cinnamon and sugar filling, topped with icing."}
        };
    }
}
