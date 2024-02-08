
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerPress : MonoBehaviour
{
    private Input input = null;
    private float triggerpress;
    [SerializeField] public GameObject obj;
    private void Awake()
    {
        input = new Input();
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
}

