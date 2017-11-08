using UnityEngine;
using System.Collections;

public class GhostStun : MonoBehaviour {
	
	bool lightCheck;
	FlashLight flash;

	public GameObject ghost;
	
		
	// Use this for initialization
	
	void Start () {
		//print("Obj:" +gameObject.GetComponentInChildren<Light>().GetComponentInChildren<FlashLight>());
		flash = gameObject.GetComponentInChildren<Light>().GetComponentInChildren<FlashLight>();
		//bool test = gameObject.GetComponentInChildren<Light>().FlashLight.isLightOn();
		//print("Test:"+test);
		print("Obj:"+flash);
		flash.setLightOn();
		print("Start" + flash.isLightOn());	
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){				
		print(other.gameObject.name);
		print ("Collider" + flash);	
		if(other.gameObject.name == "Ghost" && flash == true ){
			print("Ghost is stunned!");
			//  other.GetComponent<Rigidbody>().velocity = Vector3.zero;
			//  other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

			other.GetComponent<GhostAI>().moveSpeed = 0f;
			StartCoroutine(Wait(5));
			// StopCoroutine(Wait(5));
			
		}
	}
	
	IEnumerator Wait(float time){
			yield return new WaitForSeconds(time);
			ghost.GetComponent<GhostAI>().moveSpeed = 5f;
			print("Ghost is unstunned");
			
	}
	



}
