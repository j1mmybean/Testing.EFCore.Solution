using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategorySearchDto
	{
		public int MovieCategoryID { get; set; }
		public string Name { get; set; }

	}
	public static class MovieCategorySearchDtoExtension
	{
		public static MovieCategorySearchDto SearchEntityToDto(this MovieCategoryEntity entity)
		{
			return new MovieCategorySearchDto
			{
				MovieCategoryID = entity.MovieCategoryID,
				Name = entity.Name,
			};
		}
		public static IEnumerable<MovieCategorySearchDto> SearchEntitiesToDtos(this IEnumerable<MovieCategoryEntity> entities)
		{
			var dtos = new List<MovieCategorySearchDto>();

			foreach (var entity in entities)
			{
				MovieCategorySearchDto dto = entity.SearchEntityToDto();
				dtos.Add(dto);
			}
			return dtos;
		}
	}
}
