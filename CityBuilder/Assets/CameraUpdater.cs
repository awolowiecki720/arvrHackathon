using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraUpdater : MonoBehaviour {

	public Text numObjectsText;
	public Text highestYCoordinateText;
	public Text didWinText;
	public Text cameraText;

	private int numObjects;
	private float highestYCoordinate;
	private bool hasWon = false;
	private float cameraX;
	private float cameraZ;

	// y to win
	private int maxY = 50;

	// Use this for initialization
	void Start () {
		numObjects = 0;
		setNumObjectsText();
		
		highestYCoordinate = float.MinValue;
		highestYCoordinateText.text = "";
		
		didWinText.text = "";

		cameraX = 0.0f;
		cameraZ = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		updateNumObjects();
		setNumObjectsText();
		updateHighestYCoordinate();
		setHighestYCoordinateText();
		checkDidWin();
		updateCameraCoordinates();
		setCameraCoordinatesText();
	}

	void updateHighestYCoordinate() {

		highestYCoordinate = float.MinValue;

		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("cube");
		foreach(GameObject gameObject in gameObjects) {
			if (gameObject.activeInHierarchy) {
				float y = gameObject.transform.position.y;
				if (y > highestYCoordinate) {
					highestYCoordinate = y;
				}
			}
		}
	}

	void updateNumObjects() {
		int count = 0;

		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("cube");
		foreach(GameObject gameObject in gameObjects) {
			if (gameObject.activeInHierarchy) {
				count++;
			}
		}
		numObjects = count;
	}

	void checkDidWin() {
		if (highestYCoordinate > maxY && !hasWon) {
			setDidWinText();
		}
	}

	void updateCameraCoordinates() {
		cameraX = Camera.main.gameObject.transform.position.x;
		cameraZ = Camera.main.gameObject.transform.position.z;
	}

	void setHighestYCoordinateText() {
		highestYCoordinateText.text = "Highest Y Coordinate: " + highestYCoordinate.ToString();
	}

	void setNumObjectsText() {
		numObjectsText.text = "# Cubes: " + numObjects.ToString();
	}

	void setDidWinText() {
		didWinText.text = "YOU WON!!";
	}

	void setCameraCoordinatesText() {
		cameraText.text = "position: " + ((int)cameraX).ToString() + ", " + ((int)cameraZ).ToString();
	}
}
