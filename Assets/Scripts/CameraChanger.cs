using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Camera focusCamera;

    [SerializeField]
    private Image backToMainCamera;

    [SerializeField]
    private Canvas mainCanvas;

    [SerializeField]
    private Canvas focusCanvas;

    public void SwitchViews()
    {
        ChangeCameras();
        SwitchCanvas();
        ToggleBackToMainCamera();
    }

    public void ToggleBackToMainCamera()
    {
        backToMainCamera.gameObject.SetActive(!backToMainCamera.gameObject.activeSelf);
    }

    public void ChangeCameras()
    {
        mainCamera.gameObject.SetActive(!mainCamera.isActiveAndEnabled);
        focusCamera.gameObject.SetActive(!focusCamera.isActiveAndEnabled);
    }

    public void SwitchCanvas()
    {
        if (focusCanvas != null)
        {
            mainCanvas.gameObject.SetActive(!mainCanvas.gameObject.activeSelf);
            focusCanvas.gameObject.SetActive(!focusCanvas.gameObject.activeSelf);
        }
    }

    public void TurnOffFocusCanvas()
    {
        focusCanvas.gameObject.SetActive(false);
        focusCamera.transform.localPosition = new Vector3(-2.07f, 1.08f, -1.02f);
    }
}
