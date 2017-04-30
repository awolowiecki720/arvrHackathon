using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    public GameObject cubePrefab;
    public List<GameObject> spawnedCubes;
    public bool isPlacing = false;

    private List<Color> colors = new List<Color>();
    private int colorIndex;

	// Use this for initialization
	void Start () {
        spawnedCubes = new List<GameObject>();
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.green);
        colors.Add(Color.magenta);
        colors.Add(Color.cyan);
        colors.Add(Color.yellow);
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
            Renderer r = cube.GetComponent<Renderer>();
            //if (r)
            //{
            r.material.color = colors[colorIndex];
            colorIndex = (colorIndex + 1) % colors.Count;
            //}
            spawnedCubes.Add(cube);
        }
        else if(AirTapSwag.AirTap && isPlacing)
        {
            isPlacing = false;
        }
	}
}
