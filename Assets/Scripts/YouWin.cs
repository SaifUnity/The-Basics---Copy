using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class YouWin : MonoBehaviour
{
    // When a trigger collision happens
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Load the scene with index 7
            SceneManager.LoadScene(7);
        }
    }
}
