using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int brickCount = 0;

	public AudioClip crack;
	public Sprite[] hitSprites;

	private LevelManager levelManager;
	private int timesHit;

	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			brickCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();


	}


	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			brickCount--;
			Debug.Log(brickCount);
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHit -1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}

	}

	// TODO Remove this method once we can actually win

	void SimulteWin() {
		levelManager.LoadNextLevel();
	}

}
