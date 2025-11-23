using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JSAM;

public class SoundManager : MonoBehaviour {
    [Header("Slider")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    [Header("Buttons")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainMenuButton;

    private const string MUSIC_VOLUME_KEY = "JSAM_MusicVolume";

    private void Start() {
        LoadVolumeSettings();

        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        if (effectsSlider != null)
            effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    private void SetMusicVolume(float volume) {
        AudioManager.MusicVolume = volume;
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
    }

    private void SetEffectsVolume(float volume) {
        AudioManager.SoundVolume = volume;
    }

    private void LoadVolumeSettings() {
        if (PlayerPrefs.HasKey(MUSIC_VOLUME_KEY)) {
            float savedMusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
            if (musicSlider != null)
                musicSlider.value = savedMusicVolume;
            AudioManager.MusicVolume = savedMusicVolume;
        }
        else {
            if (musicSlider != null)
                musicSlider.value = 0.5f;
        }

        if (effectsSlider != null)
            effectsSlider.value = 0.5f;
        AudioManager.SoundVolume = 0.5f;
    }

    public void OpenSettings() {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);

        if (musicSlider != null)
            EventSystem.current.SetSelectedGameObject(musicSlider.gameObject);
    }

    public void CloseSettings() {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (mainMenuButton != null)
            EventSystem.current.SetSelectedGameObject(mainMenuButton);

        PlayerPrefs.Save();
    }
}
