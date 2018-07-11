using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickGameController : MonoBehaviour {

    public Text textScore;
    private int score = 0;
	// Use this for initialization
	void Start () {
        syncText();
	}

    private void syncText()
    {
        textScore.text = score.ToString();
    }

    private void OnBrickHit()
    {
        score++;
    }
	
	// Update is called once per frame
	void Update () {
        syncText();
	}
}
