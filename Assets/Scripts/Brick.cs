using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;
	public GameObject smoke;
	private int timesHit = 0;
	private LevelManager levelManager;
	private bool isBreakable;

	
	
	// Use this for initialization
	void Start () {
		isBreakable = tag == "Breakable";
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		if(isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.1f);
		if(isBreakable) {
			HandleHites();
		}
	}
	
	void HandleHites () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else { 
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
		GameObject smokePuff = (GameObject) Instantiate (smoke, transform.position, Quaternion.identity);
		smokePuff.particleSystem.startColor = GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null) {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Missing sprite for index");
		}
	}

}
