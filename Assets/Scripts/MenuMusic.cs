using UnityEngine;
using JSAM;
using System.Collections;

public class MenuMusic : MonoBehaviour {
    void Awake() {
        
        StartCoroutine(PlayMusicWithDelay());
    }

    private IEnumerator PlayMusicWithDelay() {
        
        yield return new WaitForSeconds(0.1f);

        
        AudioManager.PlayMusic(MusicAudioLibraryMusic.MenuMusic);
    }
}







