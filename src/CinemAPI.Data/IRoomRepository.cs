using CinemAPI.Models.Contracts.Room;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IRoomRepository
    {
        Task<IRoom> GetById(int id);
        
        Task<IRoom> GetByCinemaAndNumber(int cinemaId, int number);

        Task Insert(IRoomCreation room);

    }
}