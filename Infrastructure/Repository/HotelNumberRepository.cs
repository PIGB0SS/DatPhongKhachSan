using Appplication.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class HotelNumberRepository : Repository<HotelNumber>, IHotelNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
            }
}
