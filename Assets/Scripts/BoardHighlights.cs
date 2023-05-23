using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BoardHighlights : MonoBehaviour
{
    public static BoardHighlights Instance{set;get;}
    public GameObject highlightprefab;
    List<GameObject> _highlights;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _highlights = new List<GameObject>();    
    }


    GameObject GetHighlightObject()
    {
        GameObject go = _highlights.Find(g => !g.activeSelf);
        if(go==null)
        {
            go = Instantiate(highlightprefab);
            _highlights.Add(go);
        }
        return go;
    }

    public void HighlightAllowedMoves(bool[,] moves)
    {
        for(int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (moves[i, j])
                {
                    GameObject go = GetHighlightObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i+0.525f, 0, j+0.525f);
                }
            }
        }
    }

    public void HideHighlights()
    {
        foreach (GameObject go in _highlights)
        {
            go.SetActive(false);
        }
    }
}
