using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpriteRenderer : MonoBehaviour {


    public Sprite walkingSprite_1;
	// Use this for initialization
	void Start () {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);
        spriteRenderer.sprite = walkingSprite_1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
