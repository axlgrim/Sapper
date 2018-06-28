
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private int _rows = 9;
    private int _columns = 9;
    public int Mine_num = 15;
    static float offset_X = 3.5f;
    static float offset_Y = 3.5f;
    public Cell Cell;
    public bool IsOver = false;
    public int OpenedCells = 0;
    public int TotalCells = 81;
    public bool IsPaused = false;

    private Cell[,] _cellArray;

    // Use this for initialization
	void Awake () 
    {
        CheckResources();
        Vector3 start_pos = Cell.transform.position;
        _cellArray = new Cell[_columns, _rows];
        TotalCells = _rows * _columns;


        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                
                if (0 == i && 0 == j)
                {
                    _cellArray[i,j] = Cell;
                }
                else
                {
                    _cellArray[i,j] = Instantiate(Cell) as Cell;

                }

                float pos_X = (offset_X * i) + start_pos.x;
                float pos_Y = (offset_Y * j) + start_pos.y;
                _cellArray[i,j].x_id = i;
                _cellArray[i,j].y_id = j;

                _cellArray[i,j].transform.position = new Vector3(pos_X, pos_Y, 0f);


            }
        }

        AssignMines();
		
	}

    void AssignMines()
    {
        int i = 0;
        int j = 0;
        int cnt = 0;
        do
        {
            _cellArray[i, j].IsMine = true;
            cnt++;

            if (j < _rows)
            {
                j++;
            }

            if (j == _rows)
            {
                j = 0;
                i++;
            }
        }
        while (cnt < Mine_num);
        RandomShuffle();

        CheckForNumber();
    }

    public void CheckCellsAround(Cell openedCell)
    {
        int i = openedCell.x_id;
        int j = openedCell.y_id;
        if (i + 1 < _columns-1 && !_cellArray[i + 1, j].IsMine && !_cellArray[i + 1, j].IsChecked )
        {
            _cellArray[i + 1, j].ChangeSprite();
            _cellArray[i + 1, j].IsChecked = true;
            CheckCellsAround(_cellArray[i + 1, j]);
        }
        if (i - 1 > 0 && !_cellArray[i - 1, j].IsMine && !_cellArray[i-1, j].IsChecked)
        {
            _cellArray[i - 1, j].ChangeSprite();
            _cellArray[i - 1, j].IsChecked = true;
            CheckCellsAround(_cellArray[i - 1, j]);
        }
        if (j + 1 < _rows-1 && !_cellArray[i, j+1].IsMine && !_cellArray[i, j+1].IsChecked)
        {
            _cellArray[i, j + 1].ChangeSprite();
            _cellArray[i, j + 1].IsChecked = true;
            CheckCellsAround(_cellArray[i, j+1]);
        }
        if (j - 1 > 0 && !_cellArray[i, j - 1].IsMine && !_cellArray[i, j - 1].IsChecked )
        {
            _cellArray[i, j - 1].ChangeSprite();
            _cellArray[i, j - 1].IsChecked = true;
            CheckCellsAround(_cellArray[i, j - 1]);
        }

    }
    void CheckCell(Cell openedCell, int i, int j)
    {
        _cellArray[i + 1, j].ChangeSprite();
        _cellArray[i + 1, j].IsChecked = true;
    }

    public void GameOver()
    {
        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                if(_cellArray[i, j].IsMine)
                {
                    _cellArray[i, j].SpriteRend.sprite = _cellArray[i, j].Mine;
                    
                }
                
            }
        }
        IsOver = true;
    }

    void CheckForNumber()
    {
        int mine_cnt;
        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                mine_cnt = 0;

                if(i == 0 && j == 0 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j+1].IsMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == _columns-1 && j == _rows-1 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == 0 && j == _rows-1 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == _columns-1 && j == 0 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i == _columns-1 && j == _rows-1 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                }
                if (i != 0 && j == 0 && i!= _columns-1 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j+1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j].IsMine)
                    {
                        mine_cnt++;
                    }

                }
                if (i == 0 && j != 0 &&  j != _rows-1 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i+1, j].IsMine)
                    {
                        mine_cnt++;
                    }

                }
                if (i != 0 && j != 0 && i != _columns-1 && j != _rows-1 && !_cellArray[i, j].IsMine)
                {
                    if (_cellArray[i, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j+1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i - 1, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j + 1].IsMine)
                    {
                        mine_cnt++;
                    }
                    if (_cellArray[i + 1, j - 1].IsMine)
                    {
                        mine_cnt++;
                    }

                }

                _cellArray[i, j].num_of_Mines = mine_cnt;

            }

        }
    }

    void RandomShuffle()
    {
        bool mine = false;
        int rand_i;
        int rand_j;
        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                mine = _cellArray[i, j].IsMine;
                rand_i = Random.Range(0, _columns);
                rand_j = Random.Range(0, _rows);
                _cellArray[i, j].IsMine = _cellArray[rand_i, rand_j].IsMine;
                _cellArray[rand_i, rand_j].IsMine =  mine;

            }
        }

    }

    void CheckResources()
    {
        var textAsset = Resources.Load<TextAsset>("Config");
        char[] Delimeters = new char[] {'\n', '\r'};
        string[] parameters = textAsset.text. Split(Delimeters, System.StringSplitOptions.RemoveEmptyEntries);
        _rows = System.Convert.ToInt16(parameters[0]);
        _columns = System.Convert.ToInt16(parameters[1]);
        Mine_num = System.Convert.ToInt16(parameters[2]);
    }

}
