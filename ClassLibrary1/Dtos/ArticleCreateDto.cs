using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class ArticleCreateDto
	{
		public int ArticleID { get; set; }
		public string Title { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public int Clicks { get; set; }
		public string Content { get; set; }

	}
	public static class ArticleCreateDtoExtension
	{
		public static ArticleEntity CreateDtoToEntity(this ArticleCreateDto dto)
		{
			return new ArticleEntity(dto.Title, dto.MemberID, dto.PostingDate, dto.Likes, dto.Clicks, dto.Content);
		}
	}
}
