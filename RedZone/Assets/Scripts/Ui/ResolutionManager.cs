using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public Toggle fullscreenToggle;

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int width, int heigth)
    {
        Screen.SetResolution(width, heigth, Screen.fullScreen);
    }

    public void Apply1080p()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }

    public void Apply720p()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen);
    }
}
