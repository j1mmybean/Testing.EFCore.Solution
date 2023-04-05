using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.Win
{
	public class ArticleUpdateVm
	{
		public int ArticleID { get; set; }

		[Required(ErrorMessage = "必填")]
		public string Title { get; set; }

		[Required(ErrorMessage = "必填")]
		public string Content { get; set; }
	}
	public static class ArticleUpdateVmExtension
	{
		public static ArticleUpdateDto UpdateVmToDto(this ArticleUpdateVm vm)
		{
			return new ArticleUpdateDto()
			{
				ArticleID = vm.ArticleID,
				Title = vm.Title,
				Content = vm.Content,
			};
		}
	}
}
