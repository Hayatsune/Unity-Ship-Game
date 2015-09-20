using UnityEngine;
using System.Collections;

public class shootAgain : MonoBehaviour {
	private float timer = 0.4f;
	private Vector2 siz, en_siz;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		
		//Récupération de la taille du vaisseau auquel ce script est attaché
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		if (gameObject.tag == "Player") {
			//Si appui sur la touche espace
			bool sp = Input.GetKey(KeyCode.Space);
			
			if(sp && timer <= 0){
				//La position de création du tir se situe à la droite du vaisseau
				Vector3	tmpPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + siz.y/2, 
				                             gameObject.transform.position.z);	
				
				//Création d’une instance d’un prefab de type shootOrange
				GameObject gY = Instantiate(Resources.Load ("shoot1st"), tmpPos, Quaternion.identity) as GameObject;
				timer = 0.4f;
			}
		}
	}
}
