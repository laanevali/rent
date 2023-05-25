using System.ComponentModel.DataAnnotations;
namespace rent.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? MobileNo { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Experince { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public IFormFile DriverImage { get; set; }
    }
    public class DriverHistory
    {
        public Driver Driver { get; set; }
        public List<Rent> Rents { get; set; }
        public DriverHistory() 
        {
            Rents = new List<Rent>();
        }
    }
}
