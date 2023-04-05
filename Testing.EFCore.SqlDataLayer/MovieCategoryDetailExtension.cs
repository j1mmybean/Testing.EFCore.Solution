using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.EFCore.SqlDataLayer.EFCore;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class MovieCategoryDetailExtension
	{
		public static MovieCategoryDetailEntity ModelToEntity(this TMovieCategoryDetail detail)
		{
			return new MovieCategoryDetailEntity(detail.FMovieId, detail.FMovieCategoryId);
		}
		public static IEnumerable<MovieCategoryDetailEntity> ModelsToEntities(this IEnumerable<TMovieCategoryDetail> details)
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
