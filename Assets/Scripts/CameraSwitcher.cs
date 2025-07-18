using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour {
    public CinemachineVirtualCamera[] cameras;
    public int currentCameraIndex = 0;

    void Start() {
        TurnOnCamera(currentCameraIndex);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            currentCameraIndex = currentCameraIndex + 1;

            if (currentCameraIndex >= cameras.Length) {
                currentCameraIndex = 0;
            }

            TurnOnCamera(currentCameraIndex);
        }
    }

    void TurnOnCamera(int index) {
        for (int i = 0; i < cameras.Length; i++) {
            if (i == index) {
                cameras[i].Priority = 10;
            }
            else {
                cameras[i].Priority = 0;
            }
        }
    }
}

