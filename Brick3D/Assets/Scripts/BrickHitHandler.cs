using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHitHandler : MonoBehaviour {
    private GameObject _gameController;

    public GameObject GameController {
        get
        {
            if (_gameController == null)
            {
                var controller = GameObject.FindGameObjectWithTag("Controller");
                if (controller != null)
                {
                    _gameController = controller;
                }
            }
            return _gameController;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var isBall = collision.collider.gameObject.CompareTag("Ball");

        if (isBall)
        {
            GameController.SendMessage("OnBrickHit");
        }
    }
}
