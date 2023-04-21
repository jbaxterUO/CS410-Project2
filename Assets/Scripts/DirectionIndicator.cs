using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform exit;
    public GameObject player;
    public float maxDistance = 10.0f;
    public Color startColor = Color.green;
    public Color endColor = Color.red;

    new Renderer renderer;
    private float initialSize;

    void Start()
    {
        // Store the initial size of the sphere
        initialSize = transform.localScale.magnitude;
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        

        // Calculate the direction from the player to the exit
        Vector3 direction = exit.position - transform.position;
        direction.y = 0.0f; // Ignore vertical distance
        float distance = direction.magnitude;

        // Normalize the direction vector
        direction.Normalize();

        // Calculate the dot product between the player's forward vector and the direction vector
        float dotProduct = Vector3.Dot(transform.forward, direction.normalized);
        float minDotProduct = 0.0f;
        float maxDotProduct = 1.0f;

        float lerpValue = Mathf.Clamp01((dotProduct - minDotProduct) / (maxDotProduct - minDotProduct));

        Color color = Color.Lerp(startColor, endColor, lerpValue);

        renderer.enabled = true;
        renderer.material.color = color;

        // Set the size of the sphere based on the distance
        float size = Mathf.Clamp(distance, 0.0f, maxDistance) / maxDistance;
        transform.localScale = initialSize * size * Vector3.one;

        bool isMoving = player.GetComponent<PlayerMovement>().isMoving();

        if (!isMoving)
        {
            renderer.enabled = false;
        }

    }

}



















