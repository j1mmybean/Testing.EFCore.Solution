using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordUpdateDto
	{
		public int KeywordID { get; set; }
		public string Name { get; set; }

	}
	public static class KeywordUpdateDtoExtension
	{
		public static KeywordUpdateDto UpdateEntityToDto(this KeywordEntity entity)
		{
			return new KeywordUpdateDto
			{
				KeywordID = entity.KeywordID,
				Name = entity.Name,
			};
		}
		public static KeywordEntity UpdateDtoToEntity(this KeywordUpdateDto dto)
		{
			return new KeywordEntity(dto.Name)
			{
				KeywordID = dto.KeywordID,
			};
		}
	}

}
