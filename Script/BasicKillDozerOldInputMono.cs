using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKillDozerOldInputMono : MonoBehaviour
{

    public BasicKillDozerMoveMono m_moveDozer;

    void Start()
    {
        
    }

    void Update()
    {


        // Does player  want to move forward?
        if (Input.GetKey(KeyCode.UpArrow) || 
            Input.GetKey(KeyCode.Z)
            )
        {
            m_moveDozer.SetPercentBackForwardTo(1);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            m_moveDozer.SetPercentBackForwardTo( -1);
        }
        else
        {
            m_moveDozer.SetPercentBackForwardTo(0) ;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            m_moveDozer.SetPercentLeftRightTo(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            m_moveDozer.SetPercentLeftRightTo(1);
        }
        else
        {
            m_moveDozer.SetPercentLeftRightTo(0) ;
        }

    }
}
