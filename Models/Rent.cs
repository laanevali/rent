using System.ComponentModel.DataAnnotations;
namespace rent.Models
{
    public class Rent
    {
        public int Id { get; set; }
        [Required]
        public string? PickUp { get; set; }
        [Required]
        public string? DropOff { get; set; }
        [Required]
        public DateTime PickUpDate { get; set; }
        [Required]
        public DateTime DropOffDate { get; set; }
        [Required]
        public int TotalRun { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public int TotalAmount { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public int DriverId { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? CustomerContact { get; set; }
    }
}
