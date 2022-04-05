using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class RightHand : MonoBehaviour
{
    private Movement _movement;
    public List<GameObject> _rightHand;
    public GameObject Card;
    public GameObject newCard;
    public bool instTimer = true;

    public GameObject _door;
    //kartları arttırma işlemi
    public bool multipler;
    public int multiplervalue;
    //kartları azaltma işlemi
    public bool destroyer;

    public bool GoLeft;
    public float GoY;
    public TextMeshProUGUI Count;




    void Start()
    {
        _movement = FindObjectOfType<Movement>();
        instTimer = true;
        GoLeft = true;
        GoY = 3.17f;
    }

    // Update is called once per frame
    void Update()
    {
        Count.text = ""+_rightHand.Count;
       
        if (_rightHand.Count ==0)
        {
            GoY = 3.17f;
            multipler = false;
            destroyer = false;
        }

        if (_movement._left && _rightHand.Count != 0)
        {
            
            for (int i = 0; i < 1; i++)
            {
                
                if (GoLeft)
                {
                    _rightHand[_rightHand.Count - 1].transform.DOMoveX(-0.62f,0.1f);
                    _rightHand[_rightHand.Count - 1].transform.DOMoveY(5, 0.1f);
                    _rightHand[_rightHand.Count - 1].transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 90), 0.2f);
                    GoLeft = false;
                    StartCoroutine(CardMoveTimer());
                    
                }

            }
        }

        if (_rightHand.Count > 0)
        {
            Card = _rightHand[0];
        }
       
        if (multipler)
        {

           
            if (multiplervalue != _door.gameObject.GetComponent<DoorsController>().SelectedListCount) 
            {
                for (int i = 0; i < _door.gameObject.GetComponent<DoorsController>().SelectedListCount; i++)
                {
                    if (_door.gameObject.GetComponent<DoorsController>().Plus || _door.gameObject.GetComponent<DoorsController>().Product)
                    {
                        if (instTimer)
                        {
                            newCard = Instantiate(Card, new Vector3(_rightHand[_rightHand.Count - 1].gameObject.transform.position.x, _rightHand[_rightHand.Count - 1].gameObject.transform.position.y + 0.01f, _rightHand[_rightHand.Count - 1].gameObject.transform.position.z), Quaternion.identity);
                            multiplervalue++;
                            instTimer = false;
                            StartCoroutine(InstentiateSmoothTimer());

                        }

                    }
                }
            }
            if (multiplervalue == _door.gameObject.GetComponent<DoorsController>().SelectedListCount)
            {
                multipler = false;
            }
        }

        if (destroyer )
        {

            if (_door.gameObject.GetComponent<DoorsController>().Minus && _door.gameObject.GetComponent<DoorsController>().SelectedListCount != _rightHand.Count)
            {
                for (int i = 1; i < _door.gameObject.GetComponent<DoorsController>().ProcessValue+1; i++)
                {
                    if (instTimer )
                    {
                        Destroy(_rightHand[_rightHand.Count-1]);
                        _rightHand.Remove(_rightHand[_rightHand.Count-1].gameObject);
                       
                    }
                }
                
            }
            if (_door.gameObject.GetComponent<DoorsController>().Divide && _door.gameObject.GetComponent<DoorsController>().SelectedListCount != _rightHand.Count) 
            {
                for (int i = 1; i < _door.gameObject.GetComponent<DoorsController>().ProcessValue + 1; i++)
                {
                    if (instTimer )
                    {
                        Destroy(_rightHand[_rightHand.Count-1]);
                        _rightHand.Remove(_rightHand[_rightHand.Count-1].gameObject);
                        instTimer = false;
                        StartCoroutine(InstentiateSmoothTimer());
                    }
                }
            }

            if (_rightHand.Count == _door.gameObject.GetComponent<DoorsController>().SelectedListCount )
            {
                multiplervalue = 0;
                destroyer = false;
            }
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag =="Card")
        {
            _rightHand.Remove(other.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Card")
        {
            _rightHand.Add(other.gameObject);
            GoY = 3.17f;
            GoY = GoY+(_rightHand.Count* 0.02f);
            other.gameObject.transform.DOMoveY(GoY, 1);
            other.gameObject.transform.DOMoveX(1.2f, 0.5f);
            other.gameObject.transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 0), 0.5f);
        }
        if (other.gameObject.tag == "Door")
        {
            _door = other.gameObject;
            multiplervalue = 0;
            if (_door.GetComponent<DoorsController>().Plus|| _door.GetComponent<DoorsController>().Product)
            {
                 multipler = true;
            }
            else if (_door.GetComponent<DoorsController>().Minus|| _door.GetComponent<DoorsController>().Divide)
            {
                destroyer = true;
            }
        }
    }
    
    IEnumerator InstentiateSmoothTimer()
    {
        
        yield return new WaitForSeconds(0.01f);
        instTimer = true;
    }
    IEnumerator CardMoveTimer()
    {
       yield return new WaitForSeconds(0.00000001f);
        GoY += 0.01f;
        GoLeft = true;
    }
}
