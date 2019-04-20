using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Data.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext db;

        public TicketRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ITicketCreate> Get(long projectionId)
        {
            return await this.db.Tickets.FirstOrDefaultAsync(t => t.ProjectionId == projectionId);
        }

        public async Task Insert(ITicketCreate ticket)
        {
            Ticket newTicket = new Ticket()
            {
                ProjectionStartDate = ticket.ProjectionStartDate,
                CinemaName = ticket.CinemaName,
                Col = ticket.Col,
                MovieName = ticket.MovieName,
                RoomNumber = ticket.RoomNumber,
                Row = ticket.Row,
                ProjectionId = ticket.ProjectionId
            };

            this.db.Tickets.Add(newTicket);
            await this.db.SaveChangesAsync();
        }
    }
}