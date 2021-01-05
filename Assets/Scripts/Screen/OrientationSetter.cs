using UnityEngine;
using UnityEngine.UI;

public class OrientationSetter : MonoBehaviour
{
    public CanvasScaler canvasScaler;

    private void Start()
    {
        if (Screen.width > 1440)
        {
            canvasScaler.matchWidthOrHeight = 0.6f;

            Screen.orientation = UnityEngine.ScreenOrientation.Landscape;
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

            Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
            Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
        }
        else
        {
            canvasScaler.matchWidthOrHeight = 0f;

            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

            Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
        }
        Destroy(gameObject);
    }
}