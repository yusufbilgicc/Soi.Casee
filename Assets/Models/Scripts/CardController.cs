using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    private Movement _movement;
    public bool left;
    public bool right;
    public float yVal;
   
    void Start()
    {
        _movement = FindObjectOfType<Movement>();
    }

    
    void Update()
    {
        
        // burası oldu gibi ama olmadı bunşarı listenin countu kadar çalışan bi for döngüsü ile arada cok az bir sanşiye olarak çalıştırıcaksın 
        // ama gidişleri fena değil bi bak bakalım
        // cardlar gittiği zaman yerine kaybolucak sen yenisini inst ediceksin sayısı kadar 

        //if (left && _movement._left)
        //{
        //    transform.DOMove(new Vector3(-0.62f, 7f, transform.position.z), 1.5f).OnComplete(() => transform.DOMoveY(3.17f, 1));
        //    transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 180), 1.5f);
        //    left = false;
        //    right = true;
        //}
        //else if (right && _movement._right)
        //{
        //    transform.DOMove(new Vector3(1.2f,7f, transform.position.z), 1.5f).OnComplete(() => transform.DOMoveY(3.17f, 1));
        //    transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 0), 1.5f);
        //    right = false;
        //    left = true;    
        //}
    }
}
