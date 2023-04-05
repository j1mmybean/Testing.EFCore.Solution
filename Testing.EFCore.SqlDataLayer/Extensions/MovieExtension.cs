using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class MovieExtension
	{
		public static MovieEntity ModelToEntity(this Movies movie)
		{
			return new MovieEntity(movie.MovieName, movie.MovieIntroduction, movie.MovieLevelID, movie.MovieOnDate, movie.MovieOffDate, movie.MovieLength, movie.MoviePicture);
		}
		public static IEnumerable<MovieEntity> ModelsToEntities(this IEnumerable<Movies> movies)
		{
			var entities = new List<MovieEntity>();

			foreach (var movie in movies)
			{
				MovieEntity entity = movie.ModelToEntity();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
