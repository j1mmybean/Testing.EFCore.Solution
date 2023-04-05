using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class CommentService
	{
		private readonly ICommentRepository repo;
		private readonly IArticleRepository articleRepos;

		public CommentService(ICommentRepository repo, IArticleRepository articleRepos)
		{
			this.repo = repo;
			this.articleRepos = articleRepos;
		}
		public IEnumerable<CommentSearchDto> Search(int? articleID, int? itemNumber, int? memberID)
		{
			IEnumerable<CommentEntity> entities = repo.Search(articleID, itemNumber, memberID);

			return entities.SearchEntitiesToDtos();
		}

		public void Create(CommentCreateDto dto)
		{
			var entity = dto.CreateDtoToEntity();

			if (string.IsNullOrEmpty(entity.Content)) throw new Exception("請正確填寫留言內容");

			// 驗證是否存在此文章
			var entityInDb = articleRepos.GetByArticleID(entity.ArticleID);
			if (entityInDb == null) throw new Exception("無此文章");

			repo.Create(entity);
		}

		public void Update(CommentUpdateDto dto)
		{
			var currentComment = repo.GetComment(dto.ArticleID, dto.ItemNumber);

			if (string.IsNullOrEmpty(currentComment.Content)) throw new Exception("請正確填寫留言內容");

			var updateEntity = dto.UpdateDtoToEntity(currentComment.MemberID, currentComment.PostingDate, currentComment.Likes);

			repo.Update(updateEntity);
		}
		public CommentUpdateDto GetComment(int articleID, int itemNumber)
		{
			var entity = repo.GetComment(articleID, itemNumber);
			return entity.UpdateEntityToDto();
		}
	}
}
