using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { set; get; }

    const float Tile_Size = 1.0f;
    const float Tile_Offset = 0.5f;
    int _selectionX = -1;
    int _selectionY = -1;
    Chessman _selectedChessman;
    bool[,] allowedMoves { set; get; }

    public List<GameObject> chessmanPrefabs;
    public Chessman[,] Chessmans { set; get; }
    public bool isWhiteTurn = true;
     List<GameObject> _activeChessman = new List<GameObject>();

    void Awake()
    {
        Instance = this;    
    }
    void Start()
    {
        SpawnAllChessman();
    }
    void Update()
    {
        UpdateSelection();
        DrawChessBoard();
        if (Input.GetMouseButtonDown(0))
        {
            if(_selectionX >=0 && _selectionY >= 0)
            {
                if (_selectedChessman == null)
                {
                    SelectChessman(_selectionX, _selectionY);
                }
                else
                {
                    MoveChessman(_selectionX, _selectionY);
                }
            }
        }
    }

    void SelectChessman(int x,int y)
    {
        if (Chessmans[x, y] == null)
            return;

        if (Chessmans[x, y].isWhite != isWhiteTurn)
            return;

        
        allowedMoves = Chessmans[x, y].PossibleMove();
        bool hasOnePossibleMove = false;

        foreach(bool b in allowedMoves)
        {
            if (b)
            {
                hasOnePossibleMove = true;
                break;
            }
        }
        if (!hasOnePossibleMove)
            return;

        _selectedChessman = Chessmans[x, y];
        BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves); 
    }
    void MoveChessman(int x, int y)
    {
        if (allowedMoves[x,y])
        {
            Chessman c = Chessmans[x, y];
            if(c!=null && c.isWhite != isWhiteTurn)
            {
                if (c.GetType() == typeof(King))
                {
                    Endgame();
                }
                //captured
                _activeChessman.Remove(c.gameObject);
                Destroy(c.gameObject);
            }

            Chessmans[_selectedChessman.CurrentX, _selectedChessman.CurrentY] = null;
            _selectedChessman.transform.position = GetTileCenter(x, y);

            _selectedChessman.SetPosition(x, y);
            Chessmans[x, y] = _selectedChessman;
            isWhiteTurn = !isWhiteTurn;
        }
        _selectedChessman = null;
        BoardHighlights.Instance.HideHighlights();
    }
    void Endgame()
    {
        if(isWhiteTurn)
            Debug.Log("white Win");
        else
            Debug.Log("black Win");

        foreach(GameObject go in _activeChessman)
        {
            Destroy(go);
        }

        isWhiteTurn = false ;
        BoardHighlights.Instance.HideHighlights();
        SpawnAllChessman();

    }
    void UpdateSelection()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 30.0f,LayerMask.GetMask("ChessPlane")))
        {
            _selectionX = (int)hit.point.x;
            _selectionY = (int)hit.point.z;
           
        }
        else
        {
            _selectionX = -1;
            _selectionY = -1;
        }
    }

    void DrawChessBoard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;

        for(int i=0;i <=8;i++)
        {
            Vector3 start = Vector3.forward * i;

            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }


        if(_selectionX>=0 && _selectionY >= 0)
        {
            Debug.DrawLine(Vector3.forward * _selectionY + Vector3.right * _selectionX,
                Vector3.forward * (_selectionY + 1) + Vector3.right * (_selectionX + 1));
            
            Debug.DrawLine(Vector3.forward * (_selectionY + 1) + Vector3.right * (_selectionX ),
                Vector3.forward * _selectionY + Vector3.right * (_selectionX + 1));

        }
    }



    void SpawnChessman(int index, int x,int y)
    {
        GameObject go = Instantiate(chessmanPrefabs[index], GetTileCenter(x,y), Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        Chessmans[x, y] = go.GetComponent<Chessman>();
        Chessmans[x, y].SetPosition(x, y);
        _activeChessman.Add(go);

    }

    Vector3 GetTileCenter(int x,int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (Tile_Size * x) + Tile_Offset;
        origin.z += (Tile_Size * y) + Tile_Offset;
        return origin;

    }

    void SpawnAllChessman()
    {
        _activeChessman = new List<GameObject>();
        Chessmans = new Chessman[8, 8];
        
        //white 

        SpawnChessman(0, 3, 0);// King
        SpawnChessman(1, 4, 0);// Queen
        
        SpawnChessman(2, 0, 0);// LeftRook
        SpawnChessman(2, 7, 0);// RightRook

        SpawnChessman(3, 2, 0);// LeftBishop
        SpawnChessman(3, 5, 0);// RightBishop
         
        SpawnChessman(4, 1, 0);// LeftKnight
        SpawnChessman(4, 6, 0);// RightKnight

        for(int i=0;i<=7;i++)
            SpawnChessman(5, i, 1);// Pawn


        //black
        SpawnChessman(6, 4, 7);// King
        SpawnChessman(7, 3, 7);// Queen

        SpawnChessman(8, 0, 7);// LeftRook
        SpawnChessman(8, 7, 7);// RightRook

        SpawnChessman(9, 2, 7);// LeftBishop
        SpawnChessman(9, 5, 7);// RightBishop

        SpawnChessman(10,1, 7);// LeftKnight
        SpawnChessman(10, 6, 7);// RightKnight

        for (int i = 0; i <= 7; i++)
            SpawnChessman(11, i, 6);// Pawn



    }
}
