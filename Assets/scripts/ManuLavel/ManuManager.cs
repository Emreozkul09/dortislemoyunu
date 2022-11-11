using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
    


public class ManuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject startbtn,stopbtn;
    void Start()
    {
        Fadeout();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void Fadeout()
    {
        startbtn.GetComponent<CanvasGroup>().DOFade(1,0.8f);
        stopbtn.GetComponent<CanvasGroup>().DOFade(1,0.8f);
    }
    public void exitgame()
    {
        Application.Quit();
    }
    public void startgamelavel()
    {
        SceneManager.LoadScene("gamelevel3");
    }
}
