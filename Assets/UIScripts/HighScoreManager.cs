using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public int highScore;
    public float lastDistance;
}

public class HighScoreManager : MonoBehaviour {
    public static HighScoreManager Instance { get; private set; }

    public int HighScore { get; private set; }
    public float LastDistance { get; private set; }

    private string savePath;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        LoadData();
    }

    public void SetHighScore(int score, float lastDistance) {
        Debug.Log($"SetHighScore called with score: {score}, lastDistance: {lastDistance}");

        if (score > HighScore) {
            HighScore = score;
            Debug.Log($"New HighScore set: {HighScore}");
        }

        LastDistance = lastDistance;
        Debug.Log($"LastDistance updated: {LastDistance}");

        SaveDataToFile();
    }

    private void SaveDataToFile() {
        SaveData data = new SaveData {
            highScore = HighScore,
            lastDistance = LastDistance
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log($"Data saved to {savePath}: {json}");
    }

    private void LoadData() {
        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScore = data.highScore;
            LastDistance = data.lastDistance;

            Debug.Log($"Data loaded from {savePath}: {json}");
        }
        else {
            Debug.Log("No save file found. Starting with default values.");
        }
    }
}




