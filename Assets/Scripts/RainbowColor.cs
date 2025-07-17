using System.Collections;
using UnityEngine;

public class RainbowColor : MonoBehaviour {
    public Material myMaterial;

    void Start() {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor() {
        while (true) {
            float r = Mathf.Sin(Time.time * 1f) * 0.5f + 0.5f;
            float g = Mathf.Sin(Time.time * 1f + 2f) * 0.5f + 0.5f;
            float b = Mathf.Sin(Time.time * 1f + 4f) * 0.5f + 0.5f;

            Color newColor = new Color(r, g, b);
            myMaterial.color = newColor;

            yield return null;
        }
    }
}

