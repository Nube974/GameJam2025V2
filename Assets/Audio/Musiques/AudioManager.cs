using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioClip[] playlist;
	public AudioSource audioSource;
	private int musicIndex = 0;
	public bool nextMusic = false;
	
    void Start()
    {
	
		audioSource.clip = playlist[0];
		audioSource.Play();
        
    }

    void Update()
    {
        if(!audioSource.isPlaying)
		{
			PlayNextSong();
		}
    }
	
	public void PlayNextSong()
	{
		print("musique suivante");
		musicIndex = (musicIndex + 1) % playlist.Length;
		audioSource.clip = playlist[musicIndex];
		audioSource.Play();
	}
	void OnCollisionEnter2D(Collision2D collision)
    {
		print(collision.gameObject.tag);
		//PlayNextSong();
        if (collision.gameObject.CompareTag("MusicTrigger"))
        {
            // Contact principal
			if (!nextMusic){
				PlayNextSong();
				nextMusic = true;
			}
        }
	}
}
