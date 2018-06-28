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
    public Sprite BackFlag;
    public Sprite Mine;
    public Sprite One;
    public Sprite Two;
    public Sprite Three;
    public Sprite Four;
    public Sprite Five;
    public Sprite Six;
    public Sprite Seven;
    public Sprite Eight;


    public int num_of_Mines = 0;

    public bool isMine = false;
    public bool isFlag = false;
    public bool isChecked = false;


    // Use this for initialization
    void Awake ()
    {
        SpriteRend.sprite = Back;
    }

    void OnMouseUp()
    {
        if (!Manager.isOver && !Manager.isPaused)
        {
            isChecked = true;
            ChangeSprite();
            if (!this.isMine)
            {
                Manager.checkCellsAround(this);
            }

        }

    }
	
	// TODO: For some reason  right click not working, need to be debugged and clarified
	void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (!isChecked && !Manager.isOver && !isFlag)
            {
                SpriteRend.sprite = BackFlag;
                isFlag = true;
            }
            if (!isChecked && !Manager.isOver && isFlag)
            {
                SpriteRend.sprite = Back;
                isFlag = false;
            }
        }

    }

    public void ChangeSprite()
    {
        if(!isMine)
        {
            switch (num_of_Mines)
            {
                case 1:
                    SpriteRend.sprite = One;
                    break;
                case 2:
                    SpriteRend.sprite = Two;
                    break;
                case 3:
                    SpriteRend.sprite = Three;
                    break;
                case 4:
                    SpriteRend.sprite = Four;
                    break;
                case 5:
                    SpriteRend.sprite = Five;
                    break;
                case 6:
                    SpriteRend.sprite = Six;
                    break;
                case 7:
                    SpriteRend.sprite = Seven;
                    break;
                case 8:
                    SpriteRend.sprite = Eight;
                    break;
                default:
                    SpriteRend.sprite = Face;
                    break;

            }

            Manager.openedCells++;
            

        }
        else
        {
            Manager.gameOver();
        }

        //Instantiate(Effect, transform.position, transform.rotation);
            
    }
}
