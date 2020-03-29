using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookMark.OrmData.Databases;
using BookMark.Domain.Models;

namespace BookMark.OrmData.Repositories {
	public class AppointmentRepository : ARepository<Appointment> {
		public AppointmentRepository(BookMarkDbContext ctx) : base(ctx) {

		}
		public override List<Appointment> All() {
			DbSet<Appointment> table = _ctx.Set<Appointment>();
			return table.Include(a => a.UserAppointments).ThenInclude(ua => ua.User).ToList();
		}
		public override Appointment Get(long ID) {
			DbSet<Appointment> table = _ctx.Set<Appointment>();
			return table.SingleOrDefault(u => u.AppointmentID == ID);
		}
	}
}