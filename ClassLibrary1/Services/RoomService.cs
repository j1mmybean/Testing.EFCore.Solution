using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class RoomService
	{
		public readonly IRoomRepository repo;

		public RoomService(IRoomRepository repo)
		{
			this.repo = repo;
		}

		public void Create(RoomCreateDto dto)
		{
			var entity =dto.ToEntity();
			var entityInDb = repo.GetByName(entity.CinemaID,entity.RoomName);

			if (entityInDb != null) throw new Exception("該資料已存在!!");

			repo.Create(entity);
		}

		public void Update(RoomUpdateDto dto)
		{
			var entity = dto.ToEntity();
			var entityInDb = repo.GetByName(entity.CinemaID,entity.RoomName);

			if(entityInDb!=null && entityInDb.RoomID!=entity.RoomID) throw new Exception("該資料已存在!!");

			repo.Update(entity);
		}
	
	}
}
