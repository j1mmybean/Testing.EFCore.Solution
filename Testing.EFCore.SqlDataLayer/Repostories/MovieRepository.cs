using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class MovieRepository : IMovieRepository
	{
		InseparableEntities InseparableDb = new InseparableEntities();
		public IQueryable<Movies> Search(int? MovieID, string MovieName, DateTime? OffDate, int? Level)
		{
			IQueryable<Movies> search = InseparableDb.Movies;

			if (MovieID != null) search = search.Where(m => m.MovieID == MovieID);
			if (MovieName != null) search = search.Where(m => m.MovieName.Contains(MovieName));
			if (OffDate != null) search = search.Where(m => m.MovieOffDate >= OffDate);
			if (Level != null) search = search.Where(m => m.MovieLevelID == Level);

			return search;
		}

		public IQueryable<Movies> GetMovie(int? MovieID)
		{
			var get = InseparableDb.Movies.Where(m=>m.MovieID==MovieID);

			return get;
		}
		/// <summary>
		/// 
		/// </summary>
		InseparableEntities inseparableEntities = new InseparableEntities();
		public void Create(MovieEntity entity)
		{

			Movies movie = new Movies();

			movie.MovieID = entity.MovieID;
			movie.MovieLevelID = entity.LevelID;
			movie.MovieOnDate = entity.OnDate;
			movie.MovieIntroduction = entity.Introduction;

			inseparableEntities.Movies.Add(movie);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int movieID)
		{
			Movies movie = inseparableEntities.Movies.Single(m => m.MovieID == movieID);

			movie.MovieName = "電影已刪除";

			inseparableEntities.SaveChanges();
		}

		public void Update(MovieEntity entity)
		{
			Movies movie = inseparableEntities.Movies.Single(m => m.MovieID == entity.MovieID);

			movie.MovieName = entity.Name;
			movie.MovieIntroduction = entity.Introduction;
			movie.MovieLevelID = entity.LevelID;
			movie.MovieOnDate = entity.OnDate;
			movie.MovieOffDate = entity.OffDate;
			movie.MovieLength = entity.Length;
			movie.MoviePicture = entity.Picture;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<MovieEntity> Search(int? movieID, string name, int? levelID, DateTime? onDate, DateTime? offDate)
		{
			//重新實作entityframework不然update時FormMovies不會跟新?????
			InseparableEntities inseparable = new InseparableEntities();

			IEnumerable<Movies> movies = inseparable.Movies;

			if (movieID.HasValue) movies = movies.Where(m => m.MovieID == movieID);
			if (!string.IsNullOrEmpty(name)) movies = movies.Where(m => m.MovieName.Contains(name));
			if (levelID.HasValue) movies = movies.Where(m => m.MovieLevelID == levelID);
			if (offDate.HasValue) movies = movies.Where(m => m.MovieOffDate >= offDate);

			return movies.ModelsToEntities();
		}

		public MovieEntity GetByMovieID(int movieID)
		{
			Movies movie = inseparableEntities.Movies.Single(m => m.MovieID == movieID);
			MovieEntity entity = new MovieEntity(movie.MovieName, movie.MovieIntroduction, movie.MovieLevelID, movie.MovieOnDate, movie.MovieOffDate, movie.MovieLength, movie.MoviePicture)
			{
				MovieID = movieID,
			};
			return entity;
		}

		public MovieEntity GetByMovieName(string name)
		{
			Movies movie = inseparableEntities.Movies.Single(m => m.MovieName == name);
			MovieEntity entity = new MovieEntity(movie.MovieName, movie.MovieIntroduction, movie.MovieLevelID, movie.MovieOnDate, movie.MovieOffDate, movie.MovieLength, movie.MoviePicture)
			{
				MovieID = movie.MovieID,
			};
			return entity;
		}
	}
}
