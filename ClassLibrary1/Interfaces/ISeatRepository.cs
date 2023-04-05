using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface ISeatRepository
	{
		void Create(SeatEntity entity);
		void Update(SeatEntity entity);

		SeatEntity GetBySeat(int roomId, string row, int column);
	}
}
