using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessManager : MonoBehaviour
{
    [SerializeField] private OVRPassthroughLayer passthroughLayer;
    
    private void Start()
    {
        AdjustBrightness(0f);

    }
    public void AdjustBrightness(float brightnessAmount)
    {
        if (passthroughLayer != null)
        {

            passthroughLayer.SetBrightnessContrastSaturation(brightnessAmount);

        }
    }
    public void AdjustBrightnessGradually()
    {
        if (passthroughLayer != null)
        {
            float currentBrightness = passthroughLayer.colorMapEditorBrightness;
            

        }
        

    }
}
