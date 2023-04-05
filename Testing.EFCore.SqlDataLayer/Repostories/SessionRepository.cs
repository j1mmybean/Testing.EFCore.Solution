using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class SessionRepository:ISessionRepository
	{
		public IQueryable<Sessions> Search(int? movie,int? cinema,int? room,DateTime begin,DateTime end)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<Sessions> search = InseparableDb.Sessions;

			if (movie != null) search = search.Where(s => s.MovieId == movie);
			if (cinema != null) search = search.Where(s => s.CinemaID == cinema);
			if (room != null) search = search.Where(s => s.RoomId == room);
			if (begin != null && end != null)search= search.Where(s => s.SessionDate < end&& begin <s.SessionDate);

			return search;
		}

		public Sessions GetSession(int sessionId) 
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Sessions.Single(s => s.SessionId == sessionId);
			
			return get;
		}

		public void Create(SessionEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			Sessions s = new Sessions();

			s.SessionDate = entity.SessionDate;
			s.CinemaID = (int)entity.CinemaID;
			s.RoomId=(int)entity.RoomId;
			s.SessionTime = entity.SessionTime;
			s.TicketPrice = (int)entity.TicketPrice;
			s.MovieId = (int)entity.MovieId;

			try
			{
				InseparableDb.Sessions.Add(s);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}

		public void Update(SessionEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var edit = InseparableDb.Sessions.Single(s => s.SessionId == entity.SessionId);

			edit.SessionDate = entity.SessionDate;
			edit.RoomId = (int)entity.RoomId;
			edit.SessionTime = entity.SessionTime;
			edit.TicketPrice = (int)entity.TicketPrice;
			entity.MovieId = (int)entity.MovieId;
			entity.CinemaID= (int)entity.CinemaID;

			try { InseparableDb.SaveChanges(); }catch(SqlException ex) { throw new Exception(ex.Message); }
		}
		public void Delete(int ID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var delete = InseparableDb.Sessions.First(s => s.SessionId == ID);

			try
			{
				InseparableDb.Sessions.Remove(delete);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}
		public SessionEntity GetSession(int roomID, DateTime Day,TimeSpan time)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var se = InseparableDb.Sessions.Where(s => s.RoomId == roomID).Where(s => s.SessionDate == Day).SingleOrDefault(s => s.SessionTime == time);

			return se == null ? null : new SessionEntity(se.MovieId, se.RoomId, se.CinemaID,se.SessionDate, se.SessionTime, se.TicketPrice)
			{
				SessionId = se.SessionId,
			};
		}

	}
}
