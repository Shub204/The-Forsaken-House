using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public float x, y, z; // Player position
    public int health;
    public bool firstDoorKey;
    public bool halfEye1;
    public bool halfEye2;
    public bool hasTorch;
}

public static class SaveSystem
{
    private static string saveFilePath = Application.persistentDataPath + "/savegame.json";
    public static void DeleteCheckpoint()
    {
        if (File.Exists(Application.persistentDataPath + "/savegame.json"))
        {
            File.Delete(Application.persistentDataPath + "/savegame.json");
            Debug.Log("Checkpoint Deleted! Game will always start fresh.");
        }
    }


    public static void SaveCheckpoint(Vector3 position)
    {
        PlayerData data = new PlayerData
        {
            x = position.x,
            y = position.y,
            z = position.z,
            health = GlobalHealth.currentHealth,  // Save health from GlobalHealth
            halfEye1 = GlobalInventory.halfEye1,
            halfEye2 = GlobalInventory.halfEye2,
            hasTorch = GlobalInventory.hasTorch
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved at: " + saveFilePath);
    }

    public static PlayerData LoadCheckpoint()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        else
        {
            Debug.LogWarning("No save file found! Returning default values.");
            return new PlayerData
            {
                x = 0,
                y = 1,
                z = 0,
                health = 20, // Default health 
                firstDoorKey = false,
                halfEye1 = false,
                halfEye2 = false,
                hasTorch = false
            };
        }
    }
}
