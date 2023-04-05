using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class CinemasRepository:ICinemaRepository
	{
		public IQueryable<Cinemas> Search(string Name,string Country)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<Cinemas> search = InseparableDb.Cinemas;

			if (Name != null) search = search.Where(c => c.CinemaName.Contains(Name));
			if (Country != null) search = search.Where(c => c.CinemaRegion == Country);
			return search;
		}

		public Cinemas GetCinemas(int? ID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Cinemas.Single(c => c.CinemaID == ID);
			return get;
		}

		public void Create(CinemaEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			Cinemas c = new Cinemas();

			c.CinemaName=entity.CinemaName;
			c.CinemaAddress=entity.CinemaAddress;
			c.CinemaRegion=entity.CinemaRegion;
			c.CinemaTel=entity.CinemaTel;

			try
			{
				InseparableDb.Cinemas.Add(c);
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }

		}

		public void Update(CinemaEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var edit = InseparableDb.Cinemas.First(c => c.CinemaID == entity.CinemaID);

			edit.CinemaName=entity.CinemaName;
			edit.CinemaAddress=entity.CinemaAddress;
			edit.CinemaRegion=entity.CinemaRegion;
			edit.CinemaTel=entity.CinemaTel;

			try
			{
				InseparableDb.SaveChanges();
			}catch(SqlException ex) { throw new Exception(ex.Message); }
		}

		public void Delete(int ID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var delete = InseparableDb.Cinemas.First(c => c.CinemaID == ID);

			try
			{
				InseparableDb.Cinemas.Remove(delete);
				InseparableDb.SaveChanges();
			}
			catch(SqlException ex) { throw new Exception(ex.Message); }
		}
		public CinemaEntity GetCinema(string name)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var get = InseparableDb.Cinemas.SingleOrDefault(c => c.CinemaName == name);

			return get == null ? null : new CinemaEntity(get.CinemaName, get.CinemaRegion, get.CinemaAddress, get.CinemaTel)
			{
				CinemaID=get.CinemaID
			};
		}
	}
}
