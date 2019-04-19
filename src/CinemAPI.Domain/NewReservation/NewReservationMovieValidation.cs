using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Movie;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationMovieValidation : INewReservation
    {
        private readonly IMovieRepository movieRepo;
        private readonly INewReservation newReservation;

        public NewReservationMovieValidation(IMovieRepository movieRepo, INewReservation newReservation)
        {
            this.movieRepo = movieRepo;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            IMovie movie = await movieRepo.GetById(reservation.MovieId);

            if (movie == null)
            {
                return new NewReservationSummary(false, $"Movie with id {reservation.MovieId} does not exist");
            }
            else
            {
                reservation.MovieName = movie.Name;
            }

            return await newReservation.New(reservation);
        }
    }
}