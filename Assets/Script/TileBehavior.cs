using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

       
        if (IsOutOfScreen())
        {        
            FingerDanceManager.Instance.LoseHP(1);
           
            Destroy(gameObject);
        }
    }

    private bool IsOutOfScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.y < 0; 
    }
}



