using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieUpdateDto
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
	public static class MovieUpdateDtoExtension
	{
		public static MovieUpdateDto UpdateEntityToDto(this MovieEntity entity)
		{
			return new MovieUpdateDto
			{
				MovieID = entity.MovieID,
				Name = entity.Name,
				Introduction = entity.Introduction,
				LevelID = entity.LevelID,
				OnDate = entity.OnDate,
				OffDate = entity.OffDate,
				Length = entity.Length,
				Picture = entity.Picture,
			};
		}
		public static MovieEntity UpdateDtoToEntity(this MovieUpdateDto dto)
		{
			return new MovieEntity(dto.Name, dto.Introduction, dto.LevelID, dto.OnDate, dto.OffDate, dto.Length, dto.Picture)
			{
				MovieID = dto.MovieID,
			};
		}
	}

}
