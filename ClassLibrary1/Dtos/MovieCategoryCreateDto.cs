using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryCreateDto
	{
		public int MovieCategoryID { get; set; }
		public string Name { get; set; }
	}
	public static class MovieCategoryCreateDtoExtension
	{
		public static MovieCategoryEntity CreateDtoToEntity(this MovieCategoryCreateDto dto)
		{
			return new MovieCategoryEntity(dto.Name);
		}
	}
}
