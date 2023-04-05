using ISpan.Inseparable.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public static class CommentExtension
	{
		public static CommentEntity ModelToEntity(this Comments comment)
		{
			return new CommentEntity(comment.ArticleID, comment.ItemNumber, comment.MemberID, comment.CommentPostingDate, comment.CommentLikes,  comment.CommentContent);
		}
		public static IEnumerable<CommentEntity> ModelsToEntities(this IEnumerable<Comments> comments)
		{
			var entities = new List<CommentEntity>();

			foreach (var comment in comments)
			{
				CommentEntity entity = comment.ModelToEntity();
				entities.Add(entity);
			}
			return entities;
		}
	}
}
