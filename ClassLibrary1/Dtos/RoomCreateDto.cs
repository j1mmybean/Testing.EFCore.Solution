using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class RoomCreateDto
	{
		public int RoomID { get; set; }
		public int CinemaID { get; set; }
		public string RoomName { get; set; }
	}

	public static class RoomCreateDtoExtension
	{
		public static RoomEntity ToEntity(this RoomCreateDto dto)
		{
			return new RoomEntity(dto.CinemaID, dto.RoomName);
		}
	}
}
