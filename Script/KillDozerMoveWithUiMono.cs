using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillDozerMoveWithUiMono : MonoBehaviour
{

    public BasicKillDozerMoveMono m_killDozer;
    public Slider m_fromBackToFront;
    public Slider m_fromLeftToRight;

    void Update()
    {

        if (m_fromBackToFront != null) {

            m_killDozer.SetPercentBackForwardTo(m_fromBackToFront.value)  ;
        }
        if(m_fromLeftToRight != null) {

            m_killDozer.SetPercentLeftRightTo(m_fromLeftToRight.value)  ;
        }
     }
}
