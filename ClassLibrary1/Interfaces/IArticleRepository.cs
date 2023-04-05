using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public interface IArticleRepository
	{
		void Create(ArticleEntity entity);

		void Delete(int articleID);

		void Update(ArticleEntity entity);

		IEnumerable<ArticleEntity> Search(int? articleID, string title, int? memberID, int? keywordID);

		ArticleEntity GetByArticleID(int articleID);
		ArticleEntity GetByTitle(string title);
	}
}
