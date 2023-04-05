using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface ISessionRepository
	{
		void Create(SessionEntity entity);
		void Update(SessionEntity entity);

		SessionEntity GetSession(int roomID, DateTime Day, TimeSpan time);
	}
}
