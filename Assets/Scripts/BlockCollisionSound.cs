using UnityEngine;

public class BlockCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;  // Reference to the sound effect
    public float volume = 1.0f;       // Volume control (default is 1, max volume)
    private AudioSource audioSource;

    void Start()
    {
        // Try to get the existing AudioSource, or add one if it doesn't exist
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;  // Ensure the sound doesn't play on start
        audioSource.clip = collisionSound;  // Assign the sound effect
    }

    // This method is called whenever the block collides with any object
    private void OnCollisionEnter(Collision collision)
    {
        // Play the sound effect on collision, with the specified volume
        if (collisionSound != null && audioSource != null)
        {
            audioSource.volume = volume;  // Set the volume
            audioSource.Play();
        }
    }
}
