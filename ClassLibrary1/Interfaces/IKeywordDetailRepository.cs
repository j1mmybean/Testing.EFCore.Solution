using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public interface IKeywordDetailRepository
	{
		void Create(KeywordDetailEntity entity);

		void Delete(int articleID, int keywordID);

		void Update(KeywordDetailEntity entity);

		IEnumerable<KeywordDetailEntity> Search(int? articleID, int? keywordID);

		KeywordDetailEntity GetKeywordDetail(int articleID, int keywordID);

	}
}
