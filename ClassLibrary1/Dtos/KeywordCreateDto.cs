using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordCreateDto
	{
		public int KeywordID { get; set; }
		public string Name { get; set; }
	}
	public static class KeywordCreateDtoExtension
	{
		public static KeywordEntity CreateDtoToEntity(this KeywordCreateDto dto)
		{
			return new KeywordEntity(dto.Name);
		}
	}
}
