using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class MovieCategoryDetailRepository :IMovieCategoryDetailRepository
	{
		InseparableEntities inseparableEntities = new InseparableEntities();
		public void Create(MovieCategoryDetailEntity entity)
		{

			MovieCategoryDetails movieCategoryDetail = new MovieCategoryDetails();

			movieCategoryDetail.MovieID = entity.MovieID;
			movieCategoryDetail.MovieCategoryID = entity.MovieCategoryID;

			inseparableEntities.MovieCategoryDetails.Add(movieCategoryDetail);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int movieID, int movieCategoryID)
		{
			MovieCategoryDetails movieCategoryDetail = inseparableEntities.MovieCategoryDetails.Single(a => a.MovieID == movieID && a.MovieCategoryID == movieCategoryID);

			inseparableEntities.MovieCategoryDetails.Remove(movieCategoryDetail);

			inseparableEntities.SaveChanges();
		}

		public void Update(MovieCategoryDetailEntity entity)
		{
			MovieCategoryDetails movieCategoryDetail = inseparableEntities.MovieCategoryDetails.Single(a => a.MovieID == entity.MovieID);

			movieCategoryDetail.MovieCategoryID = entity.MovieCategoryID;

			inseparableEntities.SaveChanges();
		}
		public void UpdateByCategoryID(MovieCategoryDetailEntity entity)
		{
			MovieCategoryDetails movieCategoryDetail = inseparableEntities.MovieCategoryDetails.Single(a => a.MovieCategoryID == entity.MovieCategoryID);

			movieCategoryDetail.MovieID = entity.MovieID;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<MovieCategoryDetailEntity> Search(int? movieID, int? movieCategoryID)
		{
			//重新實作entityframework不然update時FormMovieCategoryDetails不會跟新?????
			InseparableEntities inseparable = new InseparableEntities();

			IEnumerable<MovieCategoryDetails> movieCategoryDetails = inseparable.MovieCategoryDetails
				.Select(a => a);

			if (movieID.HasValue) movieCategoryDetails = movieCategoryDetails.Where(a => a.MovieID == movieID);
			if (movieCategoryID.HasValue) movieCategoryDetails = movieCategoryDetails.Where(a => a.MovieCategoryID == movieCategoryID);

			return movieCategoryDetails.ModelsToEntities();
		}

		public MovieCategoryDetailEntity GetMovieCategoryDetail(int movieID, int movieCategoryID)
		{
			MovieCategoryDetails movieCategoryDetail = inseparableEntities.MovieCategoryDetails.Single(a => a.MovieID == movieID && a.MovieCategoryID == movieCategoryID);
			MovieCategoryDetailEntity entity = new MovieCategoryDetailEntity(movieID, movieCategoryID);
			return entity;
		}
	}
}
