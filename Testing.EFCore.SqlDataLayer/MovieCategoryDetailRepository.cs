using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.EFCore.SqlDataLayer.EFCore;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class MovieCategoryDetailRepository :IMovieCategoryDetailRepository
	{
		InseparableContext inseparableEntities = new InseparableContext();
		public void Create(MovieCategoryDetailEntity entity)
		{

			TMovieCategoryDetail movieCategoryDetail = new TMovieCategoryDetail();

			movieCategoryDetail.FMovieId = entity.MovieID;
			movieCategoryDetail.FMovieCategoryId = entity.MovieCategoryID;

			inseparableEntities.TMovieCategoryDetails.Add(movieCategoryDetail);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int movieID, int movieCategoryID)
		{
			TMovieCategoryDetail movieCategoryDetail = inseparableEntities.TMovieCategoryDetails.Single(a => a.FMovieId == movieID && a.FMovieCategoryId == movieCategoryID);

			inseparableEntities.TMovieCategoryDetails.Remove(movieCategoryDetail);

			inseparableEntities.SaveChanges();
		}

		public void Update(MovieCategoryDetailEntity entity)
		{
			TMovieCategoryDetail movieCategoryDetail = inseparableEntities.TMovieCategoryDetails.Single(a => a.FMovieId == entity.MovieID);

			movieCategoryDetail.FMovieCategoryId = entity.MovieCategoryID;

			inseparableEntities.SaveChanges();
		}
		public void UpdateByCategoryID(MovieCategoryDetailEntity entity)
		{
			TMovieCategoryDetail movieCategoryDetail = inseparableEntities.TMovieCategoryDetails.Single(a => a.FMovieCategoryId == entity.MovieCategoryID);

			movieCategoryDetail.FMovieId = entity.MovieID;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<MovieCategoryDetailEntity> Search(int? movieID, int? movieCategoryID)
		{
			//重新實作entityframework不然update時FormTMovieCategoryDetail不會跟新?????
			InseparableContext inseparable = new InseparableContext();

			IEnumerable<TMovieCategoryDetail> movieCategoryDetails = inseparable.TMovieCategoryDetails
				.Select(a => a);

			if (movieID.HasValue) movieCategoryDetails = movieCategoryDetails.Where(a => a.FMovieId == movieID);
			if (movieCategoryID.HasValue) movieCategoryDetails = movieCategoryDetails.Where(a => a.FMovieCategoryId == movieCategoryID);

			return movieCategoryDetails.ModelsToEntities();
		}

		public MovieCategoryDetailEntity GetMovieCategoryDetail(int movieID, int movieCategoryID)
		{
			TMovieCategoryDetail movieCategoryDetail = inseparableEntities.TMovieCategoryDetails.Single(a => a.FMovieId == movieID && a.FMovieCategoryId == movieCategoryID);
			MovieCategoryDetailEntity entity = new MovieCategoryDetailEntity(movieID, movieCategoryID);
			return entity;
		}
	}
}
