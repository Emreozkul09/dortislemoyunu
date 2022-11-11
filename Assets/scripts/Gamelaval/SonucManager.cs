using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OyunaYenidenBasla()
    {
        
        SceneManager.LoadScene("gamelevel3");


    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("manulavel");
    }

    // Update is called once per frame
    void Update()
    {

    }
        
}
