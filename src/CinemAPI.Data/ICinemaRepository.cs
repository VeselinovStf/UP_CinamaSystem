using CinemAPI.Models;
using CinemAPI.Models.Contracts.Cinema;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface ICinemaRepository
    {
        Task<ICinema> GetByNameAndAddress(string name, string address);

        Task Insert(ICinemaCreation cinema);
    }
}