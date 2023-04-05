using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class SeatRepository: ISeatRepository
	{
		

		public IQueryable<Seats> Search(int? roomID,int? cinemaID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<Seats> search =InseparableDb.Seats;

			if (roomID != null) search = search.Where(s => s.RoomID == roomID);
			if (cinemaID != null) search = search.Where(s => s.Rooms.CinemaID == cinemaID);
			return search;
		}
		public Seats GetSeat(int? seatID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Seats.Single(s => s.SeatID == seatID);
			return get;
		}

		public void Create(SeatEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			Seats seats = new Seats();

			seats.RoomID = entity.RoomID;
			seats.SeatRow = entity.SeatRow;
			seats.SeatColumn=entity.SeatColumn;

			try
			{
				InseparableDb.Seats.Add(seats);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}

		public void Update(SeatEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var edit = InseparableDb.Seats.Single(se => se.SeatID == entity.SeatID);

			edit.SeatRow = entity.SeatRow;
			edit.SeatColumn = entity.SeatColumn;

			try { InseparableDb.SaveChanges(); }catch(SqlException ex) { throw new Exception(ex.Message); }

		}
		public void Delete(int Id)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var delete = InseparableDb.Seats.Single(s => s.SeatID == Id);

			try
			{
				InseparableDb.Seats.Remove(delete);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}
		public SeatEntity GetBySeat(int roomId, string row, int column)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Seats.Where(se => se.RoomID == roomId).Where(se => se.SeatRow == row).SingleOrDefault(se => se.SeatColumn == column);

			return get == null ? null : new SeatEntity(get.RoomID, get.SeatRow, get.SeatColumn)
			{
				SeatID = get.SeatID,
			};
		}
	}
}
