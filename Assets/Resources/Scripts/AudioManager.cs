using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
     public static AudioManager Instance { get; private set; }

    public AudioClip themeMusic;
    public AudioClip designSceneMusic;
    public AudioClip[] meowSounds;
    public AudioClip tumbleweedSound;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the scene loaded event

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayThemeMusic();
    }

    public void PlayThemeMusic()
    {
        audioSource.loop = true;
        audioSource.clip = themeMusic;
        audioSource.Play();
    }

    public void PlayDesignSceneMusic()
    {
        audioSource.loop = true;
        audioSource.clip = designSceneMusic;
        audioSource.Play();
    }

    public void PlayMeowSound(int index)
    {
        if (index >= 0 && index < meowSounds.Length)
        {
            audioSource.PlayOneShot(meowSounds[index]);
        }
        else
        {
            Debug.LogWarning("Animal sound index out of range.");
        }
    }

    public void PlayTumbleweedSound()
    {
        audioSource.PlayOneShot(tumbleweedSound);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DesignScene")
        {
            PlayDesignSceneMusic();
        }
        else
        {
            PlayThemeMusic();
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the event when the object is destroyed
        }
    }
}
