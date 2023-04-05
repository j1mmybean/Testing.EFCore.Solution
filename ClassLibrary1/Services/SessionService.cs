using ISpan.Inseparable.BLL.Dtos;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class SessionService
	{
		public readonly ISessionRepository repo;

		public SessionService(ISessionRepository repo)
		{
			this.repo = repo;
		}

		public void Create(SessionCreateDto dto)
		{
			var entity = dto.ToEntity();

			var entityInDb = repo.GetSession((int)entity.RoomId, entity.SessionDate, entity.SessionTime);

			if (entityInDb != null) throw new Exception("該時段影廳已被使用!");

			repo.Create(entity);
		}

		public void Update(SessionUpdateDto dto)
		{
			var entity = dto.ToEntity();

			var entityInDb = repo.GetSession((int)entity.RoomId, entity.SessionDate, entity.SessionTime);

			if (entityInDb != null && entityInDb.SessionId != entity.SessionId) throw new Exception("該時段影廳已被使用!");

			repo.Update(entity);
		}
	}
}
