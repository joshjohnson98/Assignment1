using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactivity : MonoBehaviour {


	void Start () {
		
	}
		

	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //change input.mouseposition to 
			//point ahead of center screen?
			if (Physics.Raycast(ray, out hit))
			if (hit.collider != null)
				hit.collider.enabled = false;
				gameObject.SetActive (false);


		}



			//gameObject.active = false;
			//Destroy(gameObject);
			//renderer.enabled = false;
	
	}


}
