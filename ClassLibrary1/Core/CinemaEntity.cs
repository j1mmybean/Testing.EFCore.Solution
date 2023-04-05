using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class CinemaEntity
	{
		public int CinemaID { get; set; }
		public string CinemaName { get; set; }
		public string CinemaRegion { get; set; }
		public string CinemaAddress { get; set; }
		public string CinemaTel { get; set; }

		public CinemaEntity( string cinemaName, string cinemaRegion, string cinemaAddress, string cinemaTel)
		{
			CinemaName = cinemaName;
			CinemaRegion = cinemaRegion;
			CinemaAddress = cinemaAddress;
			CinemaTel = cinemaTel;
		}
	}
}
