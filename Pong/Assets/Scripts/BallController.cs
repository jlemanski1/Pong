using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private int speed;     // Ball's move speed

    private Rigidbody2D rigidBody;
    private AudioSource audioSource;


	private void Awake () {
        speed = 30;

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;     // Start ball towards AI Paddle
	}


    // Collision
    private void OnCollisionEnter2D(Collision2D collision) {
        // Collided with a paddle
        if ((collision.gameObject.name == "L_Paddle") || (collision.gameObject.name == "R_Paddle")) {
            HandlePaddleHit(collision);
        }

        // Collided with either top or bottom walls
        if ((collision.gameObject.name == "Floor") || (collision.gameObject.name == "Roof")) {
            // Play Wall Hit sound effect
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallHit);
        }

        // Collided with left or right goal walls
        if ((collision.gameObject.name == "L_Goal") || (collision.gameObject.name == "R_Goal")) {
            // TODO: Update Score UI

            // Reset ball to centre
            transform.position = new Vector2(0, 0);
        }
    }

    
    // Handles Paddle-Ball hit logic
    private void HandlePaddleHit(Collision2D collision) {
        float y = PaddleHitLocation(transform.position, collision.transform.position,
            collision.collider.bounds.size.y);

        Vector2 dir = new Vector2();    // Ball's direction

        // Left Paddle Hit
        if ( collision.gameObject.name  == "L_Paddle"){
            dir = new Vector2(1, y).normalized;
        }

        // Right Paddle Hit
        if (collision.gameObject.name == "R_Paddle"){
            dir = new Vector2(-1, y).normalized;
        }

        // Calcluate ball's velocity
        rigidBody.velocity = dir * speed;

        // Play Paddle Hit sound effect
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.paddleHit);
    }


    // Returns the position the ball hit the paddle
    private float PaddleHitLocation(Vector2 ballPos, Vector2 paddlePos, float paddleHeight) {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }
}
