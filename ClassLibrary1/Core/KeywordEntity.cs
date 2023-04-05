using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class KeywordEntity
	{
		public int KeywordID { get; set; }
		public string Name { get; set; }
		public KeywordEntity(string name)
		{
			Name = name;
		}
	}
}
