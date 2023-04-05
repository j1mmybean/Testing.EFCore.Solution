using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class KeywordRepository : IKeywordRepository
	{
		InseparableEntities inseparableEntities = new InseparableEntities();
		public void Create(KeywordEntity entity)
		{

			Keywords articleKeyword = new Keywords();

			articleKeyword.KeywordName = entity.Name;

			inseparableEntities.Keywords.Add(articleKeyword);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int articleKeywordID)
		{
			Keywords articleKeyword = inseparableEntities.Keywords.Single(a => a.KeywordID == articleKeywordID);

			inseparableEntities.Keywords.Remove(articleKeyword) ;

			inseparableEntities.SaveChanges();
		}

		public void Update(KeywordEntity entity)
		{
			Keywords articleKeyword = inseparableEntities.Keywords.Single(a => a.KeywordID == entity.KeywordID);

			articleKeyword.KeywordName = entity.Name;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<KeywordEntity> Search(int? articleKeywordID, string name)
		{
			//重新實作entityframework不然update時FormKeywords不會跟新?????
			InseparableEntities inseparable = new InseparableEntities();

			IEnumerable<Keywords> keywords = inseparable.Keywords
				.Select(a => a);

			if (articleKeywordID.HasValue) keywords = keywords.Where(a => a.KeywordID == articleKeywordID);
			if (!string.IsNullOrEmpty(name)) keywords = keywords.Where(a => a.KeywordName.Contains(name))
																					.OrderBy(a => a.KeywordID);

			return keywords.ModelsToEntities();
		}

		public KeywordEntity GetKeyword(int articleKeywordID)
		{
			Keywords articleKeyword = inseparableEntities.Keywords.Single(a => a.KeywordID == articleKeywordID);
			KeywordEntity entity = new KeywordEntity(articleKeyword.KeywordName)
			{
				KeywordID = articleKeywordID,
			};
			return entity;
		}

		public KeywordEntity GetByKeywordName(string name)
		{
			Keywords articleKeyword = inseparableEntities.Keywords.SingleOrDefault(a => a.KeywordName == name);
			if (articleKeyword == null) return null;
			KeywordEntity entity = new KeywordEntity(articleKeyword.KeywordName)
			{
				KeywordID = articleKeyword.KeywordID,
			};
			return entity;
		}

		public IEnumerable<KeywordEntity> GetByArticleID(int articleID)
		{
			InseparableEntities inseparable = new InseparableEntities();

			//用articleID在KeywordDetails找出文章的類別有哪些
			IEnumerable<KeywordDetails> details = inseparableEntities.KeywordDetails
				.Where(acd => acd.ArticleID == articleID);
			IEnumerable<int> articleKeywordIDs = details.Select(acd => acd.KeywordID);

			IEnumerable<Keywords> keywords = inseparable.Keywords
				.Where(ac => articleKeywordIDs.Contains(ac.KeywordID));

			return keywords.ModelsToEntities();
		}
		public IEnumerable<KeywordEntity> GetKeywordsLeave(int articleID)
		{
			InseparableEntities inseparable = new InseparableEntities();

			//用articleID在KeywordDetails找出文章的類別有哪些
			IEnumerable<KeywordDetails> details = inseparableEntities.KeywordDetails
				.Where(acd => acd.ArticleID == articleID);
			IEnumerable<int> articleKeywordIDs = details.Select(acd => acd.KeywordID);

			//收集剩下的keywords
			IEnumerable<Keywords> keywordsLeave = inseparable.Keywords
				.Where(ac => !articleKeywordIDs.Contains(ac.KeywordID));

			return keywordsLeave.ModelsToEntities();
		}
	}
}
