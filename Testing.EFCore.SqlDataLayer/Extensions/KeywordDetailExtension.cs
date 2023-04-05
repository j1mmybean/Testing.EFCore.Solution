using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class KeywordDetailExtension
	{
		public static KeywordDetailEntity ModelToEntity(this KeywordDetails detail)
		{
			return new KeywordDetailEntity(detail.ArticleID, detail.KeywordID);
		}
		public static IEnumerable<KeywordDetailEntity> ModelsToEntities(this IEnumerable<KeywordDetails> details)
		{
			var entities = new List<KeywordDetailEntity>();

			foreach (var detail in details)
			{
				KeywordDetailEntity entity = detail.ModelToEntity();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
