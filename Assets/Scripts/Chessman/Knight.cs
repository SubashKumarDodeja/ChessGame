using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Chessman
{


    public override bool[,] PossibleMove()
    {
        bool[,] temp = new bool[8, 8];

        //upLeft
        KnightMove(CurrentX - 1, CurrentY +2,temp);
        //upRight
        KnightMove(CurrentX +1, CurrentY + 2, temp);

        //RightUp
        KnightMove(CurrentX + 2, CurrentY + 1, temp);
        //RightDown
        KnightMove(CurrentX + 2, CurrentY - 1, temp);

        //LeftUp
        KnightMove(CurrentX - 2, CurrentY + 1, temp);
        //LeftDown
        KnightMove(CurrentX - 2, CurrentY - 1, temp);


        //DownLeft
        KnightMove(CurrentX - 1, CurrentY - 2, temp);
        //DownRight
         KnightMove(CurrentX + 1, CurrentY - 2, temp);

        return temp;
    }

    public void KnightMove(int x, int y, bool[,] temp)
    {
        Chessman c;
        if(x>=0 && x < 8 && y >= 0 && y < 8)
        {
            c = BoardManager.Instance.Chessmans[x, y];
            if (c == null)
            {
                temp[x, y] = true;
            } else if(c.isWhite != isWhite)
            {
                temp[x, y] = true;
            }
        }
    }
}
