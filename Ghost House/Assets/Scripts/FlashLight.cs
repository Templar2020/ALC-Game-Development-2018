﻿// ToggleLight.cs
// Turns the light component of this object on/off when the user presses and releases the `L` key.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour {

	public bool lightOn = true;
	// Flashlight power capacity
	public int maxPower = 4;
	// Useable flashlight power
	public int currentPower;

	public int batDrainAmt;

	public float batDrainDelay;

	Light light;

	// Gets Battery UI Text
	public Text batteryText;

	// Use this for initialization
	void Start () {
		//Add power to flashlight
		currentPower = maxPower;
		print("Power = " + currentPower);

		light = GetComponent<Light> ();
		// Set Light default to ON
		lightOn = true;
		print("Turn light on when Flashlight is initiated");
		light.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		// Toggle light on/off when L key is pressed.
		if (Input.GetKeyUp (KeyCode.L) && lightOn) {
			print("Light Off");
			lightOn = false;
			light.enabled = false;
			
		}

		else if (Input.GetKeyUp (KeyCode.L) && !lightOn){
			print("Light On");			
			lightOn = true;
			light.enabled = true;
		}

		//Update Battery UI text
		batteryText.text = currentPower.ToString();

		//Drain Battery Life
		if(currentPower > 0){
			StartCoroutine(BatteryDrain(batDrainDelay,batDrainAmt));
		}
	}

	public void setLightOn(){
		lightOn = true;
	}

	public bool isLightOn(){
		return lightOn;
	
	}

	IEnumerator BatteryDrain(float delay, int amount){
		yield return new WaitForSeconds(delay);
		currentPower -= amount;
		if(currentPower <= 0){
			currentPower = 0;
			print("Battery is dead!");
			light.enabled = false;

		}
	}

}
