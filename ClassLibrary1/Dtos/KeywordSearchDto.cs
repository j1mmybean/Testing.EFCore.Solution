using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordSearchDto
	{
		public int KeywordID { get; set; }
		public string Name { get; set; }

	}
	public static class KeywordSearchDtoExtension
	{
		public static KeywordSearchDto SearchEntityToDto(this KeywordEntity entity)
		{
			return new KeywordSearchDto
			{
				KeywordID = entity.KeywordID,
				Name = entity.Name,
			};
		}
		public static IEnumerable<KeywordSearchDto> SearchEntitiesToDtos(this IEnumerable<KeywordEntity> entities)
		{
			var dtos = new List<KeywordSearchDto>();

			foreach (var entity in entities)
			{
				KeywordSearchDto dto = entity.SearchEntityToDto();
				dtos.Add(dto);
			}
			return dtos;
		}
	}
}
