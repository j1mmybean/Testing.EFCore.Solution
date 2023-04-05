using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class SeatCreateDto
	{
		public int SeatID { get; set; }
		public int RoomID { get; set; }
		public string SeatRow { get; set; }
		public int SeatColumn { get; set; }
	}

	public static class SeatCreateDtoExtension
	{
		public static SeatEntity ToEntity(this SeatCreateDto dto)
		{
			return new SeatEntity(dto.RoomID, dto.SeatRow, dto.SeatColumn);
		}
	}
}
