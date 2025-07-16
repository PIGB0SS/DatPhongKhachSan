using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        [Display(Name = "Tên Khách sạn")]
        [MaxLength(100)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name ="Giá Phòng Một Đêm")]
        [Range(10,10000)]
        public double Price { get; set; }
        //area in square meters
        public int SquareMeter { get; set; }
        //number of beds
        public int Occupancy { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        [Display(Name="Hình Ảnh")]
        public string? ImageUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
