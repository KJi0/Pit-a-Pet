using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoadManager
{
    public static void SaveGame(Pet pet)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/pet.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PetData data = new PetData(pet);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Pet LoadGame()
    {
        string path = Application.persistentDataPath + "/pet.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PetData data = formatter.Deserialize(stream) as PetData;
            stream.Close();

            return new Pet(data);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
