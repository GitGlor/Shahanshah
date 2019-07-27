using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Figure : MonoBehaviour
{
    public bool isWhite;

    public virtual bool[,] PossibleMoves(Figure[,] gameState)
    {

        return new bool[8, 8];
    }

    public virtual bool MoveFigure(int i, int j, Vector3 destination, Figure a, Figure[,] gameState, bool[,] possibleMoves)
    {
        return true;
    }

    public virtual bool EatFigure(Figure prey, Figure[,] gameState)
    {
        if (prey != null)
        {
            Debug.Log(prey);
            Destroy(prey.gameObject);
            gameState[Mathf.FloorToInt(prey.transform.position.x), Mathf.FloorToInt(prey.transform.position.z)] = this;
        }
        return true;
    }
}