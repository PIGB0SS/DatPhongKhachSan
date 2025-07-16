using Domain.Entities;
using System.Linq.Expressions;

namespace Appplication.Common.Interfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        void Update(Hotel entity);
        void Save();
    }
}
