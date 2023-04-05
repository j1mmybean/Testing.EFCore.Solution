using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class ArticleService
	{
		private readonly IArticleRepository repo;

		public ArticleService(IArticleRepository repo)
		{
			this.repo = repo;
		}
		public IEnumerable<ArticleSearchDto> Search(int? articleID, string title, int? memberID, int? keywordID)
		{
			IEnumerable<ArticleEntity> entities = repo.Search(articleID , title, memberID, keywordID);

			return entities.SearchEntitiesToDtos();
		}

		public void Create(ArticleCreateDto dto)
		{
			var entity = dto.CreateDtoToEntity();

			if (string.IsNullOrEmpty(entity.Title) || string.IsNullOrEmpty(entity.Content)) throw new Exception("請正確填寫標題及內容");

			// 驗證Title 是否唯一
			var entityInDbByTitle = repo.GetByTitle(entity.Title);
			if (entityInDbByTitle != null) throw new Exception("此標題已被使用");

			repo.Create(entity);
		}

		public void Update(ArticleUpdateDto dto)
		{
			var currentArticle = repo.GetByArticleID(dto.ArticleID);

			var updateEntity = dto.UpdateDtoToEntity(currentArticle.MemberID, currentArticle.PostingDate, currentArticle.Likes, currentArticle.Clicks);

			if (string.IsNullOrEmpty(updateEntity.Title) || string.IsNullOrEmpty(updateEntity.Content)) throw new Exception("請正確填寫標題及內容");

			// 驗證Title 是否唯一
			var entityInDb = repo.GetByTitle(updateEntity.Title);
			if (entityInDb != null && entityInDb.ArticleID != updateEntity.ArticleID) throw new Exception("此標題已被使用");

			repo.Update(updateEntity);
		}
		public ArticleUpdateDto GetByArticleID(int ArticleID)
		{
			var entity = repo.GetByArticleID(ArticleID);
			return entity.UpdateEntityToDto();
		}
		public ArticleUpdateDto GetByTitle(string title)
		{
			var entity = repo.GetByTitle(title);
			return entity.UpdateEntityToDto();
		}
	}
}
