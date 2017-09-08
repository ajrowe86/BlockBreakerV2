using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			// Wait for a mouse press to launch the ball.
			if (Input.GetMouseButtonDown(0)) {
				Debug.Log ("Left mouse button clicked, launch ball");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
		if (hasStarted) {
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
}
