using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject next;
    public GameObject before;
    // Use this for initialization
    void Start()
    {

    }
    public void turnpage()
    {
        if (page1.activeInHierarchy)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            before.SetActive(true);
        }
        else
        {
            page2.SetActive(false);
            page3.SetActive(true);
            before.SetActive(true);
        }
        if (page3.activeInHierarchy)
        {
            next.SetActive(false);
        }
    }
    public void turnpage2()
    {
        if (page2.activeInHierarchy)
        {
            page1.SetActive(true);
            page2.SetActive(false);
            next.SetActive(true);
        }
        else
        {
            page2.SetActive(true);
            page3.SetActive(false);
            next.SetActive(true);
        }
        if (page1.activeInHierarchy)
        {
            before.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}