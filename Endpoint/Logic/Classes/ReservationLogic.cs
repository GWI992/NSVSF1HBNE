using Endpoint.Logic.Exceptions;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Repositories.Interfaces;

namespace Endpoint.Logic.Classes
{
    public class ReservationLogic : ILogic<Reservation, Reservation>
    {
        IReservationRepository _repository;
        public ReservationLogic(IReservationRepository repository)
        {
            this._repository = repository;
        }

        public void Create(Reservation item)
        {
            this._repository.Create(item);
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public Reservation Read(string id)
        {
            Reservation reservation = this._repository.Read(id);
            if (reservation == null)
            {
                throw new EntityNotFoundException();
            }
            return reservation;
        }

        public IList<Reservation> ReadAll()
        {
            return this._repository.ReadAll()?.ToList();
        }

        public void Update(string id, Reservation item)
        {
            this.Read(id); // Check entity is exists
            this._repository.Update(id, item);
        }
    }
}
