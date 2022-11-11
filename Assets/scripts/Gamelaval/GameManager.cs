using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject kareprefab;

    [SerializeField]
    public Transform karelerpaneli;
    [SerializeField]
    public Transform sorupaneli;
    [SerializeField]
    private Text sorutext;
    [SerializeField]
    private Sprite[] karesprites;
    [SerializeField]
    private GameObject sonucpaneli;

    List<int> bolumdegerlerilistesi=new List<int>();
    int bolunensayi,bolensayi;
    int kacincisoru;
    int butondegeri;
    bool butonabasıldımı;
    int dogrusonuc;
    int kalanHak;
    string sorununZorlukDerecesi;

    GameObject gecerlikare;
    


    public GameObject[] karelerdizisi=new GameObject[25];

    HakKontrolManager hakKontrolManager;
    PuanManager puanManager;
    [SerializeField]
    AudioSource audioSource;

    public AudioClip butonsesi; 

    
    private void Awake()
    {

        kalanHak=3;

        audioSource=GetComponent<AudioSource>();

        sonucpaneli.GetComponent<RectTransform>().localScale=Vector3.zero;
        hakKontrolManager=Object.FindObjectOfType<HakKontrolManager>();

        puanManager=Object.FindObjectOfType<PuanManager>();


        hakKontrolManager.Haklarikontrolet(kalanHak);
    }
    void Start()
    {
        butonabasıldımı=false;
        sorupaneli.GetComponent<RectTransform>().localScale=Vector3.zero;
        KareOluştur ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void KareOluştur()
    {
        for(int i=0;i<25;i++)
        {
            GameObject kare=Instantiate(kareprefab,karelerpaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite=karesprites[Random.Range(0,karesprites.Length)];
            kare.transform.GetComponent<Button>().onClick.AddListener(() => butonatiklandi());
            karelerdizisi[i]=kare;
        }
        Textesayiyaz();
        StartCoroutine(DoFadeRoutune());
        Invoke("Sorupaneliniac",5f);
    }
    void butonatiklandi()
    {
        if(butonabasıldımı)
        {
            audioSource.PlayOneShot(butonsesi);
            butondegeri=int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            gecerlikare=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            sonucukontrolet();

        }
       
    }
    void sonucukontrolet()
    {
        if(butondegeri==dogrusonuc)
        {
            gecerlikare.transform.GetChild(1).GetComponent<Image>().enabled=true;
            gecerlikare.transform.GetChild(0).GetComponent<Text>().text="";
            gecerlikare.transform.GetComponent<Button>().interactable=false;
            puanManager.PuanArtir(sorununZorlukDerecesi);
            bolumdegerlerilistesi.RemoveAt(kacincisoru);
            if(bolumdegerlerilistesi.Count>0)
            {
                Sorupaneliniac();
            }
            else{
                OyunBitti();
            }
           
           
            
        }
        else{
            kalanHak--;
            hakKontrolManager.Haklarikontrolet(kalanHak);
            
        }
        if(kalanHak<=0)
        {
            OyunBitti();
        }

    }
    void OyunBitti()
    {
        //Debug.Log("oyun bitti");
        butonabasıldımı=false;
        sonucpaneli.GetComponent<RectTransform>().DOScale(1,0.5f);
    }

    IEnumerator DoFadeRoutune()
    {
        foreach(var kare in karelerdizisi)
        {
        kare.GetComponent<CanvasGroup>().DOFade(1,0.2f);

        yield return new WaitForSeconds(0.2f);


        }

    }
    
    void Textesayiyaz()
    {
        foreach(var kare in karelerdizisi)
        {
            int rastgeledeger=Random.Range(0,13);
            bolumdegerlerilistesi.Add(rastgeledeger);
            kare.transform.GetChild(0).GetComponent<Text>().text=rastgeledeger.ToString();
        }
        //Debug.Log(bolumdegerlerilistesi[1]);
    }
    void Sorupaneliniac()
    {
        Sorusor();
        butonabasıldımı=true;
        sorupaneli.GetComponent<RectTransform>().DOScale(1,0.5f);

    }    
    void Sorusor(){
        bolensayi=Random.Range(2,11);
        kacincisoru=Random.Range(0,bolumdegerlerilistesi.Count);
        dogrusonuc=bolumdegerlerilistesi[kacincisoru];
        bolunensayi=bolensayi*bolumdegerlerilistesi[kacincisoru];

        if(bolunensayi<=40)
        {
            sorununZorlukDerecesi="kolay";
        }
        else if(bolunensayi>40 &&  bolunensayi<=80)
        {
            sorununZorlukDerecesi="orta";

        }
        else
        {
            sorununZorlukDerecesi="zor";
        }

        sorutext.text=bolunensayi.ToString()+":"+bolensayi.ToString();
    }
}
