using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapmanager : MonoBehaviour
{
    public List<GameObject> prefListBrick = new List<GameObject>();
    private int col = 10;
    private int row = 10;
    public float r1 = 1;
    private List<GameObject> listBrick = new List<GameObject>();
    public static Mapmanager mapmanager { get; private set; }
    
    void Start()
    {
        int soluong = col * row / prefListBrick.Count;

        for (int i = 0; i < prefListBrick.Count; i++)
        {

            for (int j = 0; j < soluong; j++)
            {

                listBrick.Add(prefListBrick[i]);
            }
        }
        Soft();
        Genmap();

    }
    private void Update()
    {
      
    }

    public void Genmap()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //Instantiate(listBrick[i * 10 + j], new Vector3(i, 0.1f, j), Quaternion.identity, this.transform);
                GameObject a = Instantiate(listBrick[i * 10 + j]);
                a.transform.localPosition = new Vector3(i - (r1 * 5) + 0.5f, 0.1f, j - (r1 * 5) + 0.5f);
                a.transform.parent = gameObject.transform;
                a.transform.localScale = Vector3.one * 0.2f;

            }
        }
        
    }
    private void Soft()
    {
        for (int i = 0; i < listBrick.Count; i++)
        {
            int tron = Random.Range(0, 99);
            GameObject tmp = listBrick[i];
            listBrick[i] = listBrick[tron];
            listBrick[tron] = tmp;

        }
    }
}
