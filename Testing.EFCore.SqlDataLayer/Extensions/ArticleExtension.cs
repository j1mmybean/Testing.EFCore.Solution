using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class ArticleExtension
	{
		public static ArticleEntity ModelToEntity(this Articles article)
		{
			return new ArticleEntity(article.ArticleTitle, article.MemberID, article.ArticlePostingDate, article.ArticleLikes, article.ArticleClicks, article.ArticleContent)
			{
				ArticleID = article.ArticleID,
			};
		}
		public static IEnumerable<ArticleEntity> ModelsToEntities(this IEnumerable<Articles> articles)
		{
			var entities = new List<ArticleEntity>();

			foreach (var article in articles)
			{
				ArticleEntity entity = article.ModelToEntity();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
