using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISpan.Inseparable.BLL
{
	public class MovieCategoryService
	{
		private readonly IMovieCategoryRepository repo;

		public MovieCategoryService(IMovieCategoryRepository repo)
		{
			this.repo = repo;
		}
		public IEnumerable<MovieCategorySearchDto> Search(int? movieCategoryID, string name)
		{
			IEnumerable<MovieCategoryEntity> entities = repo.Search(movieCategoryID, name);

			return entities.SearchEntitiesToDtos();
		}

		public void Create(MovieCategoryCreateDto dto)
		{
			var entity = dto.CreateDtoToEntity();

			if (string.IsNullOrEmpty(entity.Name)) throw new Exception("請正確填寫類別名稱");

			// 驗證CategoryName 是否唯一
			var entityInDb = repo.GetByCategoryName(entity.Name);
			if (entityInDb != null) throw new Exception("類別已存在");

			repo.Create(entity);
		}

		public void Update(MovieCategoryUpdateDto dto)
		{
			var updateEntity = dto.UpdateDtoToEntity();

			if (string.IsNullOrEmpty(updateEntity.Name)) throw new Exception("請正確填寫類別名稱");

			// 驗證CategoryName 是否唯一
			var entityInDb = repo.GetByCategoryName(updateEntity.Name);
			if (entityInDb != null && entityInDb.MovieCategoryID != updateEntity.MovieCategoryID) throw new Exception("存在同名之類別");

			repo.Update(updateEntity);
		}
		public MovieCategoryUpdateDto GetMovieCategory(int MovieCategoryID)
		{
			var entity = repo.GetMovieCategory(MovieCategoryID);
			return entity.UpdateEntityToDto();
		}

		public IEnumerable<MovieCategorySearchDto> GetByMovieID(int movieID)
		{
			IEnumerable<MovieCategoryEntity> entities = repo.GetByMovieID(movieID);

			return entities.SearchEntitiesToDtos();
		}
		public IEnumerable<MovieCategorySearchDto> GetCategoriesLeave(int movieID)
		{
			IEnumerable<MovieCategoryEntity> entitiesLeave = repo.GetCategoriesLeave(movieID);

			return entitiesLeave.SearchEntitiesToDtos();
		}
	}
}
