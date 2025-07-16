namespace Appplication.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository Hotel { get; }
        IHotelNumberRepository HotelNumber { get; }

        void Save();
    }
}
