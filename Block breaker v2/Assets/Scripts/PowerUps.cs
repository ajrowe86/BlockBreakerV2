using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	public GameObject PowerUp;
	public AudioClip PowerUpCollected;
	
	public int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Paddle") {
			Debug.Log ("Power Up collected!!!");
			AudioSource.PlayClipAtPoint (PowerUpCollected, transform.position, 0.1f);
			score = score + 100;
			Debug.Log (score);
			Destroy(gameObject);
		}
		if (other.gameObject.name == "Lose Collider") {
			Debug.Log ("Power Up destroyed!!");
			Debug.Log (score + "test");
			//if (score >= 20) {
				score = score - 20;
				Debug.Log (score);
			//}
			Destroy(gameObject);
		}
	}
	
	
}
