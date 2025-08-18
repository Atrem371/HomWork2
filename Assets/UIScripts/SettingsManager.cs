using UnityEngine;

public class SettingsManager : MonoBehaviour {
    [Header("Panel")]
    [SerializeField] private GameObject settingsPanel;

    
    public void OpenSettings() {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    
    public void CloseSettings() {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    
    public void ToggleSettings() {
        if (settingsPanel != null)
            settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}
