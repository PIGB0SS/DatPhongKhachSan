using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var hotelNumbers = _db.HotelNumbers.ToList();
            return View(hotelNumbers);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> hotels = _db.Hotels.Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            }).ToList();
            ViewData["Hotels"] = hotels; 
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelNumber hotelNumber)
        {
            if (ModelState.IsValid)
            {
                _db.HotelNumbers.Add(hotelNumber);
                _db.SaveChanges();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction("Index", "HotelNumber");
            }
            return View(hotelNumber);
        }
        public IActionResult Update(int hotelid)
        {
            var hotel = _db.Hotels.FirstOrDefault(h => h.Id == hotelid);
            if (hotel == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            return View(hotel);
        }
        [HttpPost]
        public IActionResult Update(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _db.Hotels.Update(hotel);
                _db.SaveChanges();
                TempData["success"] = "Đã cập nhật thành công";
                return RedirectToAction("Index", "Hotel");
            }
            return View(hotel);
        }
        public IActionResult Delete(int hotelid)
        {
            var hotel = _db.Hotels.FirstOrDefault(h => h.Id == hotelid);
            if (hotel == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            return View(hotel);
        }
        [HttpPost]
        public IActionResult Delete(Hotel hotel)
        {
            if (ModelState.IsValid == false)
            {
                TempData["error"] = "Không xóa được thông tin";
                return View(hotel);
            }
            _db.Hotels.Remove(hotel);
            _db.SaveChanges();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction("Index", "Hotel");
        }
    }
}
