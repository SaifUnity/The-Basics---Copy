using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Variable to set the duration of a full day in seconds, editable in the Inspector
    [SerializeField]
    private float dayDuration = 120f; // 2 minutes for a full day cycle, adjust as needed

    // Colors for different times of day
    [SerializeField]
    private Color morningColor = new Color(1f, 0.85f, 0.7f); // Warm morning color
    [SerializeField]
    private Color noonColor = Color.white; // Bright white color at noon
    [SerializeField]
    private Color eveningColor = new Color(1f, 0.6f, 0.4f); // Orange sunset color
    [SerializeField]
    private Color nightColor = new Color(0.1f, 0.1f, 0.35f); // Dark blue night color

    // To store the initial rotation of the light
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation; // Save the initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the percentage of the day that has passed
        float time = (Time.time / dayDuration) % 1; // Keeps time between 0 and 1 for the cycle

        // Rotate the light based on the time of day
        float angle = time * 360f; // 360 degrees for a full rotation
        transform.rotation = initialRotation * Quaternion.Euler(angle, 0, 0);

        // Change light color based on time of day
        if (time <= 0.25f) // Morning (6 AM - 12 PM)
        {
            // Interpolate from morningColor to noonColor
            float t = time / 0.25f;
            GetComponent<Light>().color = Color.Lerp(morningColor, noonColor, t);
        }
        else if (time <= 0.5f) // Noon (12 PM - 6 PM)
        {
            // Interpolate from noonColor to eveningColor
            float t = (time - 0.25f) / 0.25f;
            GetComponent<Light>().color = Color.Lerp(noonColor, eveningColor, t);
        }
        else if (time <= 0.75f) // Evening (6 PM - 12 AM)
        {
            // Interpolate from eveningColor to nightColor
            float t = (time - 0.5f) / 0.25f;
            GetComponent<Light>().color = Color.Lerp(eveningColor, nightColor, t);
        }
        else // Night (12 AM - 6 AM)
        {
            // Interpolate from nightColor to morningColor
            float t = (time - 0.75f) / 0.25f;
            GetComponent<Light>().color = Color.Lerp(nightColor, morningColor, t);
        }
    }
}
