using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordDetailService
	{
		private readonly IKeywordDetailRepository repo;

		public KeywordDetailService(IKeywordDetailRepository repo)
		{
			this.repo = repo;
		}
		public IEnumerable<KeywordDetailSearchDto> Search(int? articleID, int? keywordID)
		{
			IEnumerable<KeywordDetailEntity> entities = repo.Search(articleID, keywordID);

			return entities.SearchEntitiesToDtos();
		}

		public void Create(KeywordDetailCreateDto dto)
		{
			var entity = dto.CreateDtoToEntity();
			repo.Create(entity);
		}

		public void Update(KeywordDetailUpdateDto dto)
		{
			var entity = dto.UpdateDtoToEntity();

			repo.Update(entity);
		}
		//public KeywordDetailUpdateDto GetKeywordDetail(int articleID, int itemNumber)
		//{
		//	var entity = repo.GetKeywordDetail(articleID, itemNumber);
		//	return entity.UpdateEntityToDto();
		//}
	}
}
