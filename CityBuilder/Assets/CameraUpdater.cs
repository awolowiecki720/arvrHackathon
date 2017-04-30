using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraUpdater : MonoBehaviour {

	public Text numObjectsText;
	public Text highestYCoordinateText;

	private int numObjects;
	private float highestYCoordinate;

	// Use this for initialization
	void Start () {
		numObjects = 0;
		highestYCoordinate = float.MinValue;
		setNumObjectsText();
	}
	
	// Update is called once per frame
	void Update () {
		updateNumObjects();
		setNumObjectsText();
		updateHighestYCoordinate();
		setHighestYCoordinateText();
	}

	void updateHighestYCoordinate() {

		highestYCoordinate = float.MinValue;

		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("cube");
		foreach(GameObject gameObject in gameObjects) {
			float y = gameObject.transform.position.y;
			if (y > highestYCoordinate) {
				highestYCoordinate = y;
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

	void setHighestYCoordinateText() {
		highestYCoordinateText.text = "Highest Y Coordinate: " + highestYCoordinate.ToString();
	}

	void setNumObjectsText() {
		numObjectsText.text = "# Cubes: " + numObjects.ToString();
	}
}
