using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class OrderCreateDto
	{
		public int OrderID { get; set; }
		public int MemberID { get; set; }
		public int CinemaID { get; set; }
		public System.DateTime OrderDate { get; set; }
		public System.DateTime ModifiedTime { get; set; }
		public int TotalMoney { get; set; }
	}
	public static class OrderCreateDtoExtension
	{
		public static OrderEntity ToEntity(this OrderCreateDto dto)
		{
			return new OrderEntity(dto.MemberID,dto.CinemaID,dto.OrderDate,dto.ModifiedTime,dto.TotalMoney);
		}
	}
}
