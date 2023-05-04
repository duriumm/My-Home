using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwitcher : MonoBehaviour
{
    public enum Page
    {
        ImagesPage,
        TextPage,
        InsurancesPage
    }
    public List<GameObject> pagesList = new List<GameObject>();
    public Page currentPage = Page.ImagesPage;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform page in GameObject.Find("Pages").gameObject.transform)
        {
            pagesList.Add(page.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Switches page to the selected one. 
    // Choose the selected page by choosing enum in editor
    public void SwitchPage()
    {
        foreach (GameObject page in pagesList) 
        {
            if(page.name == currentPage.ToString())
            {
                print("The pressed buttons currentPage was same as the one we want to switch to, " +
                    "therefor we do NOT set active false on it");
                page.SetActive(true);
            }
            else
                page.SetActive(false);
        }
    }
}
