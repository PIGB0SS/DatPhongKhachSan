using Appplication.Common.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHotelRepository Hotel { get; private set; }
        public IHotelNumberRepository HotelNumber { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Hotel = new HotelRepository(_db);
            HotelNumber = new HotelNumberRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
