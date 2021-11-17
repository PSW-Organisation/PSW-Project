using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ehealthcare.Model
{
	[Serializable]
	public class Entity
	{
		private int id;

		public Entity(int id)
		{
			this.id = id;
		}

		public int Id 
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}
		
	}
}
