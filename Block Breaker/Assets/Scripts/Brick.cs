using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private bool isBreakable;
    private SceneLoader sceneLoader;

	void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }

        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        timesHit = 0;
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 1f);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            sceneLoader.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = smokePuff.GetComponentInChildren<ParticleSystem>().main;
            main.startColor = new ParticleSystem.MinMaxGradient(GetComponent<SpriteRenderer>().color);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
      
    }
}
