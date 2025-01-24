using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips; 
    public AudioClip gameOverClip; 
    private AudioSource audioSource; 
    private bool isGameOver = false; 

    [Range(0f, 1f)]
    public float volume = 1.0f; 
    private void Start()
    {
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
        audioSource.volume = volume; 

        
        PlayRandomSound();
    }

    private void Update()
    {
        
        if (!isGameOver && !audioSource.isPlaying)
        {
            PlayRandomSound();
        }
    }

    private void PlayRandomSound()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("ไม่มีไฟล์เสียงใน Audio Clips!");
            return;
        }

        
        AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = randomClip;
        audioSource.Play(); 
    }

    public void PlayGameOverSound()
    {
        if (isGameOver) return; 

        isGameOver = true; 
        audioSource.Stop(); 

        if (gameOverClip != null)
        {
            audioSource.clip = gameOverClip; 
            audioSource.loop = false; 
            audioSource.Play(); 
        }
        else
        {
            Debug.LogWarning("ไม่มีไฟล์ Game Over Clip!");
        }
    }
}
