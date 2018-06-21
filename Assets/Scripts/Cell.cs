using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public SpriteRenderer SpriteRend;
    public GameManager Manager;
    public int x_id;
    public int y_id;
    public Sprite Face;
    public Sprite Back;
    public Sprite Mine;

    public bool isMine = false;

	// Use this for initialization
	void Awake ()
    {
        SpriteRend.sprite = Back;
    }

    void OnMouseUp()
    {
        ChangeSprite();
        if(!this.isMine)
        {
            Manager.checkCellsAround(this);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeSprite()
    {
        if(!isMine)
        {
            SpriteRend.sprite = Face;

        }
        else
        {
            Manager.gameOver();
        }

        //Instantiate(Effect, transform.position, transform.rotation);
            
    }
}
