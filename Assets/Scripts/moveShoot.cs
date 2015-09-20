using UnityEngine;
using System.Collections;

public class moveShoot : MonoBehaviour {
	public float speed;
	private Vector2 siz;
	private Vector3 movement;
	private Vector3 rightTopCameraBorder;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		
		if (transform.position.y + (siz.y / 2) > rightTopCameraBorder.y) Destroy (gameObject);
		
		movement = new Vector3 (0, speed, transform.position.z);
		GetComponent<Rigidbody2D> ().velocity = movement;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag != "Player") {
			collider.gameObject.AddComponent<fadeOut> ();
			Destroy (gameObject);
		}
	}
}
