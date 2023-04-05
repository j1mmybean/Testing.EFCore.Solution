using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class CommentUpdateDto
	{
		public int ArticleID { get; set; }
		public int ItemNumber { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public string Content { get; set; }
	}
	public static class CommentUpdateDtoExtension
	{
		public static CommentUpdateDto UpdateEntityToDto(this CommentEntity entity)
		{
			return new CommentUpdateDto
			{
				ArticleID = entity.ArticleID,
				ItemNumber = entity.ItemNumber,
				MemberID = entity.MemberID,
				PostingDate = entity.PostingDate,
				Likes = entity.Likes,
				Content = entity.Content
			};
		}
		public static CommentEntity UpdateDtoToEntity(this CommentUpdateDto dto, int memberID, DateTime postingDate, int likes)
		{
			return new CommentEntity(dto.ArticleID, dto.ItemNumber, memberID, postingDate, likes, dto.Content);
		}
	}

}
