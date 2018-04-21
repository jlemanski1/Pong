using UnityEngine;

public class AIPaddle : MonoBehaviour {

    public BallController ball;

    [SerializeField]
    private int speed;

    public float lerpSmoothing = 2f;    // Field to smooth interpolation
    private Rigidbody2D rigidBody;


	private void Awake () {
        speed = 30;
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	
	private void FixedUpdate () {
        // Ball is higher than the paddle
		if (ball.transform.position.y > transform.position.y) {
            Vector2 dir = new Vector2(0, 1).normalized;

            // Move paddle
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * speed, lerpSmoothing * Time.deltaTime);
        }
        // Ball is lower than the paddle
        else if (ball.transform.position.y < transform.position.y) {
            Vector2 dir = new Vector2(0, -1).normalized;

            // Move paddle
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * speed, lerpSmoothing * Time.deltaTime);
        }
        // Reset paddle's location and zero out movement
        else {
            Vector2 dir = new Vector2(0, 0).normalized;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * speed, lerpSmoothing * Time.deltaTime);
        }
    }


}
