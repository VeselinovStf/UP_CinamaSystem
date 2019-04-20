﻿using CinemAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal class TicketModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Ticket> ticketModel = modelBuilder.Entity<Ticket>();
            ticketModel.HasKey(model => model.Id);
            ticketModel.Property(model => model.MovieId).IsRequired();
            ticketModel.Property(model => model.ProjectionStartDate).IsRequired();
            ticketModel.Property(model => model.MovieName).IsRequired();
            ticketModel.Property(model => model.CinemaName).IsRequired();
            ticketModel.Property(model => model.Col).IsRequired();
            ticketModel.Property(model => model.Row).IsRequired();
            ticketModel.Property(model => model.ProjectionId).IsRequired();
            ticketModel.Property(model => model.RoomNumber).IsRequired();
        }
    }
}