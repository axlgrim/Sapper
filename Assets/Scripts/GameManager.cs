using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    static int rows = 9;
    static int columns = 9;
    static int mine_num = 10;
    static float offset_X = 3.5f;
    static float offset_Y = 3.5f;
    public Cell Cell;

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

        
    }
}
