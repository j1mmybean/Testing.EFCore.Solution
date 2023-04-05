using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryUpdateDto
	{
		public int MovieCategoryID { get; set; }
		public string Name { get; set; }

	}
	public static class MovieCategoryUpdateDtoExtension
	{
		public static MovieCategoryUpdateDto UpdateEntityToDto(this MovieCategoryEntity entity)
		{
			return new MovieCategoryUpdateDto
			{
				MovieCategoryID = entity.MovieCategoryID,
				Name = entity.Name,
			};
		}
		public static MovieCategoryEntity UpdateDtoToEntity(this MovieCategoryUpdateDto dto)
		{
			return new MovieCategoryEntity(dto.Name)
			{
				MovieCategoryID = dto.MovieCategoryID,
			};
		}
	}

}
