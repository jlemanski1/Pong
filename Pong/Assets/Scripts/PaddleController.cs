using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    [SerializeField]
    private int speed;     // Paddle's move speed

    private void Awake() {
        speed = 30;     // Set speed
    }

    private void FixedUpdate () {
        // Vertical key press
        float vertInput = Input.GetAxisRaw("Vertical");

        //Set Paddle's velocity to the vertical input
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertInput) * speed;
	}
}
