using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts
{
    public interface IProjectionSeatsCount
    {
        Task<GetProjectionSeatCountModel> Get(IProjection projection);
    }
}