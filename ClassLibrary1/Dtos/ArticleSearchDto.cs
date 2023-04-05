using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class ArticleSearchDto
	{
		public int ArticleID { get; set; }
		public string Title { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public int Clicks { get; set; }
		public string Content { get; set; }
	}
	public static class ArticleSearchDtoExtension
	{
		public static ArticleSearchDto SearchEntityToDto(this ArticleEntity entity)
		{
			return new ArticleSearchDto
			{
				ArticleID = entity.ArticleID,
				Title = entity.Title,
				MemberID = entity.MemberID,
				PostingDate = entity.PostingDate,
				Likes= entity.Likes,
				Clicks = entity.Clicks,
				Content = entity.Content
			};
		}
		public static IEnumerable<ArticleSearchDto> SearchEntitiesToDtos(this IEnumerable<ArticleEntity> entities)
		{
			var dtos = new List<ArticleSearchDto>();

			foreach (var entity in entities)
			{
				ArticleSearchDto dto = entity.SearchEntityToDto();
				dtos.Add(dto);
			}
			return dtos;
		}

	}

}
