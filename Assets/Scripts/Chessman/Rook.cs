using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] temp = new bool[8, 8];
        Chessman c;
        int i;


        //Right
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)
                break;

            c = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c == null)
            {
                temp[i, CurrentY] = true;
            }
            else
            {
                if(c.isWhite != isWhite)
                {
                    temp[i, CurrentY] = true;
                }

                break;
            }
        }

        //left
        i = CurrentX;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c == null)
            {
                temp[i, CurrentY] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    temp[i, CurrentY] = true;
                }

                break;
            }
        }

        //up
        i = CurrentY;
        while (true)
        {
            i++;
            if (i >= 8)
                break;

            c = BoardManager.Instance.Chessmans[CurrentX, i];
            if (c == null)
            {
                temp[CurrentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    temp[CurrentX, i] = true;
                }

                break;
            }
        }

        //down
        i = CurrentY;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = BoardManager.Instance.Chessmans[CurrentX, i];
            if (c == null)
            {
                temp[CurrentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    temp[CurrentX, i] = true;
                }

                break;
            }
        }
        return temp;

    }
}
