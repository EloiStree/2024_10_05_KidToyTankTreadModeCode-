using UnityEngine;
using UnityEngine.InputSystem;

public class BasicKillDozerNewMouseInputMono : MonoBehaviour
{

    public BasicKillDozerMoveMono m_killDozer;

    public Vector2 m_mousePosition = new Vector2();
    public Vector2 m_mousePositionPercent = new Vector2();
    public Vector2 m_mousePositionPercentFromMiddle = new Vector2();
    public float m_screenWidth = 0;
    public float m_screenHeight = 0;

    public bool m_isMousePressed = false;

    public InputActionReference m_positionOnScreen;
    public InputActionReference m_usePressingScreen;


    void Start()
    {
        m_positionOnScreen.action.Enable();
        m_usePressingScreen.action.Enable();
    }

    void Update()
    {
        m_screenWidth = Screen.width;
        m_screenHeight = Screen.height;

        m_mousePosition = m_positionOnScreen.action.ReadValue<Vector2>();
        m_isMousePressed = m_usePressingScreen.action.ReadValue<float>()>0.5f;

        //m_mousePositionPercent= new Vector2(
        //  Mathf.Clamp01(  m_mousePosition.x / m_screenWidth),
        //    Mathf.Clamp01( m_mousePosition.y / m_screenHeight)
        //    );

        m_mousePositionPercent.x = Mathf.Clamp01(m_mousePosition.x / m_screenWidth);
        m_mousePositionPercent.y = Mathf.Clamp01(m_mousePosition.y / m_screenHeight);

        m_mousePositionPercentFromMiddle.x = Mathf.Clamp((m_mousePositionPercent.x - 0.5f) * 2f, -1, 1);
        m_mousePositionPercentFromMiddle.y = Mathf.Clamp((m_mousePositionPercent.y - 0.5f) * 2f, -1, 1);



        if (m_isMousePressed)
        {

            m_killDozer.SetPercentLeftRightTo(m_mousePositionPercentFromMiddle.x);
            m_killDozer.SetPercentBackForwardTo(m_mousePositionPercentFromMiddle.y);
        }


    }
}
