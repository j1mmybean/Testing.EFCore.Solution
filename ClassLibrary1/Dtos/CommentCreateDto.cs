using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class CommentCreateDto
	{
		public int ArticleID { get; set; }
		public int ItemNumber { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public string Content { get; set; }
	}
	public static class CommentCreateDtoExtension
	{
		public static CommentEntity CreateDtoToEntity(this CommentCreateDto dto)
		{
			return new CommentEntity(dto.ArticleID, dto.ItemNumber, dto.MemberID, dto.PostingDate, dto.Likes, dto.Content);
		}
	}

}
