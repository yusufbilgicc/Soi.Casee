using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
    private LeftHand _left;
    private RightHand _right;




    public bool Plus;
    public bool Minus;
    public bool Divide;
    public bool Product;

    public int ProcessValue; // işlemin değeri el ile girilicek kapının değerine göre

    public int SelectedListCount;


   
    
    void Start()
    {
        _left = FindObjectOfType<LeftHand>();
        _right = FindObjectOfType<RightHand>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Process()
    {
        if (Plus && SelectedListCount != 0) 
        {
            for (int i = 0; i < SelectedListCount; i++)
            {
                SelectedListCount = ((SelectedListCount + ProcessValue) - SelectedListCount);
            }
        }
        else if (Minus && SelectedListCount != 0)
        {
            for (int i = 0; i < ProcessValue; i++)
            {
                SelectedListCount--;
            }
        }
        else if (Divide && SelectedListCount != 0) 
        {
            for (int i = 0; i < 1; i++)
            {
                SelectedListCount = (SelectedListCount / ProcessValue);
            }
        }
        else if (Product && SelectedListCount != 0)
        {
            for (int i = 0; i < 1; i++)
            {
                SelectedListCount = (SelectedListCount * ProcessValue)-SelectedListCount;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Right")
        {
            SelectedListCount = other.gameObject.GetComponent<RightHand>()._rightHand.Count;
            if (SelectedListCount > 0)
            {
                Process();
            }
            
        }
        if (other.gameObject.tag == "Left")
        {
            SelectedListCount = other.gameObject.GetComponent<LeftHand>()._leftHand.Count;
            if (SelectedListCount > 0)
            {
                Process();
            }
            
        }
    }
}
