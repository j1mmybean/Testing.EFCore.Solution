using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class KeywordExtension
	{
		public static KeywordEntity ModelToEntity(this Keywords category)
		{
			return new KeywordEntity(category.KeywordName) 
			{ 
				KeywordID = category.KeywordID
			};
		}
		public static IEnumerable<KeywordEntity> ModelsToEntities(this IEnumerable<Keywords> keywords)
		{
			var entities = new List<KeywordEntity>();

			foreach (var category in keywords)
			{
				KeywordEntity entity = category.ModelToEntity();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
