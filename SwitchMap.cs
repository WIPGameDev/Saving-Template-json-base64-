using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMap : MonoBehaviour
{
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject map;
    [SerializeField] Camera mapCam;

    [SerializeField] float mapZoom;
    [SerializeField] float miniZoom;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ActivateMap();
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            ActivateMini();
        }              
    }

    private void ActivateMap()
    {
        minimap.SetActive(false);
        mapCam.orthographicSize = mapZoom;
        map.SetActive(true);
    }

    private void ActivateMini()
    {
        map.SetActive(false);
        mapCam.orthographicSize = miniZoom;
        minimap.SetActive(true);
    }
}
