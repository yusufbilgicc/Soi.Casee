using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Movement : MonoBehaviour
{

    private Rigidbody _rigi;
    public int Speed;
    public Vector2 mouse;
    public bool _left;
    public bool _right;


    void Start()
    {
        _rigi = GetComponent<Rigidbody>();

    }


    // el ile etkilei?ime girel listenin 0. eleman?na müdahale et rahat olucak iki ele de collider ve rigid ekle kap?lar?n ellere de?mesinden kontrol et i?lemleri


    void Update()
    {

        
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        _rigi.velocity = transform.forward * Speed;
        if (Input.GetMouseButton(0))
        {
            if (mouse.x < Screen.width / 2)
            {
                print("Mouse is on left side of screen.");
                _left = true;
                _right = false;
            }

            if (mouse.x > Screen.width / 2)
            {
                print("Mouse is on right side of screen.");
                _left = false;
                _right = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _left = false;
            _right = false;

        }
       

    }
   
}
