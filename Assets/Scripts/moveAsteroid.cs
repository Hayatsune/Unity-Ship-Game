using UnityEngine;
using System.Collections;

public class moveAsteroid : MonoBehaviour {
	private float speed;
	private Vector2 movement, siz;
	private Vector3 rightTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 leftTopCameraBorder;
	// Use this for initialization
	void Start () {
		speed = 5;
		
		float rayon = Random.Range (0, 2*Mathf.PI); 
		movement = new Vector2 (0 + 3 * Mathf.Sin(rayon),-speed);
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = movement;
		
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		
		//Destroy asteroids which get out
		if (transform.position.y + (siz.y/2) < leftBottomCameraBorder.y || 
		    transform.position.x - (siz.x/2) > rightBottomCameraBorder.x ||
		    transform.position.x + (siz.x/2) < leftBottomCameraBorder.x)
		{
			Vector3 tmpPos = new Vector3(Random.Range(leftTopCameraBorder.x,rightTopCameraBorder.x-(siz.x/2)),rightTopCameraBorder.y,
			                             transform.position.z);
			GameObject gY = Instantiate(Resources.Load("asteroid"), tmpPos, Quaternion.identity) as GameObject;
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//SI un astéroid touche le joueur, le joueur perd une vie
		if (collider.tag == "Player")
		{
			if(GameObject.FindGameObjectWithTag("life5"))
				GameObject.FindGameObjectWithTag("life5").AddComponent<fadeOut>();	
			else if(GameObject.FindGameObjectWithTag("life4"))
				GameObject.FindGameObjectWithTag("life4").AddComponent<fadeOut>();
			else if(GameObject.FindGameObjectWithTag("life3"))
				GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
			else if(GameObject.FindGameObjectWithTag("life2"))
				GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
			else if(GameObject.FindGameObjectWithTag("life1")){
				GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
				Destroy(GameObject.FindGameObjectWithTag("Player"));
			}
	}
}
