using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	private int timesHit = 0;
	private LevelManager levelManager;
	
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		bool isBreakable = tag == "Breakable";
		if(isBreakable) {
			HandleHites();
		}
	}
	
	void HandleHites () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits) {
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
	
	//TODO Remove this method once we can actually win
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
