using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] temp = new bool[8, 8];

        Chessman c;
        int i,j;


        //UpSide //3UpTile
        i = CurrentX - 1;
        j = CurrentY + 1;

        if (CurrentY != 7)
        {
            for(int k = 0; k < 3; k++)
            {
                if(i>=0 || i<8)
                {
                    c = BoardManager.Instance.Chessmans[i, j];
                    if (c == null)
                    {

                        temp[i, j] = true;
                    }
                    else if(isWhite != c.isWhite)
                    {
                        temp[i, j] = true;
                    }
                    i++;
                   
                }
            }
        }

        //DownSide //3DownTile
        i = CurrentX - 1;
        j = CurrentY - 1;

        if (CurrentY != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 || i < 8)
                {
                    c = BoardManager.Instance.Chessmans[i, j];
                    if (c == null)
                    {

                        temp[i, j] = true;
                    }
                    else if (isWhite != c.isWhite)
                    {
                        temp[i, j] = true;
                    }
                    i++;

                }
            }
        }


        //left
        if (CurrentX != 0)
        {
            c = BoardManager.Instance.Chessmans[CurrentX-1, CurrentY];
            if (c == null)
            {
                temp[CurrentX - 1, CurrentY]=true;
            }else if(c.isWhite != isWhite)
            {
                temp[CurrentX - 1, CurrentY] = true;
            }
        }
        //Right
        if (CurrentX != 7)
        {
            c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY];
            if (c == null)
            {
                temp[CurrentX + 1, CurrentY] = true;
            }
            else if (c.isWhite != isWhite)
            {
                temp[CurrentX + 1, CurrentY] = true;
            }
        }

        return temp;
    }

}
