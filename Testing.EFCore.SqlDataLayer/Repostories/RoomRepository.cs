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
	public class RoomRepository:IRoomRepository
	{

		public IQueryable<Rooms> Search(int? cinemaID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<Rooms> search = InseparableDb.Rooms;

			if (cinemaID != null) search = search.Where(r => r.CinemaID == cinemaID);
			
			return search;
		}

		public Rooms GetRoom(int roomID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Rooms.Single(r=>r.RoomID==roomID);
			return get;
		}

		public void Create(RoomEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			Rooms rm = new Rooms();

			rm.CinemaID = entity.CinemaID;
			rm.RoomName = entity.RoomName;

			try
			{
				InseparableDb.Rooms.Add(rm);
				InseparableDb.SaveChanges();
			}catch(SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			
		}

		public void Update(RoomEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var edit = InseparableDb.Rooms.Single(r => r.RoomID == entity.RoomID);

			edit.CinemaID = entity.CinemaID;
			edit.RoomName = entity.RoomName;

			try
			{
				InseparableDb.SaveChanges();
			}
			catch(SqlException ex) { throw new Exception(ex.Message); }
		}

		public void Delete(int Id)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var delete = InseparableDb.Rooms.SingleOrDefault(r=>r.RoomID==Id);

			try
			{
				InseparableDb.Rooms.Remove(delete);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}

		public RoomEntity GetByName(int cinemaId, string name)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Rooms.Where(r=>r.CinemaID==cinemaId).SingleOrDefault(r=>r.RoomName==name);

			return get == null ? null : new RoomEntity(get.CinemaID, get.RoomName)
			{
				CinemaID = get.CinemaID
			};
		}
	}
}
