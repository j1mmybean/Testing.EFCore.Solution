using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieSearchDto
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
	public static class MovieSearchDtoExtension
	{
		public static MovieSearchDto SearchEntityToDto(this MovieEntity entity)
		{
			return new MovieSearchDto
			{
				MovieID = entity.MovieID,
				Name= entity.Name,
				LevelID = entity.LevelID,
				OnDate = entity.OnDate,
				OffDate = entity.OffDate,
				Length = entity.Length,
				Introduction = entity.Introduction
			};
		}
		public static IEnumerable<MovieSearchDto> SearchEntitiesToDtos(this IEnumerable<MovieEntity> entities)
		{
			var dtos = new List<MovieSearchDto>();

			foreach (var entity in entities)
			{
				MovieSearchDto dto = entity.SearchEntityToDto();
				dtos.Add(dto);
			}
			return dtos;
		}
	}
}
