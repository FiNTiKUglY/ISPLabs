using System;
using System.Collections.Generic;

namespace lab6
{
	public class AthleteComparer: IComparer<Athlete>
	{
		public int Compare(Athlete first, Athlete second)
		{
			if (first.GetSpeciality()[0] > second.GetSpeciality()[0]) return 1;
			else if (first.GetSpeciality()[0] == second.GetSpeciality()[0]) return 0;
			else return -1;
		}
	}
}
