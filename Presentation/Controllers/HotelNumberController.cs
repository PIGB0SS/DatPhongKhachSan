using Appplication.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class HotelNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var hotelNumbers = _unitOfWork.HotelNumber.GetAll(include: "Hotel");
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
                bool existed = _unitOfWork.HotelNumber.Get(h => h.Hotel_Number == hotelNumber.Hotel_Number) is not null;
                if (existed)
                {
                    ModelState.AddModelError("Hotel_Number", "Số phòng đã tồn tại.");
                    TempData["error"] = "Số phòng đã tồn tại.";
                    return View(hotelNumber);
                }
                _unitOfWork.HotelNumber.Add(hotelNumber);
                _unitOfWork.Save();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction("Index", "HotelNumber");
            }
            return View(hotelNumber);
        }
        public IActionResult Update(int hotel_Number)
        {

            var hotelNumber = _unitOfWork.HotelNumber.Get(h => h.Hotel_Number == hotel_Number);
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
                _unitOfWork.HotelNumber.Update(hotelNumber);
                _unitOfWork.Save();
                TempData["success"] = "Đã cập nhật thành công";
                return RedirectToAction("Index", "HotelNumber");
            }
            return View(hotelNumber);
        }
        public IActionResult Delete(int hotel_Number)
        {
            LoadAllHotels();
            var hotelNumber = _unitOfWork.HotelNumber.Get(h => h.Hotel_Number == hotel_Number);
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
            _unitOfWork.HotelNumber.Remove(hotelNumber);
            _unitOfWork.Save();
            TempData["success"] = "Đã xóa thành công";
            return RedirectToAction("Index", "HotelNumber");
        }
        public void LoadAllHotels()
        {
            IEnumerable<SelectListItem> hotels = _unitOfWork.Hotel.GetAll().Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            }).ToList();
            ViewData["Hotels"] = hotels;
        }
    }
}
