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

    public bool IsMine = false;
    public bool IsFlag = false;
    public bool IsChecked = false;


    // Use this for initialization
    void Start ()
    {
        SpriteRend.sprite = Back;
    }

    void OnMouseUp()
    {
        if (!Manager.IsOver && !Manager.IsPaused)
        {
            IsChecked = true;
            ChangeSprite();
            if (!this.IsMine)
            {
                Manager.CheckCellsAround(this);
            }

        }
        if (Input.GetMouseButtonDown(2))
        {

            if (!IsChecked && !Manager.IsOver && !IsFlag)
            {
                SpriteRend.sprite = BackFlag;
                IsFlag = true;
            }
            if (!IsChecked && !Manager.IsOver && IsFlag)
            {
                SpriteRend.sprite = Back;
                IsFlag = false;
            }
        }

    }
	

    public void ChangeSprite()
    {
        if(!IsMine)
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

            Manager.OpenedCells++;
            

        }
        else
        {
            Manager.GameOver();
            Manager.IsOver = true;
        }

        //Instantiate(Effect, transform.position, transform.rotation);
            
    }
}
