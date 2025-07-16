using Appplication.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Hotel entity)
        {
            _context.Hotels.Update(entity);
        }
        //public void Add(Hotel entity)
        //{
        //    _context.Hotels.Add(entity);
        //}

        //public Hotel Get(Expression<Func<Hotel, bool>>? filter = null, string? includeProperties = null)
        //{
        //    IQueryable<Hotel> query = _context.Hotels;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }
        //    return query.FirstOrDefault();
        //}

        //public IEnumerable<Hotel> GetAll(Expression<Func<Hotel, bool>>? filter = null, string? includeProperties = null)
        //{
        //    IQueryable<Hotel> query = _context.Hotels;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }
        //    return query.ToList();
        //}

        //public void Remove(Hotel entity)
        //{
        //    _context.Hotels.Remove(entity);
        //}


    }
}
