using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int hp = 3;
    private bool isClicked = false;

    
    protected virtual void OnMouseDown()
    {
        isClicked = true;

        TakeDamage(1);
        FingerDanceManager.Instance.AddScore(100);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            DestroyTile();
        }
    }

    private void Update()
    {
        if (IsOutOfScreen())
        {
            if (!isClicked)
            {
                FingerDanceManager.Instance.LoseHP(1);
            }
            DestroyTile();
        }
    }

    private bool IsOutOfScreen()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera not found!");
            return false;
        }

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.y < 0;
    }

    private void DestroyTile()
    {
        Destroy(gameObject);
    }
}
