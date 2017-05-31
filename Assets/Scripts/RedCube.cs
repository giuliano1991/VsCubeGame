﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------

public class RedCube : MonoBehaviour {

	////////////////////////////
	// Alle Variablen

	// Öffentliche Floatvariablen für das maximale Ziehen und Drücken des Cubes + die Geschwindigkeit
	public float maxPull = 0;
	public float maxPush = 0;
	public float speed = 1f;

	// Öffentliche Intvariable für das Defenieren der Position des Cubes (0 = Boden; 1 = Decke; 2 = Vorne; 3 = Hinten; 4 = Links; 5 = Rechts)
	public int location = 0;

	// Startposition, Endposition und Distanz
	private Vector3 startPos;
	private Vector3 endPos;
	private float distance = 1f;

	// Bool zum Überprüfen ob die Animation läuft
	private bool isBusy = false;

//-------------------------------------------------------

	////////////////////////////
	// Use this for initialization
	void Start () {

		startPos = transform.position;

	}

//-------------------------------------------------------

	////////////////////////////
	// Update is called once per frame
	void Update () {
		
	}

//-------------------------------------------------------

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// GAMEPLAY FUNKTIONEN
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	////////////////////////////
	// Die Funktion wenn die linke Maustaste gedrückt wird
	public void LeftTrigger () {
	
		// Wird geprüft ob der maximale Ziehwert ungleich Null ist
		if (maxPull != 0 & isBusy != true) {
		
			// Switchabfrage für die Position des Cubes + die korrekte Berechnung der neuen Position
			switch (location)
			{
			case 0:
				StartCoroutine (GroundToTop ());
				break;
			
			case 1:
				StartCoroutine (TopToGround ());
				break;

			case 2:
				StartCoroutine (FrontToBack ());
				break;

			case 3:
				StartCoroutine (BackToFront ());
				break;

			case 4:
				StartCoroutine (LeftToRight ());
				break;

			case 5:
				StartCoroutine (RightToLeft ());
				break;
			}
				
			--maxPull;
			++maxPush;

		}
	}

//-------------------------------------------------------

	////////////////////////////
	// Die Funktion wenn die rechte Maustaste gedrückt wird
	public void RightTrigger () {
	
		// Wird geprüft ob der maximale Drückwert ungleich Null ist
		if (maxPush != 0 & isBusy != true) {

			// Switchabfrage für die Position des Cubes + die korrekte Berechnung der neuen Position
			switch (location)
			{
			case 0:
				StartCoroutine (TopToGround ());
				break;

			case 1:
				StartCoroutine (GroundToTop ());
				break;

			case 2:
				StartCoroutine (BackToFront ());
				break;

			case 3:
				StartCoroutine (FrontToBack ());
				break;

			case 4:
				StartCoroutine (RightToLeft ());
				break;

			case 5:
				StartCoroutine (LeftToRight ());
				break;
			}

			++maxPull;
			--maxPush;

		}
	}

//-------------------------------------------------------

//} ENDE GAMEPLAY FUNKTIONEN

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// IENUMERATOR / ANIMATION
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes von unten nach oben
	IEnumerator GroundToTop () {

		// Timer wird auf Null gesetzt und die Startposition und Endposition des Cubes wird ermittelt
		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + new Vector3 (0, distance, 0);

		// Der Timer wird gestartet
		while (timeSinceStarted <= 1f) {

			// Solange der Timer nicht zuende ist, ist der Cube "beschäftigt" und kann erstmal nicht weiter betätigt werden. Die Positionen vom Cube für die Animation werden berechnet und umgesetzt 
			isBusy = true;
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
			yield return null;

		}

		// Nachdem der Timer zuende ist, ist der Cube wieder interagierbar
		isBusy = false;
		yield return new WaitForSeconds (0.1f);

	}

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes von oben nach unten
	IEnumerator TopToGround () {

		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + new Vector3 (0, -distance, 0);

		while (timeSinceStarted <= 1f) {

			isBusy = true;
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
			yield return null;

		}

		isBusy = false;
		yield return new WaitForSeconds (0.1f);

	}

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes von vorne nach hinten
	IEnumerator FrontToBack () {

		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + new Vector3 (0, 0, -distance);

		while (timeSinceStarted <= 1f) {

			isBusy = true;
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
			yield return null;

		}

		isBusy = false;
		yield return new WaitForSeconds (0.1f);

	}

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes von hinten nach vorne
	IEnumerator BackToFront () {

		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + new Vector3 (0, 0, distance);

		while (timeSinceStarted <= 1f) {

			isBusy = true;
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
			yield return null;

		}

		isBusy = false;
		yield return new WaitForSeconds (0.1f);

	}

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes von links nach rechts
	IEnumerator LeftToRight () {

		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + new Vector3 (distance, 0, 0);

		while (timeSinceStarted <= 1f) {

			isBusy = true;
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
			yield return null;

		}

		isBusy = false;
		yield return new WaitForSeconds (0.1f);

	}

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes von rechts nach links
	IEnumerator RightToLeft () {

		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + new Vector3 (-distance, 0, 0);

		while (timeSinceStarted <= 1f) {

			isBusy = true;
			timeSinceStarted += Time.deltaTime * speed;
			transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
			yield return null;

		}

		isBusy = false;
		yield return new WaitForSeconds (0.1f);

	}

//-------------------------------------------------------

//} ENDE IENUMERATOR / ANIMATION
}
