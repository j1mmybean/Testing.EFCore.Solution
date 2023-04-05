﻿using ISpan.Inseparable.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.BLL.Dtos
{
	public class CinemaCreateDto
	{
		public int CinemaID { get; set; }
		public string CinemaName { get; set; }
		public string CinemaRegion { get; set; }
		public string CinemaAddress { get; set; }
		public string CinemaTel { get; set; }
	}

	public static class CinemaCreateDtoExtension
	{
		public static CinemaEntity ToEntity(this CinemaCreateDto dto)
		{
			return new CinemaEntity(dto.CinemaName, dto.CinemaRegion, dto.CinemaAddress, dto.CinemaTel);
		}
	}
}
