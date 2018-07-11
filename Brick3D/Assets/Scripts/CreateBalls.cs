using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBalls : MonoBehaviour {

    public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
        for (var x = -1; x <= 1; x++)
        {
            for (var z = -1; z <= 1; z++)
            {
                var ball = Instantiate(ballPrefab, transform.position, transform.rotation, transform);

                ball.transform.localPosition = new Vector3(x * 0.2f, 0, z * 0.2f);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
