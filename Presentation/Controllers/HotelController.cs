using Appplication.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var hotels = _unitOfWork.Hotel.GetAll();
            return View(hotels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (hotel.Image != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotel.Image.FileName);
                    string path = Path.Combine(wwwRootPath, @"img/Hotel", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        hotel.Image.CopyTo(fileStream);
                    }
                    hotel.ImageUrl = @"img/Hotel" + fileName;
                }
                else
                {
                    hotel.ImageUrl = "default.jpg"; // Set a default image if none is provided
                }
                _unitOfWork.Hotel.Add(hotel);
                _unitOfWork.Hotel.Save();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction("Index", "Hotel");
            }
            return View(hotel);
        }
        public IActionResult Update(int hotelid)
        {
            var hotel = _unitOfWork.Hotel.Get(h => h.Id == hotelid);
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
                _unitOfWork.Hotel.Update(hotel);
                _unitOfWork.Hotel.Save();
                TempData["success"] = "Đã cập nhật thành công";
                return RedirectToAction("Index", "Hotel");
            }
            return View(hotel);
        }
        public IActionResult Delete(int hotelid)
        {
            var hotel = _unitOfWork.Hotel.Get(h => h.Id == hotelid);
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
            _unitOfWork.Hotel.Remove(hotel);
            _unitOfWork.Hotel.Save();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction("Index", "Hotel");
        }
    }
}
