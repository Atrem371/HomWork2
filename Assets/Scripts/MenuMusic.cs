using UnityEngine;
using JSAM;
using System.Collections;

public class MenuMusic : MonoBehaviour {
    void Start() {
        StartCoroutine(PlayMusicDelayed());
    }

    private IEnumerator PlayMusicDelayed() {
        
        yield return null;

        
        AudioManager.PlayMusic(MusicAudioLibraryMusic.MenuMusic);
    }
}





