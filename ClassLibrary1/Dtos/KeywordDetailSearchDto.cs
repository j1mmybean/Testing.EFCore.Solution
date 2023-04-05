using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordDetailSearchDto
	{
		public int ArticleID { get; set; }
		public int KeywordID { get; set; }
	}
	public static class KeywordDetailSearchDtoExtension
	{
		public static KeywordDetailSearchDto SearchEntityToDto(this KeywordDetailEntity entity)
		{
			return new KeywordDetailSearchDto()
			{
				ArticleID = entity.ArticleID,
				KeywordID = entity.KeywordID,
			};
		}
		public static IEnumerable<KeywordDetailSearchDto> SearchEntitiesToDtos(this IEnumerable<KeywordDetailEntity> entities)
		{
			var dtos = new List<KeywordDetailSearchDto>();

			foreach (var entity in entities)
			{
				KeywordDetailSearchDto dto = entity.SearchEntityToDto();
				dtos.Add(dto);
			}
			return dtos;
		}
	}
}
