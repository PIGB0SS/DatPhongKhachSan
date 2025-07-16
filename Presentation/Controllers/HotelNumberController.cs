using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class HotelNumberController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HotelNumberController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var hotelNumbers = _db.HotelNumbers.Include(h => h.Hotel).ToList();
            return View(hotelNumbers);
        }
        public IActionResult Create()
        {
            LoadAllHotels();
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelNumber hotelNumber)
        {
            if (ModelState.IsValid)
            {
                // Check if the hotel number already exists
                bool existed = _db.HotelNumbers.Any(hn => hn.Hotel_Number == hotelNumber.Hotel_Number);
                if (existed)
                {
                    ModelState.AddModelError("Hotel_Number", "Số phòng đã tồn tại.");
                    TempData["error"] = "Số phòng đã tồn tại.";
                    return View(hotelNumber);
                }
                _db.HotelNumbers.Add(hotelNumber);
                _db.SaveChanges();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction("Index", "HotelNumber");
            }
            return View(hotelNumber);
        }
        public IActionResult Update(int hotel_Number)
        {

            var hotelNumber = _db.HotelNumbers.FirstOrDefault(h => h.Hotel_Number == hotel_Number);
            if (hotelNumber == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            LoadAllHotels();
            return View(hotelNumber);
        }
        [HttpPost]
        public IActionResult Update(HotelNumber hotelNumber)
        {
            LoadAllHotels();
            if (ModelState.IsValid)
            {
                _db.HotelNumbers.Update(hotelNumber);
                _db.SaveChanges();
                TempData["success"] = "Đã cập nhật thành công";
                return RedirectToAction("Index", "HotelNumber");
            }
            return View(hotelNumber);
        }
        public IActionResult Delete(int hotel_Number)
        {
            LoadAllHotels();
            var hotelNumber = _db.HotelNumbers.FirstOrDefault(h => h.Hotel_Number == hotel_Number);
            if (hotelNumber == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            return View(hotelNumber);
        }
        [HttpPost]
        public IActionResult Delete(HotelNumber hotelNumber)
        {
            if (ModelState.IsValid == false)
            {
                TempData["error"] = "Không xóa được thông tin";
                LoadAllHotels();
                return View(hotelNumber);
            }
            _db.HotelNumbers.Remove(hotelNumber);
            _db.SaveChanges();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction("Index", "HotelNumber");
        }
        public void LoadAllHotels()
        {
            IEnumerable<SelectListItem> hotels = _db.Hotels.Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            }).ToList();
            ViewData["Hotels"] = hotels;
        }
    }
}
