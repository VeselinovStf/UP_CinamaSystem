using CinemAPI.Models.Contracts.Cinema;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface ICinemaRepository
    {
        Task<ICinema> GetByNameAndAddress(string name, string address);

        Task<ICinema> GetRoomsByCinemaId(int cinemaId);

        Task Insert(ICinemaCreation cinema);
    }
}