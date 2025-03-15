using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Mapmanager : MonoBehaviour
{
    [SerializeField] private TextAsset TextAsset;
    public GameObject BoxStartDo;
    public GameObject BoxStartXanhDuong;
    public GameObject BoxStartVang;
    public GameObject BoxStarXanhLa;
    [SerializeField] private GameObject BoxEndVang;
    [SerializeField] private GameObject BoxEndXanhLa;
    [SerializeField] private GameObject BoxEndXanhBien;
    [SerializeField] private GameObject BoxEndDo;
    [SerializeField] private GameObject BoxMove;
    [SerializeField] private GameObject BoxSpoonXanhLa;
    [SerializeField] private GameObject BoxSpoonDo;
    [SerializeField] private GameObject BoxSpoonVang;
    [SerializeField] private GameObject BoxSpoonXanhBien;
    [SerializeField] private GameObject BoxWall;
    [SerializeField] private GameObject Fence;
    [SerializeField] private GameObject Floor;
    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject Groud;
    [SerializeField] private GameObject Image;
    private List<Vector3> locationRed = new List<Vector3>();
    private List<Vector3> locationGreen = new List<Vector3>();
    private List<Vector3> locationBlue = new List<Vector3>();
    private List<Vector3> locationYellow = new List<Vector3>();
    public List<GameObject> hourse = new List<GameObject>();
    private List<GameObject> listhouse = new List<GameObject>();
    private static Dictionary<int, Vector3> keyValuePairs = new Dictionary<int, Vector3>();
    private Vector3 trongluc = Vector3.up;
   


    //Transform[] childObject;
    //public List<Transform> childNodeList = new List<Transform>();

    public static Mapmanager mapmanager { get; private set; }
    private void Awake()
    {
        if (mapmanager == null)
        {
            mapmanager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Genmap();
        CloneHourse();

    }

    public void Genmap()
    {
        string maptext = TextAsset.text;
        string[] textSpilit = maptext.Split("\r\n");

        int row = textSpilit.Length;
        int col = textSpilit[0].Split("-").Length;
        for (int i = 0; i < row; i++)
        {
            string data = textSpilit[i];
            string[] Split = data.Split("-");

            for (int j = 0; j < col; j++)
            {
                int number = int.Parse(Split[j]);
                Vector3 pos = new Vector3(i, 0, j);

                if (number == 0)
                {
                    Instantiate(Fence, pos, Quaternion.identity, this.transform);
                }
                else if (number == 11)
                {
                    Instantiate(BoxStarXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[29] = pos + trongluc;
                }
                else if (number == 12)
                {
                    Instantiate(BoxStartVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[43] = pos + trongluc;

                }
                else if (number == 13)
                {
                    Instantiate(BoxStartDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[1] = pos + trongluc;



                }
                else if (number == 14)
                {
                    Instantiate(BoxStartXanhDuong, pos, Quaternion.identity, this.transform);
                    keyValuePairs[15] = pos + trongluc;
                }

                else if (number == 31)
                {
                    Instantiate(BoxEndXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[28] = pos + trongluc;
                }
                else if (number == 32)
                {
                    Instantiate(BoxEndVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[42] = pos + trongluc;
                }
                else if (number == 33)
                {
                    Instantiate(BoxEndDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[56] = pos + trongluc;

                }
                else if (number == 34)
                {
                    Instantiate(BoxEndXanhBien, pos, Quaternion.identity, this.transform);
                    keyValuePairs[14] = pos + trongluc;
                }
                else if (number == 41)
                {
                    Instantiate(BoxSpoonXanhLa, pos, Quaternion.identity, this.transform);
                    locationGreen.Add(pos);
                }
                else if (number == 42)
                {
                    Instantiate(BoxSpoonVang, pos, Quaternion.identity, this.transform);
                    locationYellow.Add(pos);
                    
                }
                else if (number == 43)
                {
                    Instantiate(BoxSpoonDo, pos, Quaternion.identity, this.transform);
                    locationRed.Add(pos);
                    keyValuePairs[0] = pos + trongluc;
                }
                else if (number == 44)
                {
                    Instantiate(BoxSpoonXanhBien, pos, Quaternion.identity, this.transform);
                    locationBlue.Add(pos);
                }
                else if (number == 1)
                {
                    Instantiate(Floor, pos, Quaternion.identity, this.transform);
                }

                else if (number == 51)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[44] = pos + trongluc;
                }

                else if (number == 52)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[45] = pos + trongluc;
                }
                else if (number == 53)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[46] = pos + trongluc;
                }
                else if (number == 54)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[47] = pos + trongluc;
                }
                else if (number == 55)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[48] = pos + trongluc;
                }
                else if (number == 56)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[49] = pos + trongluc;
                }
                else if (number == 57)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[50] = pos + trongluc;
                }
                else if (number == 58)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[51] = pos + trongluc;
                }
                else if (number == 59)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[52] = pos + trongluc;
                }
                else if (number == 60)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[53] = pos + trongluc;
                }
                else if (number == 61)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[54] = pos + trongluc;
                }

                else if (number == 62)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[55] = pos + trongluc;
                }
                else if (number == 63)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[2] = pos + trongluc;
                }
                else if (number == 64)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[3] = pos + trongluc;

                }
                else if (number == 65)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[4] = pos + trongluc;
                }
                else if (number == 66)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[5] = pos + trongluc;

                }
                else if (number == 67)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[6] = pos + trongluc;
                }
                else if (number == 68)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[7] = pos + trongluc;


                }
                else if (number == 69)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[8] = pos + trongluc;


                }
                else if (number == 70)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[9] = pos + trongluc;

                }
                else if (number == 71)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[10] = pos + trongluc;

                }
                else if (number == 72)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[11] = pos + trongluc;

                }
                else if (number == 73)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[12] = pos + trongluc;

                }

                else if (number == 74)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[13] = pos + trongluc;
                }
                else if (number == 75)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[16] = pos + trongluc;
                }
                else if (number == 76)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[17] = pos + trongluc;
                }

                else if (number == 77)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[18] = pos + trongluc;
                }
                else if (number == 78)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[19] = pos + trongluc;
                }
                else if (number == 79)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[20] = pos + trongluc;
                }
                else if (number == 80)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[21] = pos + trongluc;
                }
                else if (number == 81)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[22] = pos + trongluc;
                }
                else if (number == 82)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[23] = pos + trongluc;
                }
                else if (number == 83)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[24] = pos + trongluc;
                }
                else if (number == 84)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[25] = pos + trongluc;
                }
                else if (number == 85)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[26] = pos + trongluc;
                }
                else if (number == 86)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[27] = pos + trongluc;
                }
                else if (number == 87)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[30] = pos + trongluc;
                }
                else if (number == 88)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[31] = pos + trongluc;
                }
                else if (number == 89)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[32] = pos + trongluc;
                }
                else if (number == 90)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[33] = pos + trongluc;
                }
                else if (number == 91)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[34] = pos + trongluc;
                }
                else if (number == 92)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[35] = pos + trongluc;
                }
                else if (number == 93)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[36] = pos + trongluc;
                }
                else if (number == 94)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[37] = pos + trongluc;
                }
                else if (number == 95)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[38] = pos + trongluc;
                }
                else if (number == 96)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[39] = pos + trongluc;
                }
                else if (number == 97)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[40] = pos + trongluc;
                }
                else if (number == 98)
                {
                    Instantiate(BoxMove, pos, Quaternion.identity, this.transform);
                    keyValuePairs[41] = pos + trongluc;
                }

                else if (number == 331)
                {
                    Instantiate(BoxStartDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[57] = pos + trongluc;

                }
                else if (number == 332)
                {
                    Instantiate(BoxStartDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[58] = pos + trongluc;
                }
                else if (number == 333)
                {
                    Instantiate(BoxStartDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[59] = pos + trongluc;
                }
                else if (number == 334)
                {
                    Instantiate(BoxStartDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[60] = pos + trongluc;
                }
                else if (number == 335)
                {
                    Instantiate(BoxStartDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[61] = pos + trongluc;
                }
                else if (number == 336)
                {
                    Instantiate(BoxStartDo, pos, Quaternion.identity, this.transform);
                    keyValuePairs[62] = pos + trongluc;
                }
                else if (number == 311)
                {
                    Instantiate(BoxStarXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[63] = pos + trongluc;
                }
                else if (number == 312)
                {
                    Instantiate(BoxStarXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[64] = pos + trongluc;
                }
                else if (number == 313)
                {
                    Instantiate(BoxStarXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[65] = pos + trongluc;
                }
                else if (number == 314)
                {
                    Instantiate(BoxStarXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[66] = pos + trongluc;
                }
                else if (number == 315)
                {
                    Instantiate(BoxStarXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[67] = pos + trongluc;
                }
                else if (number == 316)
                {
                    Instantiate(BoxStarXanhLa, pos, Quaternion.identity, this.transform);
                    keyValuePairs[68] = pos + trongluc;
                }
                else if (number == 321)
                {
                    Instantiate(BoxStartVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[69] = pos + trongluc;
                }
                else if (number == 322)
                {
                    Instantiate(BoxStartVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[70] = pos + trongluc;
                }
                else if (number == 323)
                {
                    Instantiate(BoxStartVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[71] = pos + trongluc;
                }
                else if (number == 324)
                {
                    Instantiate(BoxStartVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[72] = pos + trongluc;
                }
                else if (number == 325)
                {
                    Instantiate(BoxStartVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[73] = pos + trongluc;
                }
                else if (number == 326)
                {
                    Instantiate(BoxStartVang, pos, Quaternion.identity, this.transform);
                    keyValuePairs[74] = pos + trongluc;
                }
                else if (number == 341)
                {
                    Instantiate(BoxStartXanhDuong, pos, Quaternion.identity, this.transform);
                    keyValuePairs[75] = pos + trongluc;
                }
                else if (number == 342)
                {
                    Instantiate(BoxStartXanhDuong, pos, Quaternion.identity, this.transform);
                    keyValuePairs[76] = pos + trongluc;
                }
                else if (number == 343)
                {
                    Instantiate(BoxStartXanhDuong, pos, Quaternion.identity, this.transform);
                    keyValuePairs[77] = pos + trongluc;
                }
                else if (number == 344)
                {
                    Instantiate(BoxStartXanhDuong, pos, Quaternion.identity, this.transform);

                    keyValuePairs[78] = pos + trongluc;
                }
                else if (number == 345)
                {
                    Instantiate(BoxStartXanhDuong, pos, Quaternion.identity, this.transform);
                    keyValuePairs[79] = pos + trongluc;
                }
                else if (number == 346)
                {
                    Instantiate(BoxStartXanhDuong, pos, Quaternion.identity, this.transform);

                    keyValuePairs[80] = pos + trongluc;
                }

                else if (number == 7)
                {
                    Instantiate(Groud, pos, Quaternion.identity, this.transform);
                }
                else if (number == 5)
                {
                    Instantiate(Background, pos, Quaternion.identity, this.transform);
                }

            }
        }

        for(int i = 0; i < 1; i++)
        {
            Instantiate(Image , new Vector3(8 , -0.1f, 8) , Quaternion.identity, this.transform);
        }

    }


    private void CloneHourse()
    {
        int soluong = 4 * 4 / hourse.Count;
        for (int i = 0; i < hourse.Count; i++)
        {
            for (int j = 0; j < soluong; j++)
            {
                listhouse.Add(hourse[i]);

            }
        }

        for (int i = 0; i < 4; ++i)
        {
            GameObject a = Instantiate(listhouse[3 - i], locationRed[i] + Vector3.up, Quaternion.identity, this.transform);

        }
        for (int i = 0; i < 4; ++i)
        {
            GameObject a = Instantiate(listhouse[7 - i], locationGreen[i] + Vector3.up, Quaternion.Euler(0, 180, 0), this.transform);


        }
        for (int i = 0; i < 4; i++)
        {
            GameObject a = Instantiate(listhouse[11 - i], locationBlue[i] + Vector3.up, Quaternion.Euler(0, -90, 0), this.transform);
        }

        for (int i = 0; i < 4; i++)
        {
            GameObject a = Instantiate(listhouse[15 - i], locationYellow[i] + Vector3.up, Quaternion.identity, this.transform);

        }


    }
 
    public static Dictionary<int, Vector3> CheckInt()
    {
        return keyValuePairs;
    }
}
    





