using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryDetailService
	{
		private readonly IMovieCategoryDetailRepository repo;

		public MovieCategoryDetailService(IMovieCategoryDetailRepository repo)
		{
			this.repo = repo;
		}
		public IEnumerable<MovieCategoryDetailSearchDto> Search(int? movieID, int? categoryID)
		{
			IEnumerable<MovieCategoryDetailEntity> entities = repo.Search(movieID, categoryID);

			return entities.SearchEntitiesToDtos();
		}

		public void Create(MovieCategoryDetailCreateDto dto)
		{
			var entity = dto.CreateDtoToEntity();
			repo.Create(entity);
		}

		public void Update(MovieCategoryDetailUpdateDto dto)
		{
			var entity = dto.UpdateDtoToEntity();

			repo.Update(entity);
		}
		//public MovieCategoryDetailUpdateDto GetMovieCategoryDetail(int movieID, int itemNumber)
		//{
		//	var entity = repo.GetMovieCategoryDetail(movieID, itemNumber);
		//	return entity.UpdateEntityToDto();
		//}
	}
}
