using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public SpriteRenderer SpriteRend;
    public GameObject Effect;
    public Sprite Face;
    public Sprite Back;
    public Sprite Mine;

	// Use this for initialization
	void Start ()
    {
        SpriteRend.sprite = Back;
    }

    void OnMouseUp()
    {
        ChangeSprite();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void ChangeSprite()
    {
        SpriteRend.sprite = Face;
        //Instantiate(Effect, transform.position, transform.rotation);
            
    }
}
