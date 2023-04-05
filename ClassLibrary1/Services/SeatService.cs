using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class SeatService
	{
		public readonly ISeatRepository repo;

		public SeatService(ISeatRepository repo)
		{
			this.repo = repo;
		}

		public void Create(SeatCreateDto dto)
		{
			var entity = dto.ToEntity();
			var entityInDb = repo.GetBySeat(entity.RoomID, entity.SeatRow, entity.SeatColumn);

			if (entityInDb != null) throw new Exception("該資料已存在!!");

			repo.Create(entity);
		}

		public void Update(SeatUpdateDto dto)
		{
			var entity = dto.ToEntity();
			var entityInDb = repo.GetBySeat(entity.RoomID, entity.SeatRow, entity.SeatColumn);

			if (entityInDb != null && entityInDb.SeatID!=entity.SeatID) throw new Exception("該資料已存在!!");

			repo.Update(entity);
		}
	}
}
