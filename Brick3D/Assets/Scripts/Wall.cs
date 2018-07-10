using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
  public Rigidbody torch;

  // Use this for initialization
  void Start () {
    for (int y = 0; y < 5; y++) {
      for (int x = 0; x < 5; x++) {
        Instantiate(torch, new Vector3(x, y, x + y), Quaternion.identity);
      }
    } 
  }

  // Update is called once per frame
  void Update () {

  }
}
