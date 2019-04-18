﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models
{
    public class ProjectionSeatCountSummary
    {
        public ProjectionSeatCountSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public ProjectionSeatCountSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public int AvailableSeatsCount { get; set; }
    }
}