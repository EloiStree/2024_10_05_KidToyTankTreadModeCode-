using UnityEngine;

public class RestartLevelMono : MonoBehaviour
{

    [ContextMenu("Restart Level")]
    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}