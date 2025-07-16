using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int Nights { get; set; }
        public string? Status { get; set; }
        [Required]
        public double TotalCost { get; set; }
        [Required]
        public DateTime BookingDate { get; set; } 
        [Required]
        public DateOnly CheckInDate { get; set; }
        [Required]
        public DateOnly CheckOutDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? StripeSessionId { get; set; }
        public string? StripePaymentIntentId { get; set; }
        public DateTime ActualCheckInDate { get; set; }
        public DateTime ActualCheckOutDate { get; set; }
        public int HotelNumber { get; set; }
        [NotMapped]
        public List<HotelNumber>? HotelNumbers { get; set; } 
    }
}
