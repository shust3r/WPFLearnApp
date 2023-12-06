using WPFLearnApp.Model;
namespace WPFLearnApp.Data;
public interface ICustomerDataProvider
{
    Task<IEnumerable<Customer>?> GetAllAsync();
}
public class CustomerDataProvider : ICustomerDataProvider
{
    public async Task<IEnumerable<Customer>?> GetAllAsync()
    {
        await Task.Delay(100);

        //Access API / DB / File here
        return new List<Customer>
        {
            new Customer{Id = 1, FirstName = "FirstName", LastName = "FirstSurname", IsDeveloper = true},
            new Customer{Id = 2, FirstName = "SecondName", LastName = "SecondSurname"},
            new Customer{Id = 3, FirstName = "ThirdName", LastName = "ThirdSurname", IsDeveloper = true},
            new Customer{Id = 4, FirstName = "FourthName", LastName = "FourthSurname"},
            new Customer{Id = 5, FirstName = "FifthName", LastName = "FifthSurname"},
        };
    }
}
