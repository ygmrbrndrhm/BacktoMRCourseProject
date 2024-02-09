using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrightnessManager : MonoBehaviour
{
    [SerializeField] private OVRPassthroughLayer passthroughLayer;
    //private SliderJoint2D slider;

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
    public void AdjustBrightnessGradually(float slidervalue)
    {
        if (passthroughLayer != null)
        {
            passthroughLayer.colorMapEditorBrightness = slidervalue;


        }


    }
}
