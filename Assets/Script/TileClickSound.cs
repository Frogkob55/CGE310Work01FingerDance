using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClickSound : MonoBehaviour
{
    public AudioClip[] clickSounds;
    private int lastPlayedIndex = -1;

    private void OnMouseDown()
    {
        if (clickSounds.Length > 0)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, clickSounds.Length);
            } while (randomIndex == lastPlayedIndex);

            lastPlayedIndex = randomIndex;

            // สั่งให้ SoundPlayer เล่นเสียงแทน
            SoundPlayer.Instance.PlaySound(clickSounds[randomIndex], Random.Range(0.1f, 0.2f));
        }
        else
        {
            Debug.LogWarning("No sounds assigned to the Tile!");
        }
    }
}
