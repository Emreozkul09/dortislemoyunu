using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuanManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int toplampuan;
    private int puanartisi;

    [SerializeField]
    private Text puantext;
    void Start()
    {
        puantext.text=toplampuan.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PuanArtir(string zorlukseviyesi)
    {
        switch(zorlukseviyesi)
        {
            case "kolay":
                puanartisi=5;
                break;
            case "orta":
                puanartisi=10;
                break;
            case "zor":
                puanartisi=15;
                break;


        }
        toplampuan+=puanartisi;
        puantext.text=toplampuan.ToString();

    }
}
