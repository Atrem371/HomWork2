using UnityEngine;

public class ColorChanger : MonoBehaviour {
    public Material materialToChange;
    private float colorValue = 0f;
    private bool goingUp = true;

    void Update() {
        if (goingUp) {
            colorValue = colorValue + Time.deltaTime;
            if (colorValue > 1f) {
                goingUp = false;
            }
        }
        else {
            colorValue = colorValue - Time.deltaTime;
            if (colorValue < 0f) {
                goingUp = true;
            }
        }

        Color newColor = Color.Lerp(Color.red, Color.blue, colorValue);
        materialToChange.color = newColor;
    }
}