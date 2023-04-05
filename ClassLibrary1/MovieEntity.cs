using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL
{
	public class MovieEntity
	{
		public int MovieID { get; set; }
		public string Name { get; set; }
		public string Introduction { get; set; }
		public int LevelID { get; set; }
		public DateTime OnDate { get; set; }
		public DateTime OffDate { get; set; }
		public int Length { get; set; }
		public string ImagePath { get; set; }
		public byte[] ImageByte { get; set; }
		public MovieEntity(string name, string introduction, int levelID, DateTime onDate, DateTime offDate, int length, string imagePath)
		{
			Name = name;
			Introduction = introduction;
			LevelID = levelID;
			OnDate = onDate;
			OffDate = offDate;
			Length = length;
			ImagePath = imagePath;

		}
	}

}
