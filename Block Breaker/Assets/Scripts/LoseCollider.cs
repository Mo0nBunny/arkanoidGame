using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private SceneLoader sceneLoader;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        sceneLoader.loadGameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
