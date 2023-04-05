using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class ArticleEntity
	{
		public int ArticleID { get; set; }
		public string Title { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public int Clicks { get; set; }
		public string Content { get; set; }
		public ArticleEntity(string title, int memberID, DateTime postingDate, int likes, int clicks, string content)
		{
			Title = title;
			MemberID = memberID;
			PostingDate = postingDate;
			Likes = likes;
			Clicks = clicks;
			Content = content;
		}
	}
}
