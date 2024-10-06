using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKillDozerAiSingleTargetMono : MonoBehaviour
{
    public BasicKillDozerMoveMono m_killDozerToAffect;

    public Transform m_killDozer;
    public Transform m_whatToReach;



    [SerializeField]
    [Tooltip("Stop Moving Forward")]
    float m_stopMovingForward=0.05f;

    [Range(0, 85)]
    [SerializeField]
    [Tooltip("It is just to see if it is in front and not on the side. So it is limited to 85° ")]
    float m_frontAngle = 5;

    [Range(0,1)]
    [SerializeField] 
    [Tooltip("How fast the killdozer should rotate to reach the target")]
    float m_rotateSpeedAsPercent = 0.8f;


    [Header("Debug value (Don't Touch)")]
    [SerializeField] Vector3 m_killDozerPosition;
    [SerializeField] Vector3 m_whatToReachPosition;

    [SerializeField] Vector3 m_killDozerDirectionAtZeroFlatten;
    [SerializeField] Vector3 m_whatToReachDirectionAtZeroFlatten;

    [SerializeField] float m_angleBetweenKillDozerAndWhatToReach;

    public bool m_isTargetLeft = false;
    public bool m_isTargetRight = false;
    public bool m_isInFront = false;

    void Update()
    {
        if (m_killDozerToAffect == null)
        {
            return;
        }
        if (m_killDozerPosition == null)
        {
            return;
        }

        Vector3 targetPosition = m_whatToReach.position;
        Vector3 killDozerPosition = m_killDozer.position;
        targetPosition.y = 0;
        killDozerPosition.y = 0;
        float distance= Vector3.Distance(targetPosition, killDozerPosition);
        if (distance < m_stopMovingForward)
        {
            m_killDozerToAffect.SetPercentBackForwardTo(0);
            m_killDozerToAffect.SetToLeftDirectionWithPercent(0);

            return;
        }
        m_killDozerToAffect.SetPercentBackForwardTo(1);


        m_killDozerPosition = m_killDozer.position;
        m_whatToReachPosition = m_whatToReach.position;

        bool isInFrontOfKillDozer = IsTargetInFront();
        bool isLeft = IsTargetAtLeft();
        bool isRight = IsTargetAtRight();

        m_isTargetLeft = isLeft;
        m_isTargetRight = isRight;
        m_isInFront = isInFrontOfKillDozer;
        // AND
        // 00 0
        // 01 0
        // 10 0
        // 11 1

        if (isLeft)
        {
            m_killDozerToAffect.SetToRightDirectionWithPercent(m_rotateSpeedAsPercent);

        }

        if (isRight)
        {
            m_killDozerToAffect.SetToLeftDirectionWithPercent(m_rotateSpeedAsPercent);
        }

        //if(isInFrontOfKillDozer)
        //{
        //    m_killDozerToAffect.SetPercentBackForwardTo(1);
        //}
        //else
        //{
        //    m_killDozerToAffect.SetPercentBackForwardTo(0);
        //}

        Debug.DrawLine(m_killDozer.position, m_whatToReach.position, Color.red);
        Debug.DrawLine(m_killDozer.position, m_killDozer.position + m_killDozer.forward, Color.red);



        m_killDozerDirectionAtZeroFlatten = m_killDozer.forward;
        m_whatToReachDirectionAtZeroFlatten = m_whatToReach.position - m_killDozer.position;

        m_killDozerDirectionAtZeroFlatten.y = 0;
        m_whatToReachDirectionAtZeroFlatten.y = 0;

        m_angleBetweenKillDozerAndWhatToReach = GetAngleBetweenDozerAndTarget();


        Debug.DrawLine(Vector3.zero, m_killDozerDirectionAtZeroFlatten, Color.yellow);
        Debug.DrawLine(Vector3.zero, m_whatToReachDirectionAtZeroFlatten, Color.yellow);



    }

    private float GetAngleBetweenDozerAndTarget()
    {

        return Vector3.SignedAngle(m_killDozerDirectionAtZeroFlatten, m_whatToReachDirectionAtZeroFlatten, Vector3.up);
    }

    private bool IsTargetAtRight()
    {
        float angle = GetAngleBetweenDozerAndTarget();
        if (angle < -Math.Abs(m_frontAngle))
            return true;
        return false;
    }

    private bool IsTargetInFront()
    {
        float angle = GetAngleBetweenDozerAndTarget();
        if( Math.Abs(angle) < Math.Abs(m_frontAngle))
            return true;
        return false;
    }

    private bool IsTargetAtLeft()
    {

        float angle = GetAngleBetweenDozerAndTarget();
        if (angle > Math.Abs(m_frontAngle) )
            return true;
        return false;
    }
}
