using CinemAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class ReservationModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Reservation> projectionModel = modelBuilder.Entity<Reservation>();
            //projectionModel.HasKey(model => model.Id);
            //projectionModel.Property(model => model.MovieId).IsRequired();
            //projectionModel.Property(model => model.RoomId).IsRequired();
            //projectionModel.Property(model => model.StartDate).IsRequired();
            //projectionModel.Property(model => model.AvailableSeatsCount).IsRequired();
        }
    }
}