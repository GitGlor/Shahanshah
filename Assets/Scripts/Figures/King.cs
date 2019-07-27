﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Figure
{
    public override bool[,] PossibleMoves(Figure[,] gameState)
    {
        bool[,] possibleMoves = new bool[8, 8];

        int currentX = Mathf.FloorToInt(this.transform.position.x);
        int currentZ = Mathf.FloorToInt(this.transform.position.z);

        Figure f;
        int i, j;

        // Top

        i = currentX - 1;
        j = currentZ + 1;
        if (currentZ < 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    f = gameState[i, j];
                    if (f == null) possibleMoves[i, j] = true;
                    else if (f.isWhite != isWhite) possibleMoves[i, j] = true;
                }
                i++;
            }
        }

        // Bottom

        i = currentX - 1;
        j = currentZ - 1;
        if (currentZ > 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    f = gameState[i, j];
                    if (f == null) possibleMoves[i, j] = true;
                    else if (f.isWhite != isWhite) possibleMoves[i, j] = true;
                }
                i++;
            }
        }

        // Left

        if (currentX > 0)
        {
            f = gameState[currentX - 1, currentZ];
            if (f == null) possibleMoves[currentX - 1, currentZ] = true;
            else if (f.isWhite != isWhite) possibleMoves[currentX - 1, currentZ] = true;
        }

        // Right

        if (currentX < 7)
        {
            f = gameState[currentX + 1, currentZ];
            if (f == null) possibleMoves[currentX + 1, currentZ] = true;
            else if (f.isWhite != isWhite) possibleMoves[currentX + 1, currentZ] = true;
        }

        return possibleMoves;

        //bool[,] possibleMoves = new bool[8, 8];

        //int currentX = Mathf.FloorToInt(this.transform.position.x);
        //int currentZ = Mathf.FloorToInt(this.transform.position.z);

        //int i;
        //int j;
        //Figure f;

        ////napred desno
        //i = currentX;
        //j = currentZ;
        //while (i == currentX + 1 && j == currentZ + 1)
        //{
        //    i++;
        //    j++;
        //    if (i >= 8 || j >= 8)
        //    {
        //        break;
        //    }

        //    f = gameState[i, j];
        //    if (f == null)
        //    {
        //        possibleMoves[i, j] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[i, j] = true;
        //        }
        //        break;
        //    }
        //}

        ////napred levo
        //i = currentX;
        //j = currentZ;
        //while (true)
        //{
        //    i--;
        //    j++;
        //    if (i < 0 || j >= 8)
        //    {
        //        break;
        //    }

        //    f = gameState[i, j];
        //    if (f == null)
        //    {
        //        possibleMoves[i, j] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[i, j] = true;
        //        }
        //        break;
        //    }
        //}

        ////nazad desno
        //i = currentX;
        //j = currentZ;
        //while (true)
        //{
        //    i++;
        //    j--;
        //    if (i >= 8 || j < 0)
        //    {
        //        break;
        //    }

        //    f = gameState[i, j];
        //    if (f == null)
        //    {
        //        possibleMoves[i, j] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[i, j] = true;
        //        }
        //        break;
        //    }
        //}

        ////nazad levo
        //i = currentX;
        //j = currentZ;
        //while (true)
        //{
        //    i--;
        //    j--;
        //    if (i < 0 || j < 0)
        //    {
        //        break;
        //    }

        //    f = gameState[i, j];
        //    if (f == null)
        //    {
        //        possibleMoves[i, j] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[i, j] = true;
        //        }
        //        break;
        //    }
        //}

        ////desno
        //i = currentX;
        //while (true)
        //{
        //    i++;
        //    if (i >= 8)
        //    {
        //        break;
        //    }

        //    f = gameState[i, currentZ];
        //    if (f == null)
        //    {
        //        possibleMoves[i, currentZ] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[i, currentZ] = true;
        //        }
        //        break;
        //    }
        //}

        ////levo
        //i = currentX;
        //while (true)
        //{
        //    i--;
        //    if (i < 0)
        //    {
        //        break;
        //    }

        //    f = gameState[i, currentZ];
        //    if (f == null)
        //    {
        //        possibleMoves[i, currentZ] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[i, currentZ] = true;
        //        }
        //        break;
        //    }
        //}

        ////napred
        //i = currentZ;
        //while (true)
        //{
        //    i++;
        //    if (i >= 8)
        //    {
        //        break;
        //    }

        //    f = gameState[currentX, i];
        //    if (f == null)
        //    {
        //        possibleMoves[currentX, i] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[currentX, i] = true;
        //        }
        //        break;
        //    }
        //}

        ////nazad
        //i = currentZ;
        //while (true)
        //{
        //    i--;
        //    if (i < 0)
        //    {
        //        break;
        //    }

        //    f = gameState[currentX, i];
        //    if (f == null)
        //    {
        //        possibleMoves[currentX, i] = true;
        //    }
        //    else
        //    {
        //        if (f != null && f.isWhite != this.isWhite)
        //        {
        //            possibleMoves[currentX, i] = true;
        //        }
        //        break;
        //    }
        //}


        //return possibleMoves;
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
