
using Oculus.Haptics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerPress : MonoBehaviour
{
    private Input input = null;
    private float triggerpress;
    [SerializeField] public GameObject obj;
   // [SerializeField] private HapticClip hapticClip;
    //private HapticClipPlayer hapticClipPlayer;
    [SerializeField] private float hapticDuration = 0.1f;
    private void Awake()
    {
        input = new Input();
        //hapticClipPlayer = new HapticClipPlayer(hapticClip);
    }
    private void OnEnable()
    {
        input.Enable();
        input.OculusController.Trigger.performed += OnTriggerPerformed;
        input.OculusController.Trigger.canceled += OnTriggerCanceled;
    }
    private void OnDisable()
    {
        input.Disable();
        input.OculusController.Trigger.performed -= OnTriggerPerformed;
        input.OculusController.Trigger.canceled -= OnTriggerCanceled;
    }
    private void OnTriggerPerformed(InputAction.CallbackContext value)
    {
       // PlayHapticFeedback();
        VibrateTriggerBasedOnPressure(triggerpress);
        //StartCoroutine(TriggerHapticFeedback());//1
        triggerpress = value.ReadValue<float>();
        ColorChange();
    }
    private void OnTriggerCanceled(InputAction.CallbackContext value)
    {
        triggerpress = value.ReadValue<float>();
        ColorChange();
    }
    public void ColorChange()
    {
        if (triggerpress > 0.5f)
        {
            obj.GetComponent<Renderer>().material.color = Color.red;


        }
        else if (triggerpress < 0.5f)
        {
             obj.GetComponent<Renderer>().material.color = Color.white;
        }
    }


    private void VibrateTriggerBasedOnPressure(float triggerpress)
    {
        OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Hand, triggerpress,1, OVRInput.Controller.Active);
    }
    //private IEnumerator TriggerHapticFeedback()//1
    //{
    //    OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    //    yield return new WaitForSeconds(hapticDuration);
    //    OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    //}//1
    //private void PlayHapticFeedback()
    //{
    //    hapticClipPlayer.Play(Controller.Right);
    //}
    //private void OnDestroy()
    //{
    //    hapticClipPlayer.Dispose();
    //}
    //private void OnApplicationQuit()
    //{
    //    Haptics.Instance.Dispose();
    //}
}

