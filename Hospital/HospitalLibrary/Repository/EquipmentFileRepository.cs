using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
    public class EquipmentFileRepository:IEquipmentRepository

    {
    public String FileName { get; set; }

    public EquipmentFileRepository()
    {
        this.FileName = "../../oprema.json";
    }

    public List<Equipment> GetAll()
    {
        List<Equipment> equipmentList = new List<Equipment>();
        List<Equipment> storedEquipment = ReadFromFile();
        for (int i = 0; i < storedEquipment.Count; i++)
        {
            if (storedEquipment[i].IsDeleted == false)
            {
                equipmentList.Add(storedEquipment[i]);
            }
        }

        return equipmentList;
    }

    public Boolean Save(Equipment newEquipment)
    {
        newEquipment.Id = GenerateNextId();
        List<Equipment> storedEquipment = ReadFromFile();
        for (int i = 0; i < storedEquipment.Count; i++)
        {
            if (storedEquipment[i].Id.Equals(newEquipment.Id))
                return false;
        }

        storedEquipment.Add(newEquipment);
        WriteToFile(storedEquipment);
        return true;
    }

    public Boolean Update(Equipment editedEquipment)
    {
        List<Equipment> storedEquipment = ReadFromFile();
        foreach (Equipment equipment in storedEquipment)
        {
            if (equipment.Id.Equals(editedEquipment.Id) && equipment.IsDeleted == false)
            {
                equipment.Name = editedEquipment.Name;
                equipment.Type = editedEquipment.Type;
                WriteToFile(storedEquipment);
                return true;
            }
        }

        return false;
    }

    public Equipment GetOne(int id)
    {
        List<Equipment> equipmentList = GetAll();
        for (int i = 0; i < equipmentList.Count; i++)
        {
            if (equipmentList[i].Id.Equals(id))
            {
                return equipmentList[i];
            }
        }

        return null;
    }

    public Boolean Delete(int id)
    {
        List<Equipment> storedEquipment = ReadFromFile();
        for (int i = 0; i < storedEquipment.Count; i++)
        {
            if (storedEquipment[i].Id == id && storedEquipment[i].IsDeleted == false)
            {
                storedEquipment[i].IsDeleted = true;
                WriteToFile(storedEquipment);
                return true;
            }
        }

        return false;
    }

    private List<Equipment> ReadFromFile()
    {
        try
        {
            String jsonFromFile = File.ReadAllText(this.FileName);
            List<Equipment> equipmentList = JsonConvert.DeserializeObject<List<Equipment>>(jsonFromFile);
            return equipmentList;
        }
        catch
        {
        }

        MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
        return new List<Equipment>();
    }

    private void WriteToFile(List<Equipment> equipmentList)
    {
        try
        {
            var jsonToFile = JsonConvert.SerializeObject(equipmentList, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(this.FileName))
            {
                writer.Write(jsonToFile);
            }
        }
        catch
        {
            MessageBox.Show("Neuspesno pisanje u fajl" + this.FileName + "!");
        }
    }

    private int GenerateNextId()
    {
        List<Equipment> list = ReadFromFile();
        return list.Count;
    }
    }
}