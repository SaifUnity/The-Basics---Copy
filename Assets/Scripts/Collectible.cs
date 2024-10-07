using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;
    public AudioClip collectSound;  // Reference to the sound effect

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure there is an AudioSource component attached
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;  // Prevent sound from playing on start
        audioSource.clip = collectSound;  // Set the sound effect
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the collectible for a visual effect
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the collect sound effect
            audioSource.Play();

            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);

            // Destroy the collectible after a slight delay to allow the sound to play
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
