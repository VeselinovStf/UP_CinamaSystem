using CinemAPI.Domain;
using CinemAPI.Domain.BuyTicketWithotuReservation;
using CinemAPI.Domain.BuyTicketWithoutReservation;
using CinemAPI.Domain.BuyTicketWithReservation;
using CinemAPI.Domain.CancelReservation;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.GetProjection;
using CinemAPI.Domain.GetProjectionSeatsCount;
using CinemAPI.Domain.NewProjection;
using CinemAPI.Domain.NewReservation;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemAPI.IoCContainer
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<INewProjection, NewProjectionCreation>();
            container.RegisterDecorator<INewProjection, NewProjectionMovieValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionUniqueValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionRoomValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionPreviousOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionNextOverlapValidation>();

            // ProjectionSeatsCount
            container.Register<IProjectionSeatsCount, GetProjectionAvailibleSeatCount>();
            container.RegisterDecorator<IProjectionSeatsCount, GetProjectionSeatCountProjection>();
            container.RegisterDecorator<IProjectionSeatsCount, GetProjectionSeatsCountIdValidation>();

            //Reservation
            container.Register<INewReservation, NewReservationCreation>();
            container.RegisterDecorator<INewReservation, NewReservationDecreaseSeats>();
            container.RegisterDecorator<INewReservation, NewReservationReservedSeatValidation>();
            container.RegisterDecorator<INewReservation, NewReservationExistingSeatValidation>();
            container.RegisterDecorator<INewReservation, NewReservationDateTimeValidation>();

            container.RegisterDecorator<INewReservation, NewReservationMovieValidation>();
            container.RegisterDecorator<INewReservation, NewReservationCinemaValidation>();
            container.RegisterDecorator<INewReservation, NewReservationRoomValidation>();
            container.RegisterDecorator<INewReservation, NewReservationProjectionValidation>();

            // Get Projections
            container.Register<IGetProjection, GetProjection>();

            // Cancell Reservation
            container.Register<ICancelReservation, CancelReservation>();

            // Buy without reservation
            container.Register<IBuyWithoutReservation, BuyTicketsWithoutReservation>();
            container.RegisterDecorator<IBuyWithoutReservation, BuyTicketsWithoutReservationAvailibleSeat>();
            container.RegisterDecorator<IBuyWithoutReservation, BuyTicketsWithoutReservationDateTimeValidation>();
            container.RegisterDecorator<IBuyWithoutReservation, BuyTicketsWithoutReservationValidation>();

            // Buy with reservation
            container.Register<IBuyWithReservation, BuyTicketWithReservation>();
            container.RegisterDecorator<IBuyWithReservation, BuyTicketWithReservationValidation>();
        }
    }
}