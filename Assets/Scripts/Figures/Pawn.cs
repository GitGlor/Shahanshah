using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Figure
{
    public override bool move(int destX, int destZ, Vector3 destination, Figure a, Figure[,] gameState)
    {
        int currentX = Mathf.FloorToInt(this.transform.position.x);
        int currentZ = Mathf.FloorToInt(this.transform.position.z);
        int step = this.isWhite == true ? 1 : -1;

        if ((currentX + 1 == destX || currentX - 1 == destX) && currentZ + step == destZ && a != null && a.isWhite != this.isWhite)
        {
            Debug.Log("jedem");
            this.Eat(a, gameState);
            this.transform.position = destination;
            gameState[destX, destZ] = this;
            gameState[currentX, currentZ] = null;
            return true;
        }
        else
        {
            if (currentX == destX && currentZ + step == destZ && a == null)
            {
                Debug.Log("idem za jedan");
                this.transform.position = destination;
                gameState[destX, destZ] = this;
                gameState[currentX, currentZ] = null;
                return true;
            }
            else
            {
                Debug.Log("ne moze bre");
                return false;
            }


        }

    }
}
