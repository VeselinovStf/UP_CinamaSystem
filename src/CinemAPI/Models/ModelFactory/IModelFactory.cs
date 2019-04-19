using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Output.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Models.ModelFactory
{
    public interface IModelFactory
    {
        ProjectionSeatsCountModel Create(GetProjectionSeatCountModel model);
    }
}