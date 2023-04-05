using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Core
{
	public class OrderEntity
	{
		public int OrderID { get; set; }
		public int MemberID { get; set; }
		public int CinemaID { get; set; }
		public System.DateTime OrderDate { get; set; }
		public System.DateTime ModifiedTime { get; set; }
		public int TotalMoney { get; set; }

		public OrderEntity(int? memberID,int? cinemaID,DateTime orderdate,DateTime modifiedtime,int? totalmoney)
		{
			MemberID = (int)memberID;
			CinemaID = (int)cinemaID;
			OrderDate = orderdate;
			ModifiedTime = modifiedtime;
			TotalMoney=(int)TotalMoney;
		}
	}
}
