using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PokeableItemClick : MonoBehaviour
{

    [SerializeField] public PokeInteractor rightPoke;
    [SerializeField] TMP_Text text;
    [SerializeField] private OVRPassthroughLayer passthroughLayer;
    private void Start()
    {
        AdjustBrightness(0f);

    }
    private void Update()
    {
        if (rightPoke.Interactable == true)
        {
            AdjustBrightnessGradually();
        }
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
        if (passthroughLayer != null && rightPoke.Interactable.name!=null)
        {
            float currentBrightness = passthroughLayer.colorMapEditorBrightness;
            
            if (rightPoke.Interactable.name == "IncreaseBrightness")
            {       
                currentBrightness = currentBrightness + 0.02f;
            }
            else if(rightPoke.Interactable.name == "LowerBrightness")
            {
                currentBrightness = currentBrightness -0.02f;
            }
            passthroughLayer.colorMapEditorBrightness = currentBrightness;

        }


    }
}
