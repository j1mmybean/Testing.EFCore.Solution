using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class ArticleUpdateDto
	{
		public int ArticleID { get; set; }
		public string Title { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public int Clicks { get; set; }
		public string Content { get; set; }
	}
	public static class ArticleUpdateDtoExtension
	{
		public static ArticleUpdateDto UpdateEntityToDto(this ArticleEntity entity)
		{
			return new ArticleUpdateDto
			{
				ArticleID = entity.ArticleID,
				Title = entity.Title,
				MemberID = entity.MemberID,
				PostingDate = entity.PostingDate,
				Likes = entity.Likes,
				Clicks = entity.Clicks,
				Content = entity.Content
			};
		}
		public static ArticleEntity UpdateDtoToEntity(this ArticleUpdateDto dto, int memberID, DateTime postingDate, int likes, int clicks)
		{
			return new ArticleEntity(dto.Title, memberID, postingDate, likes, clicks, dto.Content)
			{
				ArticleID = dto.ArticleID,
			};
		}
	}
}
