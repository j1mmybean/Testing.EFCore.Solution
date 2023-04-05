using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public interface IMovieCategoryRepository
	{
		void Create(MovieCategoryEntity entity);

		void Delete(int movieCategoryID);

		void Update(MovieCategoryEntity entity);

		IEnumerable<MovieCategoryEntity> Search(int? movieCategoryID, string Name);

		MovieCategoryEntity GetMovieCategory(int movieCategoryID);
		MovieCategoryEntity GetByCategoryName(string name);
		IEnumerable<MovieCategoryEntity> GetByMovieID(int movieID);
		IEnumerable<MovieCategoryEntity> GetCategoriesLeave(int movieID);
	}
}
