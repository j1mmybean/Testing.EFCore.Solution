using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class CommentSearchDto
	{
		public int ArticleID { get; set; }
		public int ItemNumber { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public string Content { get; set; }
	}
	public static class CommentSearchDtoExtension
	{
		public static CommentSearchDto SearchEntityToDto(this CommentEntity entity)
		{
			return new CommentSearchDto
			{
				ArticleID = entity.ArticleID,
				ItemNumber= entity.ItemNumber,
				MemberID = entity.MemberID,
				PostingDate = entity.PostingDate,
				Likes = entity.Likes,
				Content = entity.Content
			};
		}
		public static IEnumerable<CommentSearchDto> SearchEntitiesToDtos(this IEnumerable<CommentEntity> entities)
		{
			var dtos = new List<CommentSearchDto>();

			foreach (var entity in entities)
			{
				CommentSearchDto dto = entity.SearchEntityToDto();
				dtos.Add(dto);
			}
			return dtos;
		}
	}
}
