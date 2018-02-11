using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControls : MonoBehaviour {

	//****************** CITATION *********************************
	//Inspiration for raycasting drawn from tutorial on YouTube
	//"Unity 3D - Basic Raycast (Javascript & C#)" by Master Indie
	//https://www.youtube.com/watch?v=hHaeiaXwSO8
	//*************************************************************

	//****************** CITATION *********************************
	//Inspiration for sunlight dimming drawn from Unity API
	//"Light.intensity" by Unity
	//https://docs.unity3d.com/ScriptReference/Light-intensity.html
	//*************************************************************

	public Transform playerLocation;
	public int interactions = 0;
	public AudioSource woodChopping;
	public AudioSource sizzlingMeat;
	public Light sunLight;
	public bool startDim = false;
	public float dimSpeed;

	//messages
	public GameObject startMessage;
	public GameObject postTreeMessage;
	public GameObject preLampMessage;
	public GameObject postLampMessage;

	//add other interactable objects and list tags here
	public GameObject treeObject; 		//tag: TreeTag
	public Light lampLight; 			//tag: LampTag
	public GameObject stoveObject;		//tag: StoveTag
	public GameObject uncookedObject;	//tag: UncookedTag


	void Start () {
		woodChopping = treeObject.GetComponent<AudioSource>();
		sizzlingMeat = stoveObject.GetComponent<AudioSource> ();

	}

	void Update () {
		if (sunLight.intensity > 0 /*edit this value for min sunlight*/ && startDim == true) {
			sunLight.intensity -= 0.001F*dimSpeed;
		}

		bool foundHit = false;
		RaycastHit hit = new RaycastHit ();

		if (Input.GetMouseButtonDown (0)) {



			foundHit = Physics.Raycast (transform.position, transform.forward, out hit, 10);

			if (foundHit) {
				print ("Hit!!!!");

				if (hit.collider.tag == "TreeTag" && interactions == 0) {
					woodChopping.Play ();
					//find way to play audio before destroying object
					//okay...so this is silly. but how about I throw it somewhere else....
					treeObject.transform.Translate (0, -30, 0);
					startMessage.SetActive (false);
					postTreeMessage.SetActive (true);
					preLampMessage.SetActive (true);
					startDim = true;

					interactions++;
				} else if (hit.collider.tag == "LampTag" && interactions == 1) {
					lampLight.intensity = 1;
					postTreeMessage.SetActive (false);
					preLampMessage.SetActive (false);
					postLampMessage.SetActive (true);
				
					interactions++;
				}
				else if (hit.collider.tag == "StoveTag" && interactions == 2){
						//meat changes color
					uncookedObject.SetActive(false);
				
						//sizzling sound effect
					sizzlingMeat.Play ();
					interactions++;
				}
			} else {
				print ("You didn't hit a tagged object!");
			}
		}
	}
}
