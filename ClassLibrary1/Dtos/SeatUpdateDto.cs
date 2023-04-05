using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class SeatUpdateDto
	{
		public int SeatID { get; set; }
		public int RoomID { get; set; }
		public string SeatRow { get; set; }
		public int SeatColumn { get; set; }
	}

	public static class SeatUpdateDtoExtension
	{
		public static SeatEntity ToEntity(this SeatUpdateDto dto)
		{
			return new SeatEntity(dto.RoomID, dto.SeatRow, dto.SeatColumn)
			{
				SeatID = dto.SeatID,
			};
		}
	}
}
