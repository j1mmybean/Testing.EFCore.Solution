using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class MovieCategoryRepository : IMovieCategoryRepository
	{
		InseparableEntities inseparableEntities = new InseparableEntities();
		public void Create(MovieCategoryEntity entity)
		{

			MovieCategories movieCategory = new MovieCategories();

			movieCategory.MovieCategoryName = entity.Name;

			inseparableEntities.MovieCategories.Add(movieCategory);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int movieCategoryID)
		{
			MovieCategories movieCategory = inseparableEntities.MovieCategories.Single(a => a.MovieCategoryID == movieCategoryID);

			inseparableEntities.MovieCategories.Remove(movieCategory) ;

			inseparableEntities.SaveChanges();
		}

		public void Update(MovieCategoryEntity entity)
		{
			MovieCategories movieCategory = inseparableEntities.MovieCategories.Single(a => a.MovieCategoryID == entity.MovieCategoryID);

			movieCategory.MovieCategoryName = entity.Name;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<MovieCategoryEntity> Search(int? movieCategoryID, string name)
		{
			//重新實作entityframework不然update時FormMovieCategories不會跟新?????
			InseparableEntities inseparable = new InseparableEntities();

			IEnumerable<MovieCategories> movieCategories = inseparable.MovieCategories
				.Select(a => a);

			if (movieCategoryID.HasValue) movieCategories = movieCategories.Where(a => a.MovieCategoryID == movieCategoryID);
			if (!string.IsNullOrEmpty(name)) movieCategories = movieCategories.Where(a => a.MovieCategoryName.Contains(name))
																					.OrderBy(a => a.MovieCategoryID);

			return movieCategories.ModelsToEntities();
		}

		public MovieCategoryEntity GetMovieCategory(int movieCategoryID)
		{
			MovieCategories movieCategory = inseparableEntities.MovieCategories.Single(a => a.MovieCategoryID == movieCategoryID);
			MovieCategoryEntity entity = new MovieCategoryEntity(movieCategory.MovieCategoryName)
			{
				MovieCategoryID = movieCategoryID,
			};
			return entity;
		}

		public MovieCategoryEntity GetByCategoryName(string name)
		{
			MovieCategories movieCategory = inseparableEntities.MovieCategories.SingleOrDefault(a => a.MovieCategoryName == name);
			if (movieCategory == null) return null;
			MovieCategoryEntity entity = new MovieCategoryEntity(movieCategory.MovieCategoryName)
			{
				MovieCategoryID = movieCategory.MovieCategoryID,
			};
			return entity;
		}

		public IEnumerable<MovieCategoryEntity> GetByMovieID(int movieID)
		{
			InseparableEntities inseparable = new InseparableEntities();

			//用movieID在MovieCategoryDetails找出文章的類別有哪些
			IEnumerable<MovieCategoryDetails> details = inseparableEntities.MovieCategoryDetails
				.Where(acd => acd.MovieID == movieID);
			IEnumerable<int> movieCategoryIDs = details.Select(acd => acd.MovieCategoryID);

			IEnumerable<MovieCategories> movieCategories = inseparable.MovieCategories
				.Where(ac => movieCategoryIDs.Contains(ac.MovieCategoryID));

			return movieCategories.ModelsToEntities();
		}
		public IEnumerable<MovieCategoryEntity> GetCategoriesLeave(int movieID)
		{
			InseparableEntities inseparable = new InseparableEntities();

			//用movieID在MovieCategoryDetails找出文章的類別有哪些
			IEnumerable<MovieCategoryDetails> details = inseparableEntities.MovieCategoryDetails
				.Where(acd => acd.MovieID == movieID);
			IEnumerable<int> movieCategoryIDs = details.Select(acd => acd.MovieCategoryID);

			//收集剩下的categories
			IEnumerable<MovieCategories> movieCategoriesLeave = inseparable.MovieCategories
				.Where(ac => !movieCategoryIDs.Contains(ac.MovieCategoryID));

			return movieCategoriesLeave.ModelsToEntities();
		}
	}
}
