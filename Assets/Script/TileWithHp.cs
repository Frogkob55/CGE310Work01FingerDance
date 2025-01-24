using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWithTempo : Tile
{
    public int tempoBonus = 1; 

    
    protected override void OnMouseDown()
    {
        base.OnMouseDown(); 

        
        AddTempo(tempoBonus);
    }

    public void AddTempo(int amount)
    {
        
        FingerDanceManager.Instance.AddTempo(amount);
        Debug.Log("Tempo increased by " + amount + ". Current Tempo: " + FingerDanceManager.Instance.Tempo);
    }
}
