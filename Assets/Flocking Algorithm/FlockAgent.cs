using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Find neighbors using a collider

[RequireComponent(typeof(Collider2D))]

public class FlockAgent : MonoBehaviour {

    Collider2D agentCollider;
    // Accesser
    public Collider2D AgentCollider { get { return agentCollider; } }

	// Use this for initialization
	void Start ()
    {
        // Gets the collider that is attached to the object
        agentCollider = GetComponent<Collider2D>();
	}
	
    public void Move(Vector2 velocity)
    {
        // Move the agent to the position of the velocity
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
