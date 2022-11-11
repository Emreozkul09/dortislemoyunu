using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class alfagamalavel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject alfapanel;
    void Start()
    {
        alfapanel.GetComponent<CanvasGroup>().DOFade(0,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
