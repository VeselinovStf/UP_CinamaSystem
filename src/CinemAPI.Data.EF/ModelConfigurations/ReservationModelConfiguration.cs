using CinemAPI.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

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