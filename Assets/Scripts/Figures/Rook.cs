using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Figure
{
    public override bool[,] PossibleMoves(Figure[,] gameState)
    {
        bool[,] possibleMoves = new bool[8, 8];

        int currentX = Mathf.FloorToInt(this.transform.position.x);
        int currentZ = Mathf.FloorToInt(this.transform.position.z);

        int i;
        Figure f;

        //desno
        i = currentX;
        while (true)
        {
            i++;
            if (i >= 8)
            {
                break;
            }

            f = gameState[i, currentZ];
            if (f == null)
            {
                possibleMoves[i, currentZ] = true;
            }
            else
            {
                if (f != null && f.isWhite != this.isWhite)
                {
                    possibleMoves[i, currentZ] = true;
                }
                break;
            }
        }

        //levo
        i = currentX;
        while (true)
        {
            i--;
            if (i < 0)
            {
                break;
            }

            f = gameState[i, currentZ];
            if (f == null)
            {
                possibleMoves[i, currentZ] = true;
            }
            else
            {
                if (f != null && f.isWhite != this.isWhite)
                {
                    possibleMoves[i, currentZ] = true;
                }
                break;
            }
        }

        //napred
        i = currentZ;
        while (true)
        {
            i++;
            if (i >= 8)
            {
                break;
            }

            f = gameState[currentX, i];
            if (f == null)
            {
                possibleMoves[currentX, i] = true;
            }
            else
            {
                if (f != null && f.isWhite != this.isWhite)
                {
                    possibleMoves[currentX, i] = true;
                }
                break;
            }
        }

        //nazad
        i = currentZ;
        while (true)
        {
            i--;
            if (i < 0)
            {
                break;
            }

            f = gameState[currentX, i];
            if (f == null)
            {
                possibleMoves[currentX, i] = true;
            }
            else
            {
                if (f != null && f.isWhite != this.isWhite)
                {
                    possibleMoves[currentX, i] = true;
                }
                break;
            }
        }


        return possibleMoves;
    }

    public override bool MoveFigure(int destX, int destZ, Vector3 destination, Figure a, Figure[,] gameState, bool[,] possibleMoves)
    {
        int currentX = Mathf.FloorToInt(this.transform.position.x);
        int currentZ = Mathf.FloorToInt(this.transform.position.z);

        if (possibleMoves[destX, destZ] && a != null && this.isWhite != a.isWhite)
        {
            this.EatFigure(gameState[destX, destZ], gameState);
            this.transform.position = destination;
            gameState[destX, destZ] = this;
            gameState[currentX, currentZ] = null;
        }
        else if (possibleMoves[destX, destZ])
        {
            this.transform.position = destination;
            gameState[destX, destZ] = this;
            gameState[currentX, currentZ] = null;
        }

        return true;
    }


}