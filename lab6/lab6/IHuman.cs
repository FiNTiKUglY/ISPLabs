using System;

namespace lab6
{
	public interface IHuman
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public void SmallInfo();
		public void GetInfo();
	}
}
