using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] TextAsset textAsset;
    [SerializeField] private GameObject brickStart;
    [SerializeField] private GameObject brickGoal;
    [SerializeField] private GameObject brickAdd;
    [SerializeField] private GameObject brickRemove;



    private Vector3 posStart;
    private Vector3 posEnd;

    private int[,] mapGrid;

    public static MapManager mapManager { get; private set; } // Singleton

    private void Awake()
    {
        if (mapManager == null)
        {
            mapManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenMap();
    }

    internal void GenMap()
    {
       
        // Read text file
        string mapText = textAsset.text;
       
        string[] data = mapText.Split("\r\n");

        mapGrid = new int[data.Length, data[0].Length];

        for (int i = 0; i < data.Length; i++)
        {
            string dataSplited = data[i];
            
            for (int j = 0; j < dataSplited.Length; j++)
            {
                int dataIndex = int.Parse(dataSplited[j].ToString());
                mapGrid[i, j] = dataIndex;

                Vector3 pos = new Vector3(i, 0, j);

                if (dataIndex == 1) // Start
                {
                    Instantiate(brickStart, pos, Quaternion.identity);
                    posStart = pos;
                }
                else if (dataIndex == 2) // Add
                {
                    Instantiate(brickAdd, pos, Quaternion.identity);
                }
                else if (dataIndex == 3) // Remove
                {
                    Instantiate(brickRemove, pos, Quaternion.identity);
                }
                else if (dataIndex == 4) // End
                {
                    Instantiate(brickGoal, pos, Quaternion.identity);
                    posEnd = pos;
                }
            }
        }
        Character.character.transform.position = posStart + Vector3.up;
    }
    internal void NextMap()
    {
        GenMap();
    }

    public int GetTileValue(int x, int y)
    {
        if (x >= 0 && x < mapGrid.GetLength(0) && y >= 0 && y < mapGrid.GetLength(1))
        {
            return mapGrid[x, y];
        }
        return -1;
    }
}
