using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // This method loads a scene based on the string name provided
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Load the scene with the given name
    }
}
