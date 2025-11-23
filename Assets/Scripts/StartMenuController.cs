using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour {
    
    public string gameSceneName = "1";

    public void StartGame() {
        SceneManager.LoadScene(gameSceneName);
    }
}

