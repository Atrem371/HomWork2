using UnityEngine;
using JSAM;

public class MenuMusic : MonoBehaviour {
    void Start() {
        Invoke(nameof(PlayMusicDelayed), 1f);
    }

    void PlayMusicDelayed() {
        
        AudioManager.PlayMusic(MusicAudioLibraryMusic.MenuMusic);
    }
}



