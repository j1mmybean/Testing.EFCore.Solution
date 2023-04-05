using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.EFCore.SqlDataLayer.EFCore;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class MovieCategoryExtension
	{
		public static MovieCategoryEntity ModelToEntity(this TMovieCategory category)
		{
			return new MovieCategoryEntity(category.FMovieCategoryName) 
			{ 
				MovieCategoryID = category.FMovieCategoryId
			};
		}
		public static IEnumerable<MovieCategoryEntity> ModelsToEntities(this IEnumerable<TMovieCategory> categories)
		{
			var entities = new List<MovieCategoryEntity>();

			foreach (var category in categories)
			{
				MovieCategoryEntity entity = category.ModelToEntity();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
