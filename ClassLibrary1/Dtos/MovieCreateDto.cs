using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCreateDto
	{
		public int MovieID { get; set; }
		public string Name { get; set; }
		public string Introduction { get; set; }
		public int LevelID { get; set; }
		public DateTime OnDate { get; set; }
		public DateTime OffDate { get; set; }
		public int Length { get; set; }
		public byte[] Picture { get; set; }
	}
	public static class MovieCreateDtoExtension
	{
		public static MovieEntity CreateDtoToEntity(this MovieCreateDto dto)
		{
			return new MovieEntity(dto.Name, dto.Introduction, dto.LevelID, dto.OnDate, dto.OffDate, dto.Length, dto.Picture);
		}
	}

}
