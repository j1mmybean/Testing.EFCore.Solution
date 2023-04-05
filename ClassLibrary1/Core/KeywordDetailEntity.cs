using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordDetailEntity
	{
		public int ArticleID { get; set; }
		public int KeywordID { get; set; }
		public KeywordDetailEntity(int articleID, int keywordID)
		{
			ArticleID = articleID;
			KeywordID = keywordID;
		}
	}
}
