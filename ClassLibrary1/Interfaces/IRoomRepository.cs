using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface IRoomRepository
	{
		void Create(RoomEntity entity);
		void Update(RoomEntity entity);

		RoomEntity GetByName(int cinemaId,string name);
	}
}
