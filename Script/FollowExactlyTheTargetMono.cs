using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowExactlyTheTargetMono : MonoBehaviour
{
    public Transform m_whatToMove;
    public Transform m_whatToFollow;
 
    void Update()
    {
        if (IsOneGivenPointsIsNull())
        {
            return;
        }
        CopyValueFromFollowToWhatToMove();
    }

    private void CopyValueFromFollowToWhatToMove()
    {
        m_whatToMove.position = m_whatToFollow.position;
        m_whatToMove.rotation = m_whatToFollow.rotation;
    }

    private bool IsOneGivenPointsIsNull()
    {
        return m_whatToMove == null || m_whatToFollow == null;
    }
}
