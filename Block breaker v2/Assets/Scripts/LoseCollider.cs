using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger) {
		Debug.Log ("Collision with lose collider");
		Debug.Log (trigger.gameObject.name);
		if (trigger.gameObject.name == "Ball") {
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("Lose");
		}
	}
}