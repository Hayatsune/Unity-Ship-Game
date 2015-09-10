using UnityEngine;
using System.Collections;

public class moveShip : MonoBehaviour {
	private Vector2 movement, siz;
	private Vector3 rightTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private float positionShip, vertical, horizontal, yPos, xPos; 
	public float speed;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		positionShip = leftBottomCameraBorder.y + gameObject.GetComponent<SpriteRenderer> ().bounds.size.y/2;
		transform.position = new Vector3 (transform.position.x, positionShip, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		
		//Left
		if (transform.position.x - (siz.x / 2) < leftBottomCameraBorder.x) 
			transform.position = new Vector3(leftBottomCameraBorder.x + siz.x/2, transform.position.y, transform.position.z);
		
		//Right
		if(transform.position.x + (siz.x / 2) > rightBottomCameraBorder.x)
			transform.position = new Vector3(rightBottomCameraBorder.x - siz.x/2, transform.position.y, transform.position.z);
		
		//Top
		if (transform.position.y + (siz.y / 2) > rightTopCameraBorder.y)
			transform.position = new Vector3 (transform.position.x, rightTopCameraBorder.y - siz.y/2, transform.position.z);
		
		//
		if (transform.position.y - (siz.y / 2) < rightBottomCameraBorder.y)
			transform.position = new Vector3 (transform.position.x, rightBottomCameraBorder.y + siz.y/2, transform.position.z);
		
		//Get the horizontal and vertical inputs
		vertical = Input.GetAxis ("Vertical");
		horizontal = Input.GetAxis ("Horizontal");
		
		yPos = vertical * speed;
		xPos = horizontal * speed;
		
		movement = new Vector3 (xPos, yPos, 0);
		
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
