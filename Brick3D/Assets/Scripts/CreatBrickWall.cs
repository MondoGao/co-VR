using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatBrickWall : MonoBehaviour {

    public GameObject brickPrefab;
	// Use this for initialization
	void Start () {
        for (var z = -2; z < 3; z++)
        {
            for (var y = 0; y < 4; y++)
            {
                var brick = Instantiate(brickPrefab, transform.position, transform.rotation, transform);

                brick.transform.Rotate(new Vector3(0, 90, 0));
                brick.transform.localPosition = new Vector3(0, y * 0.003f, z * 0.006f);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
