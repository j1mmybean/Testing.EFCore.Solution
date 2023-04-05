using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class ArticleRepository : IArticleRepository
	{
		InseparableEntities inseparableEntities = new InseparableEntities();
		public void Create(ArticleEntity entity)
		{

			Articles article = new Articles();

			article.ArticleTitle = entity.Title;
			article.MemberID = entity.MemberID;
			article.ArticlePostingDate = entity.PostingDate;
			article.ArticleContent = entity.Content;

			inseparableEntities.Articles.Add(article);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int articleID)
		{
			Articles article = inseparableEntities.Articles.Single(a => a.ArticleID == articleID);

			article.ArticleTitle = "文章已刪除";
			article.ArticleContent = "文章已刪除";

			inseparableEntities.SaveChanges();
		}

		public void Update(ArticleEntity entity)
		{
			Articles article = inseparableEntities.Articles.Single(a => a.ArticleID == entity.ArticleID);

			article.ArticleTitle = entity.Title;
			article.ArticleContent = entity.Content;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<ArticleEntity> Search(int? articleID, string title, int? memberID, int? keywordID)
		{
			//重新實作entityframework不然update時FormArticles不會跟新?????
			InseparableEntities inseparable = new InseparableEntities();

			IEnumerable<Articles> articles = inseparable.Articles;

			if (articleID.HasValue) articles = articles.Where(a => a.ArticleID == articleID);
			if (!string.IsNullOrEmpty(title)) articles = articles.Where(a => a.ArticleTitle.Contains(title));
			if (memberID.HasValue) articles = articles.Where(a => a.MemberID == memberID);

			//多對多查詢

			if (keywordID.HasValue) 
			{
				IEnumerable<KeywordDetails> articleKeywordDetails = inseparable.KeywordDetails
					.Where(acd => acd.KeywordID == keywordID);
				List<int> articleIDs = new List<int>();
				foreach (var item in articleKeywordDetails)
				{
					articleIDs.Add(item.ArticleID);
				}

				articles = articles.Where(a => articleIDs.Contains(a.ArticleID));
			};

			return articles.ModelsToEntities();
		}

		public ArticleEntity GetByArticleID(int articleID)
		{
			Articles article = inseparableEntities.Articles.SingleOrDefault(a => a.ArticleID == articleID);
			if (article == null) return null;

			ArticleEntity entity = new ArticleEntity(article.ArticleTitle, article.MemberID, article.ArticlePostingDate,  article.ArticleLikes, article.ArticleClicks, article.ArticleContent)
			{
				ArticleID = articleID
			};
			return entity;
		}

		public ArticleEntity GetByTitle(string title)
		{
			Articles article = inseparableEntities.Articles.SingleOrDefault(a => a.ArticleTitle == title);
			if (article == null) return null;

			ArticleEntity entity = new ArticleEntity(article.ArticleTitle, article.MemberID, article.ArticlePostingDate, article.ArticleLikes, article.ArticleClicks, article.ArticleContent)
			{
				ArticleID = article.ArticleID
			};

			return entity;
		}
	}
}
