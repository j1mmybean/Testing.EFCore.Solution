using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordDetailCreateDto
	{
		public int ArticleID { get; set; }
		public int KeywordID { get; set; }

	}
	public static class KeywordDetailCreateDtoExtension
	{
		public static KeywordDetailEntity CreateDtoToEntity(this KeywordDetailCreateDto dto)
		{
			return new KeywordDetailEntity(dto.ArticleID, dto.KeywordID);
		}
	}

}
