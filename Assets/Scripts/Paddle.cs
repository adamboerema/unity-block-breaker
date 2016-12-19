using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public float minX;
	public float maxX;
	public bool autoPlay;
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePosition.x = Mathf.Clamp (mousePositionInBlocks, minX, maxX);
		this.transform.position = paddlePosition;
	}
	
	void AutoPlay() {
		Vector3 paddlePosition = new Vector3(ball.transform.position.x, this.transform.position.y, 0f);
		this.transform.position = paddlePosition;
	}
}
