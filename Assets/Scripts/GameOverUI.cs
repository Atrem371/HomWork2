using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverUI : MonoBehaviour {
    public GameObject gameOverPanel;
    public TextMeshProUGUI distanceText;
    public string menuSceneName = "StarMenu";
    public float fadeDuration = 0.5f;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Awake() {
        if (gameOverPanel == null)
            return;

        canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameOverPanel.AddComponent<CanvasGroup>();

        rectTransform = gameOverPanel.GetComponent<RectTransform>();
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        rectTransform.localScale = Vector3.zero;
        gameOverPanel.SetActive(true);
    }

    public void ShowGameOver(float lastDistance) {
        if (distanceText != null)
            distanceText.text = "Distance: " + Mathf.FloorToInt(lastDistance) + " m";

        StopAllCoroutines();
        StartCoroutine(FadeInPanel());
    }

    public void HideGameOver() {
        StopAllCoroutines();
        StartCoroutine(FadeOutPanel());
    }

    private IEnumerator FadeInPanel() {
        float elapsed = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        while (elapsed < fadeDuration) {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);
            canvasGroup.alpha = t;
            rectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        rectTransform.localScale = Vector3.one;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private IEnumerator FadeOutPanel() {
        float elapsed = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        while (elapsed < fadeDuration) {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);
            canvasGroup.alpha = 1f - t;
            rectTransform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        rectTransform.localScale = Vector3.zero;
    }

    public void Return() {
        HideGameOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        HideGameOver();
        SceneManager.LoadScene(menuSceneName);
    }
}













