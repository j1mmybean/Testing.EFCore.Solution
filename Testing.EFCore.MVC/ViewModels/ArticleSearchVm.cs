using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.Win
{
	public class ArticleSearchVm
	{
		public int 文章ID { get; set; }
		public string 標題 { get; set; }
		public int 會員ID { get; set; }
		public DateTime 發文時間 { get; set; }
		public int 點讚數 { get; set; }
		public int 點擊數 { get; set; }
		public string 文章內容 { get; set; }
	}
	public static class ArticleSearchVmExtension
	{
		public static ArticleSearchVm SearchDtoToVm(this ArticleSearchDto dto)
		{
			return new ArticleSearchVm()
			{
				文章ID = dto.ArticleID,
				標題 = dto.Title,
				會員ID = dto.MemberID,
				發文時間 = dto.PostingDate,
				點讚數 = dto.Likes,
				點擊數 = dto.Clicks,
				文章內容 = dto.Content
			};
		}
		public static IEnumerable<ArticleSearchVm> SearchDtosToVms(this IEnumerable<ArticleSearchDto> dtos)
		{
			List<ArticleSearchVm> Vms = new List<ArticleSearchVm>();

			foreach (var dto in dtos)
			{
				Vms.Add(dto.SearchDtoToVm());
			}
			return Vms;
		}
	}

}
