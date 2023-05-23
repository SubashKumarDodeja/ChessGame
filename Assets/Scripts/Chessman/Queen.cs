using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] temp = new bool[8, 8];

        Chessman c;
        int i, j;


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
                if (c.isWhite != isWhite)
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




        //leftUpDiagonal
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                temp[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {

                    temp[i, j] = true;
                }
                break;

            }
        }

        //rightUpDiagonal
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j >= 8)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                temp[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {

                    temp[i, j] = true;

                }
                break;
            }
        }



        //leftDownDiagonal
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                temp[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {

                    temp[i, j] = true;

                }
                break;
            }
        }

        //rightDownDiagonal
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >= 8 || j < 0)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                temp[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {

                    temp[i, j] = true;

                }
                break;
            }
        }
        return temp;
    }

   
}

