using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryDetailCreateDto
	{
		public int MovieID { get; set; }
		public int MovieCategoryID { get; set; }

	}
	public static class MovieCategoryDetailCreateDtoExtension
	{
		public static MovieCategoryDetailEntity CreateDtoToEntity(this MovieCategoryDetailCreateDto dto)
		{
			return new MovieCategoryDetailEntity(dto.MovieID, dto.MovieCategoryID);
		}
	}

}
