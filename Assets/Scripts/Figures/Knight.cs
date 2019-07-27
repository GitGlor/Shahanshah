using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Figure
{
    //public override bool MoveFigure(int destX, int destZ, Vector3 destination, Figure a, Figure[,] gameState)
    //{
    //    bool[,] possibleMoves = new bool[8, 8];

    //    int currentX = Mathf.FloorToInt(this.transform.position.x);
    //    int currentZ = Mathf.FloorToInt(this.transform.position.z);

    //    Figure f;

    //    if (gameState[currentX + 1, currentZ + 2] == null)
    //    {
    //        possibleMoves[currentX + 1, currentZ + 2] = true;
    //    }

    //    if (possibleMoves[destX, destZ] && a != null && this.isWhite != a.isWhite)
    //    {
    //        this.EatFigure(gameState[destX, destZ], gameState);
    //        this.transform.position = destination;
    //        gameState[destX, destZ] = this;
    //        gameState[currentX, currentZ] = null;
    //    }
    //    else if (possibleMoves[destX, destZ])
    //    {
    //        this.transform.position = destination;
    //        gameState[destX, destZ] = this;
    //        gameState[currentX, currentZ] = null;
    //    }

    //    return true;
    //}

    //void KnightMove(int x, int z)
    //{
    //    if (x > 8 || x < 0 || z > 8 || z < 0 )
    //    {

    //    }

    //}
}
