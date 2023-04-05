using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface ITicketOrderRepository
	{
		void Create(TicketOrderEntity entity);
		void Update(TicketOrderEntity entity);

		TicketOrderEntity GetBySeat(int seatId,int sessionId);
	}
}
