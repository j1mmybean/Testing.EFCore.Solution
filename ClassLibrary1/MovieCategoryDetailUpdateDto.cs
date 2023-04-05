using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryDetailUpdateDto
	{
		public int MovieID { get; set; }
		public int MovieCategoryID { get; set; }
	}
	public static class MovieCategoryDetailUpdateDtoExtension
	{
		public static MovieCategoryDetailEntity UpdateDtoToEntity(this MovieCategoryDetailUpdateDto dto)
		{
			return new MovieCategoryDetailEntity(dto.MovieID, dto.MovieCategoryID);
		}
		public static MovieCategoryDetailUpdateDto UpdateEntityToDto(this MovieCategoryDetailEntity entity)
		{
			return new MovieCategoryDetailUpdateDto()
			{
				MovieID = entity.MovieID,
				MovieCategoryID = entity.MovieCategoryID,
			};
		}

	}

}
