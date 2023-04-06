namespace Testing.EFCore.MVC.Models
{
	public class JsonData
	{
		public bool adult { get; set; }
		public string backdrop_path { get; set; }
		public DateTime release_date { get; set; }
		public string poster_path { get; set; }
		public string title { get; set; }
		public string overview { get; set; }
		public string original_title { get; set; }
		public string original_language { get; set; }

		public bool video { get; set; }
		public double vote_average { get; set; }
		public int vote_count { get; set; }
		public int popularity { get; set; }
		public int id { get; set; }
		public int[] genre_ids { get; set; }
	}
	//{"adult":false,
	//"backdrop_path":"/ovM06PdF3M8wvKb06i4sjW3xoww.jpg",
	//"genre_ids":[878,12,28],
	//"id":76600,
	//"original_language":"en",
	//"original_title":"Avatar: The Way of Water",
	//"overview":"設於首集超過十年後，成為納美人並與奈蒂莉共結連理的傑克，在潘朵拉星上與他們的孩子組成蘇里一家，過著與世無爭的幸福生活，未料威脅再度降臨，他們不遺餘力保護彼此，為了生存再度奮戰，還得承受隨之而來的悲痛創傷。",
	//"popularity":7408.418,
	//"poster_path":"/zdXdYiIgDbhP5oNYLh0VI6qbgpj.jpg",
	//"release_date":"2022-12-14",
	//"title":"阿凡達：水之道",
	//"video":false,
	//"vote_average":7.8,
	//"vote_count":6586}
}
