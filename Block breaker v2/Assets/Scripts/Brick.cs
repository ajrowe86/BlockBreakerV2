using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip bang;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject Smoke;
	public GameObject PowerUp;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	private PowerUps powerUps;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {	
	}
	
	void OnCollisionExit2D (Collision2D col) {
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			AudioSource.PlayClipAtPoint (bang, transform.position, 0.1f);
			PuffSmoke();
			PowerUpLoad();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PowerUpLoad() {
		int prob = Random.Range(1, 10);
		if (prob >= 1) {
			GameObject powerUp = Instantiate (PowerUp, transform.position, Quaternion.identity) as GameObject;
			powerUp.rigidbody2D.velocity = new Vector2 (0f, -2f);
		}
	}
	
	void PuffSmoke() {
		GameObject smokePuff = Instantiate (Smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick hit sprite missing.");
		}
	}
	
	// TODO Remove this method once we can actually win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
