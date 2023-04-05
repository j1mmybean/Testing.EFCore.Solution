using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.EFCore.SqlDataLayer.EFCore;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class MovieRepository : IMovieRepository
	{
		InseparableContext InseparableDb = new InseparableContext();
		public IQueryable<TMovie> Search(int? MovieID, string FMovieName, DateTime? OffDate, int? Level)
		{
			IQueryable<TMovie> search = InseparableDb.TMovies;

			if (MovieID != null) search = search.Where(m => m.FMovieId == MovieID);
			if (FMovieName != null) search = search.Where(m => m.FMovieName.Contains(FMovieName));
			if (OffDate != null) search = search.Where(m => m.FMovieOffDate >= OffDate);
			if (Level != null) search = search.Where(m => m.FMovieLevelId == Level);

			return search;
		}

		public IQueryable<TMovie> GetMovie(int? MovieID)
		{
			var get = InseparableDb.TMovies.Where(m=>m.FMovieId==MovieID);

			return get;
		}
		/// <summary>
		/// 
		/// </summary>
		InseparableContext inseparableEntities = new InseparableContext();
		public void Create(MovieEntity entity)
		{

			TMovie movie = new TMovie();

			movie.FMovieId = entity.MovieID;
			movie.FMovieLevelId = entity.LevelID;
			movie.FMovieOnDate = entity.OnDate;
			movie.FMovieIntroduction = entity.Introduction;

			inseparableEntities.TMovies.Add(movie);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int movieID)
		{
			TMovie movie = inseparableEntities.TMovies.Single(m => m.FMovieId == movieID);

			movie.FMovieName = "電影已刪除";

			inseparableEntities.SaveChanges();
		}

		public void Update(MovieEntity entity)
		{
			TMovie movie = inseparableEntities.TMovies.Single(m => m.FMovieId == entity.MovieID);

			movie.FMovieName = entity.Name;
			movie.FMovieIntroduction = entity.Introduction;
			movie.FMovieLevelId = entity.LevelID;
			movie.FMovieOnDate = entity.OnDate;
			movie.FMovieOffDate = entity.OffDate;
			movie.FMovieLength = entity.Length;
			movie.FMovieImagePath = entity.ImagePath;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<MovieEntity> Search(int? movieID, string name, int? levelID, DateTime? onDate, DateTime? offDate)
		{
			//重新實作entityframework不然update時FormTMovie不會跟新?????
			InseparableContext inseparable = new InseparableContext();

			IEnumerable<TMovie> movies = inseparable.TMovies;

			if (movieID.HasValue) movies = movies.Where(m => m.FMovieId == movieID);
			if (!string.IsNullOrEmpty(name)) movies = movies.Where(m => m.FMovieName.Contains(name));
			if (levelID.HasValue) movies = movies.Where(m => m.FMovieLevelId == levelID);
			if (offDate.HasValue) movies = movies.Where(m => m.FMovieOffDate >= offDate);

			return movies.ModelsToEntities();
		}

		public MovieEntity GetByMovieID(int movieID)
		{
			TMovie movie = inseparableEntities.TMovies.Single(m => m.FMovieId == movieID);
			MovieEntity entity = new MovieEntity(movie.FMovieName, movie.FMovieIntroduction, movie.FMovieLevelId, movie.FMovieOnDate, movie.FMovieOffDate, movie.FMovieLength, movie.FMovieImagePath)
			{
				MovieID = movieID,
			};
			return entity;
		}

		public MovieEntity GetByMovieName(string name)
		{
			TMovie movie = inseparableEntities.TMovies.Single(m => m.FMovieName == name);
			MovieEntity entity = new MovieEntity(movie.FMovieName, movie.FMovieIntroduction, movie.FMovieLevelId, movie.FMovieOnDate, movie.FMovieOffDate, movie.FMovieLength, movie.FMovieImagePath)
			{
				MovieID = movie.FMovieId,
			};
			return entity;
		}
	}
}
