using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordDetailUpdateDto
	{
		public int ArticleID { get; set; }
		public int KeywordID { get; set; }
	}
	public static class KeywordDetailUpdateDtoExtension
	{
		public static KeywordDetailEntity UpdateDtoToEntity(this KeywordDetailUpdateDto dto)
		{
			return new KeywordDetailEntity(dto.ArticleID, dto.KeywordID);
		}
		public static KeywordDetailUpdateDto UpdateEntityToDto(this KeywordDetailEntity entity)
		{
			return new KeywordDetailUpdateDto()
			{
				ArticleID = entity.ArticleID,
				KeywordID = entity.KeywordID,
			};
		}

	}

}
