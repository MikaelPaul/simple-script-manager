using System;
using System.Collections.Generic;
using System.Text;

namespace SSM.Model
{
	public class TagModel : IComparable
	{
		public string TagName { get; set; }

		public int CompareTo(object o) => string.Compare(this.TagName, ((TagModel)o).TagName, true);

	}
}
