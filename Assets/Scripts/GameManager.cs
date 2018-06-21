using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    static int rows = 9;
    static int columns = 9;
    static int mine_num = 15;
    static float offset_X = 3.5f;
    static float offset_Y = 3.5f;
    public Cell Cell;
    public bool isOver = false;

    static Cell[,] CellArray = new Cell[rows,columns];

    // Use this for initialization
	void Awake () 
    {
        Vector3 start_pos = Cell.transform.position;



        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                
                if (0 == i && 0 == j)
                {
                    CellArray[i,j] = Cell;
                }
                else
                {
                    CellArray[i,j] = Instantiate(Cell) as Cell;

                }

                float pos_X = (offset_X * i) + start_pos.x;
                float pos_Y = (offset_Y * j) + start_pos.y;
                CellArray[i,j].x_id = i;
                CellArray[i,j].y_id = j;

                CellArray[i,j].transform.position = new Vector3(pos_X, pos_Y, 0f);

            }
        }


		
	}

    void Start()
    {
        assignMines();
    }

    // Update is called once per frame
    void Update () 
    {
		
	}

    void assignMines()
    {
        int i;
        int j;
        int cnt = 0;

        while(cnt <= mine_num )
        {
            i = Random.Range(0, 9);
            j = Random.Range(0, 9);

            if (!CellArray[i, j].isMine)
            {
                CellArray[i, j].isMine = true;
                cnt++;
            }
            
        }

        checkForNumber();
    }

    public void checkCellsAround(Cell openedCell)
    {
        int i = openedCell.x_id;
        int j = openedCell.y_id;
        if (i + 1 < 8 && !CellArray[i + 1, j].isMine && !CellArray[i + 1, j].isChecked )
        {
            CellArray[i + 1, j].ChangeSprite();
            CellArray[i + 1, j].isChecked = true;
            checkCellsAround(CellArray[i + 1, j]);
        }
        if (i - 1 > 0 && !CellArray[i - 1, j].isMine && !CellArray[i-1, j].isChecked)
        {
            CellArray[i - 1, j].ChangeSprite();
            CellArray[i - 1, j].isChecked = true;
            checkCellsAround(CellArray[i - 1, j]);
        }
        if (j + 1 < 8 && !CellArray[i, j+1].isMine && !CellArray[i, j+1].isChecked)
        {
            CellArray[i, j + 1].ChangeSprite();
            CellArray[i, j + 1].isChecked = true;
            checkCellsAround(CellArray[i, j+1]);
        }
        if (j - 1 > 0 && !CellArray[i, j - 1].isMine && !CellArray[i, j - 1].isChecked )
        {
            CellArray[i, j - 1].ChangeSprite();
            CellArray[i, j - 1].isChecked = true;
            checkCellsAround(CellArray[i, j - 1]);
        }

    }
    void checkCell(Cell openedCell)
    {
        if(!openedCell.isMine)
        {
            openedCell.ChangeSprite();
        }
    }

    public void gameOver()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if(CellArray[i, j].isMine)
                {
                    CellArray[i, j].SpriteRend.sprite = CellArray[i, j].Mine;
                    
                }
                
            }
        }
        isOver = true;
    }

    void checkForNumber()
    {
        int mine_cnt;
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                mine_cnt = 0;

                if(i == 0 && j == 0 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j+1].isMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == 8 && j == 8 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == 0 && j == 8 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == 8 && j == 0 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == 8 && j == 8 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i != 0 && j == 0 && i!= 8 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j+1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j].isMine)
                    {
                        mine_cnt++;
                    }

                }
                if (i == 0 && j != 0 &&  j != 8 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i+1, j].isMine)
                    {
                        mine_cnt++;
                    }

                }
                if (i != 0 && j != 0 && i != 8 && j != 8 && !CellArray[i, j].isMine)
                {
                    if (CellArray[i, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j+1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i - 1, j - 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j + 1].isMine)
                    {
                        mine_cnt++;
                    }
                    if (CellArray[i + 1, j - 1].isMine)
                    {
                        mine_cnt++;
                    }

                }

                CellArray[i, j].num_of_Mines = mine_cnt;

            }

        }
    }
}
