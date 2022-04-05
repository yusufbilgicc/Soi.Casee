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
    private LeftHand _leftHand;
    private RightHand _righHand;

    public GameObject Button;


    void Start()
    {
        _rigi = GetComponent<Rigidbody>();
        _leftHand = GetComponentInChildren<LeftHand>();
        _righHand = GetComponentInChildren<RightHand>();

    }


    // el ile etkilei?ime girel listenin 0. eleman?na müdahale et rahat olucak iki ele de collider ve rigid ekle kap?lar?n ellere de?mesinden kontrol et i?lemleri


    void Update()
    {
        if (_leftHand._leftHand.Count == 0 && _righHand._rightHand.Count == 0)
        {
            Button.SetActive(true);
            Speed = 0;
        }
        
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            Button.SetActive(true);
            Speed = 0;

        }
    }
    public void ReloadSceneBut()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
