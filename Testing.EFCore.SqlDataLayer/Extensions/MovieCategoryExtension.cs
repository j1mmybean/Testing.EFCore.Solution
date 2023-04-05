using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class MovieCategoryExtension
	{
		public static MovieCategoryEntity ModelToEntity(this MovieCategories category)
		{
			return new MovieCategoryEntity(category.MovieCategoryName) 
			{ 
				MovieCategoryID = category.MovieCategoryID
			};
		}
		public static IEnumerable<MovieCategoryEntity> ModelsToEntities(this IEnumerable<MovieCategories> categories)
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
