using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;
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
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

}
