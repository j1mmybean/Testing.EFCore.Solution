using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class CommentRepository :ICommentRepository
	{
		InseparableEntities inseparableEntities = new InseparableEntities();
		public void Create(CommentEntity entity)
		{

			Comments comment = new Comments();

			comment.ArticleID = entity.ArticleID;
			comment.ItemNumber = inseparableEntities.Comments.Count(c => c.ArticleID == entity.ArticleID)+1;
			comment.MemberID = entity.MemberID;
			comment.CommentPostingDate = entity.PostingDate;
			comment.CommentContent = entity.Content;

			inseparableEntities.Comments.Add(comment);
			inseparableEntities.SaveChanges();
		}

		public void Delete(int articleID, int itemNumber)
		{
			Comments comment = inseparableEntities.Comments.Single(a => a.ArticleID == articleID && a.ItemNumber == itemNumber);

			comment.CommentContent = "留言已刪除";

			inseparableEntities.SaveChanges();
		}

		public void Update(CommentEntity entity)
		{
			Comments comment = inseparableEntities.Comments.Single(a => a.ArticleID == entity.ArticleID && a.ItemNumber == entity.ItemNumber);

			comment.CommentContent = entity.Content;

			inseparableEntities.SaveChanges();
		}

		public IEnumerable<CommentEntity> Search(int? articleID, int? itemNumber, int? memberID)
		{
			//重新實作entityframework不然update時FormComments不會跟新?????
			InseparableEntities inseparable = new InseparableEntities();

			IEnumerable<Comments> comments = inseparable.Comments;

			if (articleID.HasValue)	comments = comments.Where(a => a.ArticleID == articleID);
			if (itemNumber.HasValue) comments = comments.Where(a => a.ItemNumber == itemNumber);
			if (memberID.HasValue) comments = comments.Where(a => a.MemberID == memberID);

			return comments.ModelsToEntities();
		}

		public CommentEntity GetComment(int articleID, int itemNumber)
		{
			Comments comment = inseparableEntities.Comments.Single(a => a.ArticleID == articleID && a.ItemNumber == itemNumber);
			CommentEntity entity = new CommentEntity(articleID, itemNumber, comment.MemberID, comment.CommentPostingDate, comment.CommentLikes, comment.CommentContent);
			return entity;
		}
	}
}
