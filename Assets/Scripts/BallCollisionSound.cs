using UnityEngine;

public class BallCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;  // Reference to the sound effect
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component if it doesn't exist already
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;  // Prevent sound from playing on start
        audioSource.clip = collisionSound;  // Set the sound effect
    }

    // This method is called whenever the ball collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the ball collided with is named "Ramp"
        if (collision.gameObject.name == "Ramp")
        {
            // Play the sound effect when the collision is with the "Ramp"
            if (collisionSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
