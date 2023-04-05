using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISpan.Inseparable.BLL
{
	public class KeywordService
	{
		private readonly IKeywordRepository repo;

		public KeywordService(IKeywordRepository repo)
		{
			this.repo = repo;
		}
		public IEnumerable<KeywordSearchDto> Search(int? keywordID, string name)
		{
			IEnumerable<KeywordEntity> entities = repo.Search(keywordID, name);

			return entities.SearchEntitiesToDtos();
		}

		public void Create(KeywordCreateDto dto)
		{
			var entity = dto.CreateDtoToEntity();

			if (string.IsNullOrEmpty(entity.Name)) throw new Exception("請正確填寫類別名稱");

			// 驗證KeywordName 是否唯一
			var entityInDb = repo.GetByKeywordName(entity.Name);
			if (entityInDb != null) throw new Exception("類別已存在");

			repo.Create(entity);
		}

		public void Update(KeywordUpdateDto dto)
		{
			var updateEntity = dto.UpdateDtoToEntity();

			if (string.IsNullOrEmpty(updateEntity.Name)) throw new Exception("請正確填寫類別名稱");

			// 驗證KeywordName 是否唯一
			var entityInDb = repo.GetByKeywordName(updateEntity.Name);
			if (entityInDb != null && entityInDb.KeywordID != updateEntity.KeywordID) throw new Exception("存在同名之類別");

			repo.Update(updateEntity);
		}
		public KeywordUpdateDto GetKeyword(int KeywordID)
		{
			var entity = repo.GetKeyword(KeywordID);
			return entity.UpdateEntityToDto();
		}

		public IEnumerable<KeywordSearchDto> GetByArticleID(int articleID)
		{
			IEnumerable<KeywordEntity> entities = repo.GetByArticleID(articleID);

			return entities.SearchEntitiesToDtos();
		}
		public IEnumerable<KeywordSearchDto> GetKeywordsLeave(int articleID)
		{
			IEnumerable<KeywordEntity> entitiesLeave = repo.GetKeywordsLeave(articleID);

			return entitiesLeave.SearchEntitiesToDtos();
		}
	}
}
