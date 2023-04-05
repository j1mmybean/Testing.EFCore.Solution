using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Testing.EFCore.SqlDataLayer.EFCore;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class MovieCategoryRepository : IMovieCategoryRepository
	{
		InseparableContext inseparableEntities = new InseparableContext();
		public void Create(MovieCategoryEntity entity)
		{

			TMovieCategory movieCategory = new TMovieCategory();

			movieCategory.FMovieCategoryName = entity.Name;

			inseparableEntities.TMovieCategories.Add(movieCategory);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int movieCategoryID)
		{
			TMovieCategory movieCategory = inseparableEntities.TMovieCategories.Single(a => a.FMovieCategoryId == movieCategoryID);

			inseparableEntities.TMovieCategories.Remove(movieCategory) ;

			inseparableEntities.SaveChanges();
		}

		public void Update(MovieCategoryEntity entity)
		{
			TMovieCategory movieCategory = inseparableEntities.TMovieCategories.Single(a => a.FMovieCategoryId == entity.MovieCategoryID);

			movieCategory.FMovieCategoryName = entity.Name;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<MovieCategoryEntity> Search(int? movieCategoryID, string name)
		{
			//重新實作entityframework不然update時FormTMovieCategory不會跟新?????
			InseparableContext inseparable = new InseparableContext();

			IEnumerable<TMovieCategory> movieCategories = inseparable.TMovieCategories
				.Select(a => a);

			if (movieCategoryID.HasValue) movieCategories = movieCategories.Where(a => a.FMovieCategoryId == movieCategoryID);
			if (!string.IsNullOrEmpty(name)) movieCategories = movieCategories.Where(a => a.FMovieCategoryName.Contains(name))
																					.OrderBy(a => a.FMovieCategoryId);

			return movieCategories.ModelsToEntities();
		}

		public MovieCategoryEntity GetMovieCategory(int movieCategoryID)
		{
			TMovieCategory movieCategory = inseparableEntities.TMovieCategories.Single(a => a.FMovieCategoryId == movieCategoryID);
			MovieCategoryEntity entity = new MovieCategoryEntity(movieCategory.FMovieCategoryName)
			{
				MovieCategoryID = movieCategoryID,
			};
			return entity;
		}

		public MovieCategoryEntity GetByCategoryName(string name)
		{
			TMovieCategory movieCategory = inseparableEntities.TMovieCategories.SingleOrDefault(a => a.FMovieCategoryName == name);
			if (movieCategory == null) return null;
			MovieCategoryEntity entity = new MovieCategoryEntity(movieCategory.FMovieCategoryName)
			{
				MovieCategoryID = movieCategory.FMovieCategoryId,
			};
			return entity;
		}

		public IEnumerable<MovieCategoryEntity> GetByMovieID(int movieID)
		{
			InseparableContext inseparable = new InseparableContext();

			//用movieID在TMovieCategoryDetail找出文章的類別有哪些
			IEnumerable<TMovieCategoryDetail> details = inseparableEntities.TMovieCategoryDetails
				.Where(acd => acd.FMovieId == movieID);
			IEnumerable<int> movieCategoryIDs = details.Select(acd => acd.FMovieCategoryId);

			IEnumerable<TMovieCategory> movieCategories = inseparable.TMovieCategories
				.Where(ac => movieCategoryIDs.Contains(ac.FMovieCategoryId));

			return movieCategories.ModelsToEntities();
		}
		public IEnumerable<MovieCategoryEntity> GetCategoriesLeave(int movieID)
		{
			InseparableContext inseparable = new InseparableContext();

			//用movieID在TMovieCategoryDetail找出文章的類別有哪些
			IEnumerable<TMovieCategoryDetail> details = inseparableEntities.TMovieCategoryDetails
				.Where(acd => acd.FMovieId == movieID);
			IEnumerable<int> movieCategoryIDs = details.Select(acd => acd.FMovieCategoryId);

			//收集剩下的categories
			IEnumerable<TMovieCategory> movieCategoriesLeave = inseparable.TMovieCategories
				.Where(ac => !movieCategoryIDs.Contains(ac.FMovieCategoryId));

			return movieCategoriesLeave.ModelsToEntities();
		}
	}
}
