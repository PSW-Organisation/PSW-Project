using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository
{
	class MedicineIngredientRepository
	{
		private List<MedicineIngredient> medicineIngredients;
		public MedicineIngredientRepository()
		{
			DataIO dataIO = new DataIO();
			medicineIngredients = dataIO.DeSerializeObject<List<MedicineIngredient>>("medicineIngredients.xml");
			if (medicineIngredients == null)
			{
				medicineIngredients = new List<MedicineIngredient>();
			}
		}

		public List<MedicineIngredient> GetAllMedicineIngredients()
		{
			return medicineIngredients;
		}

		public void SaveAllMedicineIngredients(List<MedicineIngredient> MedicineIngredients)
		{
			DataIO dataIO = new DataIO();
			dataIO.SerializeObject(MedicineIngredients, "medicineIngredients.xml");
		}

		public void SaveAllMedicineIngredients()
		{
			DataIO dataIO = new DataIO();
			dataIO.SerializeObject(medicineIngredients, "medicineIngredients.xml");
		}

		public MedicineIngredient GetMedicineIngredientById(string id)
		{
			foreach (MedicineIngredient MedicineIngredient in medicineIngredients)
			{
				if (MedicineIngredient.Name == id)
				{
					return MedicineIngredient;
				}
			}
			return null;

		}
		public void NewMedicineIngredient(MedicineIngredient MedicineIngredient)
		{
			medicineIngredients.Add(MedicineIngredient);
			SaveAllMedicineIngredients(medicineIngredients);
		}
		public void SetMedicineIngredient(MedicineIngredient MedicineIngredient)
		{
			for (int i = medicineIngredients.Count - 1; i >= 0; i--)
			{
				if (medicineIngredients[i].Name == MedicineIngredient.Name)
				{
					medicineIngredients.RemoveAt(i);
					medicineIngredients.Insert(i, MedicineIngredient);
					break;
				}
			}
			SaveAllMedicineIngredients();
		}
		public void DeleteMedicineIngredient(MedicineIngredient targetMedicineIngredient)
		{
			foreach (MedicineIngredient MedicineIngredient in medicineIngredients.ToList())
			{
				if (MedicineIngredient.Name == targetMedicineIngredient.Name)
				{
					medicineIngredients.Remove(MedicineIngredient);
					SaveAllMedicineIngredients();
				}
			}
		}
	}
}