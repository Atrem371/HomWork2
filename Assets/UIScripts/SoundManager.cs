using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 
using JSAM;

public class SoundManager : MonoBehaviour {
    [Header("Слайдери")]
    public Slider musicSlider;
    public Slider effectsSlider;

    [Header("Кнопки")]
    public GameObject settingsPanel; 
    public GameObject mainMenuButton; 

    private void Start() {
        LoadVolumeSettings();

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    public void SetMusicVolume(float volume) {
        AudioManager.MusicVolume = volume;
        PlayerPrefs.SetFloat("JSAM_MusicVolume", volume);
    }

    public void SetEffectsVolume(float volume) {
        AudioManager.SoundVolume = volume;
        PlayerPrefs.SetFloat("JSAM_EffectsVolume", volume);
    }

    private void LoadVolumeSettings() {
        if (PlayerPrefs.HasKey("JSAM_MusicVolume")) {
            float savedMusicVolume = PlayerPrefs.GetFloat("JSAM_MusicVolume");
            musicSlider.value = savedMusicVolume;
            AudioManager.MusicVolume = savedMusicVolume;
        }
        else {
            musicSlider.value = 0.5f;
        }

        if (PlayerPrefs.HasKey("JSAM_EffectsVolume")) {
            float savedEffectsVolume = PlayerPrefs.GetFloat("JSAM_EffectsVolume");
            effectsSlider.value = savedEffectsVolume;
            AudioManager.SoundVolume = savedEffectsVolume;
        }
        else {
            effectsSlider.value = 0.5f;
        }
    }

    
    public void OpenSettings() {
        settingsPanel.SetActive(true);

        
        if (musicSlider != null) {
            EventSystem.current.SetSelectedGameObject(musicSlider.gameObject);
        }
    }

    
    public void CloseSettings() {
        settingsPanel.SetActive(false);

        
        if (mainMenuButton != null) {
            EventSystem.current.SetSelectedGameObject(mainMenuButton);
        }

        
        PlayerPrefs.Save();
    }
}