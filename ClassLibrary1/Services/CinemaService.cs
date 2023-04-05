using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class CinemaService
	{
		public readonly ICinemaRepository repo;

		public CinemaService(ICinemaRepository repo)
		{
			this.repo = repo;
		}

		public void Create(CinemaCreateDto dto)
		{
			var entity = dto.ToEntity();

			var entityInDb = repo.GetCinema(entity.CinemaName);
			if (entityInDb != null) throw new Exception("該影院已存在!!");

			repo.Create(entity);
		}

		public void Update(CinemaUpdateDto dto)
		{
			var entity = dto.Toentity();

			var entityInDb = repo.GetCinema(entity.CinemaName);
			if (entityInDb != null && entity.CinemaID!=entityInDb.CinemaID) throw new Exception("該影院已存在!!");

			repo.Update(entity);
		}
	}
}
