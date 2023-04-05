using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class CommentEntity
	{
		public int ArticleID { get; set; }
		public int ItemNumber { get; set; }
		public int MemberID { get; set; }
		public DateTime PostingDate { get; set; }
		public int Likes { get; set; }
		public string Content { get; set; }
		public CommentEntity(int articleID, int itemNumber, int memberID, DateTime postingDate, int likes, string content)
		{
			ArticleID = articleID;
			ItemNumber = itemNumber;
			MemberID = memberID;
			PostingDate = postingDate;
			Likes = likes;
			Content = content;
		}
	}

}
