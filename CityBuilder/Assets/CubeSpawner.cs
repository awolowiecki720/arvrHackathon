using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    public GameObject cubePrefab;
    public List<GameObject> spawnedCubes;
    public bool isPlacing = false;

	// Use this for initialization
	void Start () {
        spawnedCubes = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("hello!!!");
        if (AirTapSwag.AirTap)
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, 1 << gameObject.layer);
            //hit.collider.

            Debug.Log(hit.collider);
            //isPlacing = true;

            foreach (GameObject spawnedCube in spawnedCubes)
            {
                GazePlaceSwag spawnedCubeGps = spawnedCube.GetComponent<GazePlaceSwag>();
                if (spawnedCubeGps.pickedUp)
                {
                    return;
                }
            }

            GameObject cube = Instantiate(cubePrefab);
            
            cube.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;
            spawnedCubes.Add(cube);
        }
        else if(AirTapSwag.AirTap && isPlacing)
        {
            isPlacing = false;
        }
	}
}
