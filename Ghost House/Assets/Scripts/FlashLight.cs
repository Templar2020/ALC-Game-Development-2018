// ToggleLight.cs
// Turns the light component of this object on/off when the user presses and releases the `L` key.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

	public bool lightOn;

	Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		// Set Light default to ON
		lightOn = true;
		light.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		// Toggle light on/off when L key is pressed.
		if (Input.GetKeyUp (KeyCode.L) && lightOn) {
			lightOn = false;
			light.enabled = false;
			
		}

		else if (Input.GetKeyUp (KeyCode.L) && !lightOn){			
			lightOn = true;
			light.enabled = true;
		}
	}
}
