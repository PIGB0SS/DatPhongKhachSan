﻿using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HotelController(ApplicationDbContext db)
        {
            _db = db;
        } 
        public IActionResult Index()
        {
            var hotels = _db.Hotels.ToList();
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
                _db.Hotels.Add(hotel);
                _db.SaveChanges();
                TempData["success"] = "Đã thêm thành công";
                return RedirectToAction("Index","Hotel");
            }
            return View(hotel);
        }
        public IActionResult Update(int hotelid)
        {
            var hotel = _db.Hotels.FirstOrDefault(h=>h.Id==hotelid);
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
            if(ModelState.IsValid == false)
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
