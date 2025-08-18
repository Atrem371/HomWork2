using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {
    public GameObject gameOverPanel; 
    public TextMeshProUGUI distanceText; 
    public string menuSceneName = "MainMenu"; 

    public void ShowGameOver(float lastDistance) {
        gameOverPanel.SetActive(true);
        distanceText.text = "Distance: " + Mathf.FloorToInt(lastDistance) + " m";
    }

    
    public void Return() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void Menu() {
        SceneManager.LoadScene(menuSceneName);
    }
}

