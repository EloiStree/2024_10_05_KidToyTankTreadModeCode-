using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BasicKillDozerNewInputMono : MonoBehaviour
{

    public BasicKillDozerMoveMono m_moveDozer;

    public InputActionReference m_moveBackwardForward;
    public InputActionReference m_rotateLeftRight;

    public float m_moveAxisState;
    public float m_rotateAxisState;


    private void Start()
    {
        m_moveBackwardForward.action.Enable();
        m_rotateLeftRight.action.Enable();
    }

    void Update()
    {

        m_moveAxisState = m_moveBackwardForward.action.ReadValue<float>();
        m_rotateAxisState = m_rotateLeftRight.action.ReadValue<float>();

        if(m_moveDozer != null)
        {
            m_moveDozer.SetPercentBackForwardTo(m_moveAxisState);
            m_moveDozer.SetPercentLeftRightTo(m_rotateAxisState);
        }
        
    }
}
