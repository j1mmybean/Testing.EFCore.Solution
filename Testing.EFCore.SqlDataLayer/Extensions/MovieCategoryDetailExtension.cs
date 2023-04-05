using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class MovieCategoryDetailExtension
	{
		public static MovieCategoryDetailEntity ModelToEntity(this MovieCategoryDetails detail)
		{
			return new MovieCategoryDetailEntity(detail.MovieID, detail.MovieCategoryID);
		}
		public static IEnumerable<MovieCategoryDetailEntity> ModelsToEntities(this IEnumerable<MovieCategoryDetails> details)
		{
			var entities = new List<MovieCategoryDetailEntity>();

			foreach (var detail in details)
			{
				MovieCategoryDetailEntity entity = detail.ModelToEntity();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
