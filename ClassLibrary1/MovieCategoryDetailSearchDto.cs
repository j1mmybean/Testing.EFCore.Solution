using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryDetailSearchDto
	{
		public int MovieID { get; set; }
		public int MovieCategoryID { get; set; }
	}
	public static class MovieCategoryDetailSearchDtoExtension
	{
		public static MovieCategoryDetailSearchDto SearchEntityToDto(this MovieCategoryDetailEntity entity)
		{
			return new MovieCategoryDetailSearchDto()
			{
				MovieID = entity.MovieID,
				MovieCategoryID = entity.MovieCategoryID,
			};
		}
		public static IEnumerable<MovieCategoryDetailSearchDto> SearchEntitiesToDtos(this IEnumerable<MovieCategoryDetailEntity> entities)
		{
			var dtos = new List<MovieCategoryDetailSearchDto>();

			foreach (var entity in entities)
			{
				MovieCategoryDetailSearchDto dto = entity.SearchEntityToDto();
				dtos.Add(dto);
			}
			return dtos;
		}
	}
}
