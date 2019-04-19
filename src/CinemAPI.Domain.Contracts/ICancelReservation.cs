﻿using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts
{
    public interface ICancelReservation
    {
        Task<CancelReservationSummary> Cancel();
    }
}