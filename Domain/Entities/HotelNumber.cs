using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class HotelNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hotel_Number { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
