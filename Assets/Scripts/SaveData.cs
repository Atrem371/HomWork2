using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public int highScore;
    public float lastDistance;
}

public static class GameSaver {
    private static string savePath = Path.Combine(Application.persistentDataPath, "savefile.json");

    public static void Save(int highScore, float lastDistance) {
        SaveData data = new SaveData { highScore = highScore, lastDistance = lastDistance };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public static SaveData Load() {
        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return new SaveData { highScore = 0, lastDistance = 0f };
    }
}
