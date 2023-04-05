using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public interface IMovieRepository
	{
		void Create(MovieEntity entity);

		void Delete(int movieID);

		void Update(MovieEntity entity);

		IEnumerable<MovieEntity> Search(int? movieID, string name, int? levelID, DateTime? onDate, DateTime? offDate);

		MovieEntity GetByMovieID(int movieID);
		MovieEntity GetByMovieName(string name);
	}
}
