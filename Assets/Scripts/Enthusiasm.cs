using UnityEngine;
using System.Collections;

public class Enthusiasm : MonoBehaviour {
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    private AudioSource audioSource;
    private int playCount = 0;
    private Coroutine soundCoroutine;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (soundCoroutine == null)
                soundCoroutine = StartCoroutine(PlaySounds());
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (soundCoroutine != null) {
                StopCoroutine(soundCoroutine);
                soundCoroutine = null;
                audioSource.Stop();
                playCount = 0;  
            }
        }
    }

    IEnumerator PlaySounds() {
        while (true) {
            playCount++;

            AudioClip clipToPlay;

            if (playCount % 3 == 1)
                clipToPlay = sound1;
            else if (playCount % 3 == 2)
                clipToPlay = sound2;
            else
                clipToPlay = sound3;

            if (clipToPlay != null) {
                audioSource.clip = clipToPlay;
                audioSource.Play();
                Debug.Log("Playing sound #" + playCount);
            }

            yield return new WaitForSeconds(clipToPlay.length + 0.2f);
        }
    }
}








