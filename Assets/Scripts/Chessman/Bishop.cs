using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] temp = new bool[8, 8];

        Chessman c;
        int i, j;

        //leftUpDiagonal
        i = CurrentX;
        j = CurrentY;
        while(true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if(c==null)
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
            if (i >=8 || j < 0)
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