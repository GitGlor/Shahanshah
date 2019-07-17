using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Figure
{
    bool[,] possibleMoves = new bool[8, 8];
    
    public override bool move(int destX, int destZ, Vector3 destination, Figure a, Figure[,] gameState)
    {
        int currentX = Mathf.FloorToInt(this.transform.position.x);
        int currentZ = Mathf.FloorToInt(this.transform.position.z);

        //int i;

        ////desno
        //i = currentX;
        //while (true)
        //{
        //    i++;
        //    if (i >= 8)
        //    {
        //        break;
        //    }

        //    if (i == destX && a == null)
        //    {
        //        possibleMoves[destX, currentZ] = true;
        //    }
        //    else
        //    {
        //        if (a != null && a.isWhite != this.isWhite)
        //        {
        //            possibleMoves[destX, currentZ] = true;
        //        }
        //        else
        //        {
        //            break;
        //        }
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

        //    if (i == destX && a == null)
        //    {
        //        possibleMoves[destX, currentZ] = true;
        //    }
        //    else
        //    {
        //        if (a != null && a.isWhite != this.isWhite)
        //        {
        //            possibleMoves[destX, currentZ] = true;
        //        }
        //        else
        //        {
        //            break;
        //        }
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

        //    if (i == destZ && a == null)
        //    {
        //        possibleMoves[currentX, destZ] = true;
        //    }
        //    else
        //    {
        //        if (a != null && a.isWhite != this.isWhite)
        //        {
        //            possibleMoves[currentX, destZ] = true;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //}

        ////nazad
        //i = currentZ;
        //while (true)
        //{
        //    i++;
        //    if (i < 0)
        //    {
        //        break;
        //    }

        //    if (i == destZ && a == null)
        //    {
        //        possibleMoves[currentX, destZ] = true;
        //    }
        //    else
        //    {
        //        if (a != null && a.isWhite != this.isWhite)
        //        {
        //            possibleMoves[currentX, destZ] = true;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //}
        
        //desno
        for (int i = 1; i < 8; i++)
        {
            if (currentX + i >= 8)
            {
                break;
            }

            if (currentX + i == destX && a == null)
            {
                possibleMoves[destX, currentZ] = true;
                Debug.Log(possibleMoves[destX, currentZ]);
            }
            else
            {
                if (a != null && this.isWhite != a.isWhite)
                {
                    possibleMoves[destX, currentZ] = true;
                    Debug.Log(possibleMoves[destX, currentZ]);
                }
                else
                {
                    break;
                }
            }
        }

        //napred
        for (int i = 1; i < 8; i++)
        {
            if (currentZ + i < 0)
            {
                break;
            }

            if (currentZ + i == destZ && a == null)
            {
                possibleMoves[currentX, destZ] = true;
                Debug.Log(possibleMoves[currentX, destZ]);
            }
            else
            {
                if (a != null && this.isWhite != a.isWhite)
                {
                    possibleMoves[currentX, destZ] = true;
                    Debug.Log(possibleMoves[currentX, destZ]);
                }
                else
                {
                    break;
                }
            }
        }

        //levo
        for (int i = 1; i < 8; i++)
        {
            if (currentX - i < 0)
            {
                break;
            }

            if (currentX - i == destX && a == null)
            {
                possibleMoves[destX, currentZ] = true;
                Debug.Log(possibleMoves[destX, currentZ]);
            }
            else
            {
                if (a != null && this.isWhite == a.isWhite)
                {
                    possibleMoves[destX, currentZ] = true;
                    Debug.Log(possibleMoves[destX, currentZ]);
                }
                else
                {
                    break;
                }
            }
        }

        //nazad
        for (int i = 1; i < 8; i++)
        {
            if (currentZ - 1 < 0)
            {
                break;
            }

            if (currentZ - 1 == destZ && a == null)
            {
                possibleMoves[currentX, destZ] = true;
                Debug.Log(possibleMoves[currentX, destZ]);
            }
            else
            {
                if (a != null && this.isWhite == a.isWhite)
                {
                    possibleMoves[currentX, destZ] = true;
                    Debug.Log(possibleMoves[currentX, destZ]);
                }
                else
                {
                    break;
                }
            }
        }

        //for (int k = 1; k < 8; k++)
        //{
        //    if (currentX + k == destX && a == null)
        //    {
        //        possibleMoves[destX, currentZ] = true;
        //        Debug.Log("desno");
        //    }
        //    else if (currentX - k == destX && a == null)
        //    {
        //        possibleMoves[destX, currentZ] = true;
        //        Debug.Log("levo");
        //    }
        //    else if (currentZ + k == destZ && a == null)
        //    {
        //        possibleMoves[currentX, destZ] = true;
        //        Debug.Log("napred");
        //    }
        //    else if (currentZ - k == destZ && a == null)
        //    {
        //        possibleMoves[currentX, destZ] = true;
        //        Debug.Log("nazad");
        //    }
        //}


        if (possibleMoves[destX, destZ])
        {
            this.transform.position = destination;
            gameState[destX, destZ] = this;
            gameState[currentX, currentZ] = null;
        }

        return true;
    }
}
