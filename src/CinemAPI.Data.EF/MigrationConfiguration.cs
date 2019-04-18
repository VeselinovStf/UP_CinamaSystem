using CinemAPI.Models;
using System.Data.Entity.Migrations;

namespace CinemAPI.Data.EF
{
    public class MigrationConfiguration : DbMigrationsConfiguration<CinemaDbContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CinemaDbContext context)
        {
            //if (!context.Cinemas.Any())
            //{
            //}

            SeedCinemas(context);
            SeedRooms(context);
            SeedMovies(context);
            SeedProjections(context);
        }

        private void SeedProjections(CinemaDbContext context)
        {
            context.Projections.AddOrUpdate(p =>
                 p.Id,
                 new Projection() { Id = 1, MovieId = 1, RoomId = 1, StartDate = new System.DateTime(2019, 4, 30) , AvailableSeatsCount = 10},
                 new Projection() { Id = 2, MovieId = 2, RoomId = 2, StartDate = new System.DateTime(2019, 4, 25) , AvailableSeatsCount = 20},
                 new Projection() { Id = 4, MovieId = 4, RoomId = 4, StartDate = new System.DateTime(2019, 6, 30) , AvailableSeatsCount = 5},
                 new Projection() { Id = 5, MovieId = 4, RoomId = 4, StartDate = new System.DateTime(2019, 3, 30) , AvailableSeatsCount = 5}
                 );
        }

        private void SeedMovies(CinemaDbContext context)
        {
            context.Movies.AddOrUpdate(m =>
                 m.Id,
                 new Movie() { Id = 1, DurationMinutes = 120, Name = "Die Hard 1" },
                 new Movie() { Id = 2, DurationMinutes = 180, Name = "Running Man" },
                 new Movie() { Id = 3, DurationMinutes = 60, Name = "Some random" },
                 new Movie() { Id = 4, DurationMinutes = 25, Name = "Fast and Faster 2" }
                 );
        }

        private void SeedRooms(CinemaDbContext context)
        {
            context.Rooms.AddOrUpdate(r =>
              r.Id,
              new Room() { Id = 1, CinemaId = 1, Number = 1, Rows = 50, SeatsPerRow = 50 },
              new Room() { Id = 2, CinemaId = 1, Number = 2, Rows = 20, SeatsPerRow = 20 },
              new Room() { Id = 3, CinemaId = 2, Number = 3, Rows = 30, SeatsPerRow = 30 },
              new Room() { Id = 4, CinemaId = 3, Number = 4, Rows = 40, SeatsPerRow = 40 }
              );
        }

        private void SeedCinemas(CinemaDbContext context)
        {
            context.Cinemas.AddOrUpdate(c =>
               c.Id,
               new Cinema() { Id = 1, Address = "Bulgaria, Sofia, ul. Bacho Kiro 11", Name = "Master CINEMA" },
               new Cinema() { Id = 2, Address = "Bulgaria, Sofia, ul. Strandja 404", Name = "Cheap CINEMA" },
               new Cinema() { Id = 3, Address = "Bulgaria, Sofia, ul. Orqhovo 2", Name = "Action Cinema" }
               );
        }
    }
}