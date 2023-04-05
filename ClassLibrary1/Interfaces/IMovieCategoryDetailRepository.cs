using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public interface IMovieCategoryDetailRepository
	{
		void Create(MovieCategoryDetailEntity entity);

		void Delete(int movieID, int categoryID);

		void Update(MovieCategoryDetailEntity entity);

		IEnumerable<MovieCategoryDetailEntity> Search(int? movieID, int? categoryID);

		MovieCategoryDetailEntity GetMovieCategoryDetail(int movieID, int categoryID);

	}
}
