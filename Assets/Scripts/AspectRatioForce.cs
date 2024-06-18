using UnityEngine;

public class ForceAspectRatio : MonoBehaviour
{
    // Desired aspect ratio (16:9)
    public float targetAspect = 16f / 9f;

    void Start()
    {
        // Calculate the aspect ratio of the screen
        float currentAspect = (float)Screen.width / Screen.height;

        // If the current aspect ratio is different from the target aspect ratio
        if (currentAspect != targetAspect)
        {
            // Calculate the desired width to maintain the target aspect ratio
            float desiredWidth = Screen.height * targetAspect;

            // Set the screen resolution with the desired width and the screen's height
            Screen.SetResolution((int)desiredWidth, Screen.height, false);
        }
    }
}

