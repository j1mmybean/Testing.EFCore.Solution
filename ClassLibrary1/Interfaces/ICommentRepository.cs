using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public interface ICommentRepository
	{
		void Create(CommentEntity entity);

		void Delete(int articleID, int itemNumber);

		void Update(CommentEntity entity);

		IEnumerable<CommentEntity> Search(int? articleID, int? itemNumber, int? memberID);

		CommentEntity GetComment(int articleID, int itemNumber);

	}
}
