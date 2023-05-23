using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] temp = new bool[8,8];
        Chessman c, c2;
        if (isWhite)
        {
            if(CurrentX!=0 && CurrentY != 7)
            {
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                {
                    temp[CurrentX - 1, CurrentY + 1]=true;
                }
            }
            if (CurrentX != 7 && CurrentY != 7)
            {
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                {
                    temp[CurrentX + 1, CurrentY + 1] = true;
                }
            }

            if (CurrentY != 7)
            {
                c= BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                {
                    temp[CurrentX, CurrentY + 1]=true;
                }
            }
            if (CurrentY == 1)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 2];
                if (c == null && c2==null)
                {
                    temp[CurrentX, CurrentY + 2] = true;
                }
            }
        }
        else
        {
            if (CurrentX != 0 && CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite)
                {
                    temp[CurrentX - 1, CurrentY - 1] = true;
                }
            }
            if (CurrentX != 7 && CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY -1];
                if (c != null && c.isWhite)
                {
                    temp[CurrentX + 1, CurrentY - 1] = true;
                }
            }

            if (CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                {
                    temp[CurrentX, CurrentY - 1] = true;
                }
            }
            if (CurrentY == 6)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 2];
                if (c == null && c2 == null)
                {
                    temp[CurrentX, CurrentY - 2] = true;
                }
            }
        }
        return temp;

    }
}
