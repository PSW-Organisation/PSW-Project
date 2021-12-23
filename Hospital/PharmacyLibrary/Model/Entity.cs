using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyLibrary.Model
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
