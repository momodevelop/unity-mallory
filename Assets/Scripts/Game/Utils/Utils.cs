using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static float GetPixelPerUnit()
    {
        return 100.0f;
    }

    public static float GetCameraWidth()
    {
        return GetAspectRatio() * GetCameraHeight();
    }

    public static float GetCameraWidthPixels()
    {
        return GetCameraWidth() * GetPixelPerUnit();
    }


    public static float GetCameraHeight()
    {
        return Camera.main.orthographicSize * 2;
    }


    public static float GetCameraHeightPixels()
    {
        return GetCameraHeight() * GetPixelPerUnit();
    }

    public static float GetAspectRatio()
    {
        return (float)Screen.width / (float)Screen.height;

    }
}
