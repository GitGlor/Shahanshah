using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Figure : MonoBehaviour
{
    public bool isWhite;

    public virtual bool move(int i, int j, Vector3 destination, Figure a,  Figure[,] gameState)
    {
  
        return true;
    }

    public virtual bool Eat( Figure pray,  Figure[,] gameState)
    {
        if (pray != null)
        {
            Debug.Log(pray);
            Destroy(pray.gameObject);
            gameState[Mathf.FloorToInt(pray.transform.position.x), Mathf.FloorToInt(pray.transform.position.z)] = this;
        }
        return true;
    }
}
