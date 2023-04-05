using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.Win
{
	public class ArticleCreateVm
	{
		public int ArticleID { get; set; }

		[Required(ErrorMessage = "必填")]
		public string Title { get; set; }

		[Required(ErrorMessage = "必填")]
		public int? MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public int Clicks { get; set; }

		[Required(ErrorMessage = "必填")]
		public string Content { get; set; }

	}
	public static class ArticleCreateVmExtension
	{
		public static ArticleCreateDto CreateVmToDto(this ArticleCreateVm vm)
		{
			return new ArticleCreateDto()
			{
				Title = vm.Title,
				MemberID = (int)vm.MemberID,
				PostingDate = vm.PostingDate,
				Likes = vm.Likes,
				Clicks = vm.Clicks,
				Content = vm.Content
			};
		}
	}
}
