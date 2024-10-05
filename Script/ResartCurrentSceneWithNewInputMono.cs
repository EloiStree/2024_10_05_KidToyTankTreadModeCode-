using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResartCurrentSceneWithNewInputMono : MonoBehaviour
{

    public InputActionReference m_restartAction;

    void Start()
    {
        m_restartAction.action.Enable();

        m_restartAction.action.performed += RestartGame;
        m_restartAction.action.canceled += RestartGame;
    }

    private void RestartGame(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValue<float>() > 0.5f;
        if (isPressed) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
