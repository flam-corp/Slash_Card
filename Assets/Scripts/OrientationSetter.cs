using UnityEngine;

public class OrientationSetter : MonoBehaviour
{
    private void Start()
    {
        if (Screen.width > 1440)
        {
            Screen.orientation = UnityEngine.ScreenOrientation.Landscape;
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

            Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
            Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
        }
        else
        {
            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

            Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
        }
        Destroy(gameObject);
    }
}