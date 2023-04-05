using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class KeywordDetailRepository :IKeywordDetailRepository
	{
		InseparableEntities inseparableEntities = new InseparableEntities();
		public void Create(KeywordDetailEntity entity)
		{

			KeywordDetails articleKeywordDetail = new KeywordDetails();

			articleKeywordDetail.ArticleID = entity.ArticleID;
			articleKeywordDetail.KeywordID = entity.KeywordID;

			inseparableEntities.KeywordDetails.Add(articleKeywordDetail);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int articleID, int articleKeywordID)
		{
			KeywordDetails articleKeywordDetail = inseparableEntities.KeywordDetails.Single(a => a.ArticleID == articleID && a.KeywordID == articleKeywordID);

			inseparableEntities.KeywordDetails.Remove(articleKeywordDetail);

			inseparableEntities.SaveChanges();
		}

		public void Update(KeywordDetailEntity entity)
		{
			KeywordDetails articleKeywordDetail = inseparableEntities.KeywordDetails.Single(a => a.ArticleID == entity.ArticleID);

			articleKeywordDetail.KeywordID = entity.KeywordID;

			inseparableEntities.SaveChanges();
		}
		public void UpdateByKeywordID(KeywordDetailEntity entity)
		{
			KeywordDetails articleKeywordDetail = inseparableEntities.KeywordDetails.Single(a => a.KeywordID == entity.KeywordID);

			articleKeywordDetail.ArticleID = entity.ArticleID;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<KeywordDetailEntity> Search(int? articleID, int? articleKeywordID)
		{
			//重新實作entityframework不然update時FormKeywordDetails不會跟新?????
			InseparableEntities inseparable = new InseparableEntities();

			IEnumerable<KeywordDetails> articleKeywordDetails = inseparable.KeywordDetails
				.Select(a => a);

			if (articleID.HasValue) articleKeywordDetails = articleKeywordDetails.Where(a => a.ArticleID == articleID);
			if (articleKeywordID.HasValue) articleKeywordDetails = articleKeywordDetails.Where(a => a.KeywordID == articleKeywordID);

			return articleKeywordDetails.ModelsToEntities();
		}

		public KeywordDetailEntity GetKeywordDetail(int articleID, int articleKeywordID)
		{
			KeywordDetails articleKeywordDetail = inseparableEntities.KeywordDetails.Single(a => a.ArticleID == articleID && a.KeywordID == articleKeywordID);
			KeywordDetailEntity entity = new KeywordDetailEntity(articleID, articleKeywordID);
			return entity;
		}
	}
}
