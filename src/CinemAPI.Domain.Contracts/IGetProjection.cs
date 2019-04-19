﻿using CinemAPI.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts
{
    public interface IGetProjection
    {
        Task<ProjectionSummary> Get(int projectionId);
    }
}