using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieService
	{
		private readonly IMovieRepository repo;

		public MovieService(IMovieRepository repo)
		{
			this.repo = repo;
		}
		public IEnumerable<MovieSearchDto> Search(int? movieID, string Name, int? levelID, DateTime onDate, DateTime offDate)
		{
			IEnumerable<MovieEntity> entities = repo.Search(movieID, Name, levelID, onDate, offDate);

			return entities.SearchEntitiesToDtos();
		}

		public void Create(MovieCreateDto dto)
		{
			var entity = dto.CreateDtoToEntity();

			if (string.IsNullOrEmpty(entity.Name)) throw new Exception("請正確填寫電影名稱");

			repo.Create(entity);
		}

		public void Update(MovieUpdateDto dto)
		{
			var currentMovie = repo.GetByMovieID(dto.MovieID);

			if (string.IsNullOrEmpty(currentMovie.Name)) throw new Exception("請正確填寫電影名稱");

			var updateEntity = dto.UpdateDtoToEntity();

			repo.Update(updateEntity);
		}
		public MovieUpdateDto GetByMovieID(int movieID)
		{
			var entity = repo.GetByMovieID(movieID);
			return entity.UpdateEntityToDto();
		}
	}
}
