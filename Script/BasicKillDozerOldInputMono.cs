using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKillDozerOldInputMono : MonoBehaviour
{

    public BasicKillDozerMoveMono m_moveDozer;

    public KeyCode m_KeyForward= KeyCode.Z;
    public KeyCode m_keyBackward = KeyCode.B;
    public KeyCode m_keyLeft= KeyCode.Q;
    public KeyCode m_keyRight= KeyCode.D;

    void Update()
    {
        // Does player  want to move forward?
        if (Input.GetKey(KeyCode.UpArrow) || 
            Input.GetKey(m_KeyForward))
        {
            m_moveDozer.SetPercentBackForwardTo(1);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(m_keyBackward))
        {
            m_moveDozer.SetPercentBackForwardTo( -1);
        }
        else
        {
            m_moveDozer.SetPercentBackForwardTo(0) ;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(m_keyLeft))
        {
            m_moveDozer.SetPercentLeftRightTo(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(m_keyRight))
        {
            m_moveDozer.SetPercentLeftRightTo(1);
        }
        else
        {
            m_moveDozer.SetPercentLeftRightTo(0) ;
        }

    }
}
