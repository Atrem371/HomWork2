using UnityEngine;

public class HighScoreManager : MonoBehaviour {
    public static HighScoreManager Instance { get; private set; }
    public int HighScore { get; private set; }
    public float LastDistance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    public void SetHighScore(int score, float lastDistance) {
        if (score > HighScore)
            HighScore = score;

        LastDistance = lastDistance;

        SaveData();
    }

    private void SaveData() {
        GameSaver.Save(HighScore, LastDistance);
    }

    private void LoadData() {
        var data = GameSaver.Load();
        HighScore = data.highScore;
        LastDistance = data.lastDistance;
    }
}





