using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip yelpClip;
    public AudioClip Coinsound;
    public AudioClip Coinsound2;
    public AudioClip Orcacry1;
    public AudioClip Orcacry2;
    public AudioClip Orcacry3;
    public AudioClip Cthulhu;
    public AudioClip Laser;
    public AudioClip Levelchange;
    public AudioClip Plink;
    public AudioClip Cry;
    public AudioClip Cry2;
    public AudioClip FireballWoosh;
    public AudioClip Explosion;
    public AudioClip CthulhuCry;
    public AudioClip Waves;
    public AudioClip laserdoge;
    // Function to play the yelp sound
    public void PlayYelp()
    {
        if (audioSource != null && yelpClip != null)
        {
            audioSource.PlayOneShot(yelpClip);
        }
    }
    public void PlayOrcacry()
    {
        float x = Random.Range(0.0f, 3.0f);
        if (x < 1.0f)
        {
            audioSource.PlayOneShot(Orcacry1);
        }
        else if (x < 2.0f)
            audioSource.PlayOneShot(Orcacry2);
        else audioSource.PlayOneShot(Orcacry3);
    }
    public void PlayCoinsound()
    {
        if (audioSource != null && Coinsound != null)
        {
            audioSource.PlayOneShot(Coinsound);
        }
    }
    public void PlayCoinsound2()
    {
        if (audioSource != null && Coinsound2 != null)
        {
            audioSource.PlayOneShot(Coinsound2);
        }
    }
    public void PlayCthulhu()
    {
        if (audioSource != null && Cthulhu != null)
        {
            audioSource.PlayOneShot(Cthulhu);
        }
    }
    public void PlayLaser()
    {
        if (audioSource != null && Laser != null)
        {
            audioSource.PlayOneShot(Laser);
        }
    }
    public void PlayLevelchange()
    {
        if (audioSource != null && Levelchange != null)
        {
            audioSource.PlayOneShot(Levelchange);
        }
    }
    public void PlayPlink()
    {
        if (audioSource != null && Plink != null)
        {
            audioSource.PlayOneShot(Plink);
        }
    }
    public void PlayCry()
    {
        if (audioSource != null && Cry != null)
        {
            audioSource.PlayOneShot(Cry);
        }
    }
    public void PlayCry2()
    {
        if (audioSource != null && Cry2 != null)
        {
            audioSource.PlayOneShot(Cry2);
        }
    }
    public void PlayFireballWoosh()
    {
        if (audioSource != null && FireballWoosh != null)
        {
            audioSource.PlayOneShot(FireballWoosh);
        }
    }
    public void PlayCthulhuExplosion()
    {
        if (audioSource != null && Explosion != null)
        {
            audioSource.PlayOneShot(Explosion);
        }
    }
    public void PlayCthulhuCry()
    {
        if (audioSource != null && CthulhuCry != null)
        {
            audioSource.PlayOneShot(CthulhuCry);
        }
    }
    public void PlayWaves()
    {
        if (audioSource != null && Waves != null)
        {
            audioSource.PlayOneShot(Waves);
        }
    }
    public void Laserdoge()
    {
        if (audioSource != null && laserdoge != null)
        {
            audioSource.PlayOneShot(laserdoge);
        }
    }
}
