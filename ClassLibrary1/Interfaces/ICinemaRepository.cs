using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Interface
{
	public interface ICinemaRepository
	{
		void Create(CinemaEntity entity);
		void Update(CinemaEntity entity);
		CinemaEntity GetCinema(string name);
	}
}
