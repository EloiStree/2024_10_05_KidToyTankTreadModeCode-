using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ListenToButtonsEventMono : MonoBehaviour { 

    public InputActionReference m_buttonToListen;
    public UnityEvent<bool> m_onButtonValueChanged;
    public UnityEvent m_onButtonTrue;
    public UnityEvent m_onButtonFalse;
    public bool m_currentValue;

    void OnEnable()
    {
        m_buttonToListen.action.Enable();
        m_buttonToListen.action.performed += TriggerEventsUnity;
        m_buttonToListen.action.canceled += TriggerEventsUnity;
    }

    void OnDisable()
    {
        //m_buttonToListen.action.Disable();
        m_buttonToListen.action.performed -= TriggerEventsUnity;
        m_buttonToListen.action.canceled -= TriggerEventsUnity;
    }


    private void TriggerEventsUnity(InputAction.CallbackContext context)
    {
        bool wasPressed = m_currentValue;
        bool isPressedNow = context.ReadValue<float>() > 0.5f;
        m_currentValue = isPressedNow;

        if(wasPressed != isPressedNow)
        {
            m_onButtonValueChanged.Invoke(isPressedNow);
            if (isPressedNow)
            {
                m_onButtonTrue.Invoke();
            }
            else
            {
                m_onButtonFalse.Invoke();
            }
        }
    }
}
