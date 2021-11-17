using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ehealthcare.Model
{
	
	public class Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
