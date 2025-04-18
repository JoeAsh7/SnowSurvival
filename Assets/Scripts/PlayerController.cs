using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class roboController : MonoBehaviour
{
    private const string FoodObject = "FoodObject";
    private const string GroundTag = "Ground";
    private const string roboTag = "Player";
    private const string Snowflake = "Snowflake";
    
    // Explosion Prefab variable
    public GameObject explosionPrefab = null;
    public GameObject explosionInstance = null;

    // Food Collected Audio Prefab variable
    public GameObject foodCollectedAudioPrefab = null;
    public GameObject foodCollectedAudioInstance = null;

    // Private Variables
    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        

    }
        void OnCollisionEnter2D(Collision2D collidedObject)
        {
            //Destroy the collided object
            Destroy(collidedObject.gameObject);
            if (collidedObject.gameObject.CompareTag(Snowflake))
            {
                GameManager.Instance.HandleBombCollision("Snowflake");
                Debug.Log("Bomb Detected");
                // Explosion animation
                // Add offset to the explosion position
                Vector3 explosionPosition = new Vector3(transform.position.x-0.1f, transform.position.y+1f, transform.position.z);
                // Instantiate the explosion prefab at the snow's position
                explosionInstance = Instantiate(explosionPrefab, explosionPosition, transform.rotation);
                // Destroy the explosion instance after 1 second
                Destroy(explosionInstance, 5f);
            }
        }
}
