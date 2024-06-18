using UnityEngine;

public class AspectRatioEnforcer : MonoBehaviour
{
    private Camera cam;

    // Set the desired aspect ratio (16:9)
    private float targetAspect = 16f / 9f;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Ensure the camera is using orthographic projection
        cam.orthographic = true;

        UpdateCameraSize();
    }

    void Update()
    {
        // Check if the current aspect ratio is different from the target aspect ratio
        if (!Mathf.Approximately(GetCurrentAspect(), targetAspect))
        {
            UpdateCameraSize();
        }
    }

    float GetCurrentAspect()
    {
        return (float)Screen.width / Screen.height;
    }

    void UpdateCameraSize()
    {
        // Calculate the desired height of the camera's view
        float desiredHeight = cam.orthographicSize * 2;

        // Calculate the desired width based on the target aspect ratio
        float desiredWidth = targetAspect * desiredHeight;

        // Adjust the camera's size to fit the desired width while maintaining the aspect ratio
        cam.orthographicSize = desiredWidth / (2 * cam.aspect);
    }
}
