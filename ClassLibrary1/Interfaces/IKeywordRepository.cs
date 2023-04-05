using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public interface IKeywordRepository
	{
		void Create(KeywordEntity entity);

		void Delete(int keywordID);

		void Update(KeywordEntity entity);

		IEnumerable<KeywordEntity> Search(int? keywordID, string Name);

		KeywordEntity GetKeyword(int keywordID);
		KeywordEntity GetByKeywordName(string name);
		IEnumerable<KeywordEntity> GetByArticleID(int articleID);
		IEnumerable<KeywordEntity> GetKeywordsLeave(int articleID);
	}
}
