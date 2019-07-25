﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Figure figure;
    public GameObject tile;
    public Transform gameBoard;
    private GameObject dule;
    public Transform gameFigures;
    private Figure[,] gameState = new Figure[8,8];
    private Ray ray;
    private RaycastHit hit;
    public Figure[] figures = new Figure[12];
    int index;
    private Figure selectedFigure;
    private Figure rayFigure;
    private bool isWhiteTurn = true;
    private Quaternion orientation = Quaternion.Euler(-90, 0, 0);

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Instantiate(tile, new Vector3(i, 0, j), Quaternion.identity, gameBoard);
                dule = gameBoard.transform.GetChild(gameBoard.transform.childCount - 1).gameObject;

                if ((i + j) % 2 == 0)
                {
                    dule.GetComponent<Renderer>().material.color = Color.black;
                }
                else
                {
                    dule.GetComponent<Renderer>().material.color = Color.white;
                }

                //white figures
                if ((i == 0 && j == 0) || (i == 7 && j == 0))
                {
                    CreateFigure(0, i, j);
                }
                else if ((i == 1 && j == 0) || (i == 6 && j == 0))
                {
                    CreateFigure(1, i, j);
                }
                else if ((i == 2 && j == 0) || (i == 5 && j == 0))
                {
                    CreateFigure(2, i, j);
                }
                else if (i == 3 && j == 0)
                {
                    CreateFigure(3, i, j);
                }
                else if (i == 4 && j == 0)
                {
                    CreateFigure(4, i, j);
                }
                else if ((i == 0  && j == 1) || (i == 1 && j == 1) || (i == 2 && j == 1) || (i == 3 && j == 1) || (i == 4 && j == 1) || (i == 5 && j == 1) || (i == 6 && j == 1) || (i == 7 && j == 1))
                {
                    CreateFigure(5, i, j);
                }
                //black figures
                else if ((i == 0 && j == 7) || (i == 7 && j == 7))
                {
                    CreateFigure(6, i, j);
                }
                else if ((i == 1 && j == 7) || (i == 6 && j == 7))
                {
                    CreateFigure(7, i, j);
                }
                else if ((i == 2 && j == 7) || (i == 5 && j == 7))
                {
                    CreateFigure(8, i, j);
                }
                else if (i == 3 && j == 7)
                {
                    CreateFigure(9, i, j);
                }
                else if (i == 4 && j == 7)
                {
                    CreateFigure(10, i, j);
                }
                else if ((i == 0 && j == 6) || (i == 1 && j == 6) || (i == 2 && j == 6) || (i == 3 && j == 6) || (i == 4 && j == 6) || (i == 5 && j == 6) || (i == 6 && j == 6) || (i == 7 && j == 6))
                {
                    CreateFigure(11, i, j);
                }
            }
        }
        //PrintGameState();
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {

            if (selectedFigure == null)
            {
                SelectFigure();
            }
            else
            {
                MoveFigure();
            }
            //IsChess(gameState);
            Debug.Log(selectedFigure);
        }

    }

    public Figure GetWhatIsOnTile(int i, int j)
    {
        return gameState[i, j];
    }

    void CreateFigure(int index, int i, int j)
    {
        Instantiate(figures[index], new Vector3(i, 0, j), orientation, gameFigures);
        gameState[i, j] = gameFigures.GetChild(gameFigures.transform.childCount - 1).GetComponent<Figure>();
    }

    void PrintGameState()
    {
        foreach (var figure in gameState)
        {
            Debug.Log(figure);
        }
    }

    bool SelectFigure()
    {
        rayFigure = hit.collider.gameObject.GetComponent<Figure>();
        if (rayFigure.isWhite == isWhiteTurn)
        {
            selectedFigure = hit.collider.gameObject.GetComponent<Figure>();
            return true;
        }
        else
        {
            return false;
        }
           
        
    }

    void MoveFigure()
    {
        int oldX = Mathf.FloorToInt(selectedFigure.transform.position.x);
        int oldZ = Mathf.FloorToInt(selectedFigure.transform.position.z);
    
        int newX = Mathf.FloorToInt(hit.transform.position.x);
        int newZ = Mathf.FloorToInt(hit.transform.position.z);

        if (selectedFigure.MoveFigure(newX, newZ, hit.transform.position, hit.collider.gameObject.GetComponent<Figure>(), gameState)) {
            isWhiteTurn = !isWhiteTurn;
            //selectedFigure.transform.position = hit.transform.position;
        }
        else
        {
            Debug.Log("illegal move");
        }
        selectedFigure = null;
    }

    //bool IsChess(Figure[,] state)
    //{

    //    // za state proverim da li u tom stejtu neko napada kralja

    //    for (int i = 0; i < 8; i++)
    //    {
    //        for (int j = 0; j < 8; j++)
    //        {
    //           if (state[i, j] != null)
    //            {
    //                // za state[i,j] izracunamo da li napada kralja
    //                foreach (var move in state[i, j].getPossibleMoves() )
    //                {
    //                    // move treba da je [x,y]
    //                    if (isEnemyKing(state[x,y], state[i, j]))
    //                    {
    //                        return [x, y];
    //                    }
    //                }

    //            }

    //        }
    //    }
    //    return false;
    //}

    //bool IsEnemyKing(Figure potentialKing, Figure attacker)
    //{
    //    if (potentialKing != null && attacker != null)
    //    {
    //        if (potentialKing.GetType() == typeof(King) && attacker.isWhite != potentialKing.isWhite)
    //        {
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //bool IsMate(Figure[,] state)
    //{
    //    // uzmi svaku figuru
    //    // probaj svaji possibleMove, za svaki napravi futureState
    //    // setuj isMate na false ako isChess(futureState) == false
    //    // u suprotnom return true
    //    return true;
    //}

}
