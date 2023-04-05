using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.EFCore.SqlDataLayer.EFCore;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class MovieExtension
	{
		public static MovieEntity ModelToEntity(this TMovie movie)
		{
			return new MovieEntity(movie.FMovieName, movie.FMovieIntroduction, movie.FMovieLevelId, movie.FMovieOnDate, movie.FMovieOffDate, movie.FMovieLength, movie.FMovieImagePath);
		}
		public static IEnumerable<MovieEntity> ModelsToEntities(this IEnumerable<TMovie> movies)
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
