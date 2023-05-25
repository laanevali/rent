using rent.Models;
namespace rent.Repository
{
    public interface IData
    {
        bool AddNewCar(Car newcar);
        List<Car> GetAllCars(); 
        bool AddDriver(Driver newdriver);
        List<Driver> GetAllDrivers();
        bool BookingNow(Rent rent);
        List<string> GetBrand();
        List<string> GetModel(string brand);
        List<Rent> GetAllRents();
        DriverHistory GetDriverHistory(int Id);
    }
}
