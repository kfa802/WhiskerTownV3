using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour
{
   // Define properties and methods common to all animals
   
   // Variables for the click and drag method
   private bool isDragging = false;
   private Vector3 offset;

   // Variables for the audio manager
   public AudioClip animalSound;
   private AudioSource audioSource;

   // Variables for movement
   private Coroutine walkCoroutine;
   protected float speed = 1f; // Default walking speed 


   // Variables for appearance
   public Sprite hatSprite;
   public Sprite mustacheSprite;
   private GameObject hatObject;
   private GameObject mustacheObject;
   protected SpriteRenderer hatRenderer;
   protected SpriteRenderer mustacheRenderer;

   // Variables for scaling and positioning (sprites)
   public Vector3 hatScale = new Vector3(1, 1, 1);
   public Vector3 mustacheScale = new Vector3(1, 1, 1);
   public Vector3 hatPosition = new Vector3(0, 0.5f, 0);
   public Vector3 mustachePosition = new Vector3(0, -0.5f, 0);




   protected virtual void Awake()
   {
    // Add an AudioSource component to the object
    audioSource = gameObject.AddComponent<AudioSource>();
    // Start the walking coroutine
    walkCoroutine = StartCoroutine(WalkAround());


    // Create GameObjects for hat and mustache
    hatObject = new GameObject("Hat");
    mustacheObject = new GameObject("Mustache");

    // Set the hat and mustache as children of the animal
    hatObject.transform.SetParent(transform);
    mustacheObject.transform.SetParent(transform);

    // Add SpriteRenderer component to the hat and mustache objects
    hatRenderer = hatObject.AddComponent<SpriteRenderer>();
    mustacheRenderer = mustacheObject.AddComponent<SpriteRenderer>();

    // Set default sprites
    hatRenderer.sprite = hatSprite;
    mustacheRenderer.sprite = mustacheSprite;

    // Adjust scale and position of the hat and mustache
    hatObject.transform.localScale = hatScale;
    mustacheObject.transform.localScale = mustacheScale;

    hatObject.transform.localPosition = hatPosition;
    mustacheObject.transform.localPosition = mustachePosition;

   }

   protected virtual void OnMouseDown()
   {
    // Calculate the offset between the object's position and the mouse position
    offset = gameObject.transform.position - GetMouseWorldPosition();
    isDragging = true;
    PlayAnimalSound();
    Debug.Log("Mouse down on " + gameObject.name);
   }

    protected virtual void OnMouseUp()
    {
     isDragging = false;
    }

    protected virtual void Update()
    {
     if (isDragging)
     {
      // Update the object's position to follow the mouse
      gameObject.transform.position = GetMouseWorldPosition() + offset;
     }
    }

    private Vector3 GetMouseWorldPosition()
    {
     // Get the mouse position in screen coordinates
     Vector3 mousePosition = Input.mousePosition;

     mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
     // Convert the screen coordinates to world coordinates
     return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    protected virtual void PlayAnimalSound()
    {
     if (animalSound != null && audioSource != null)
     {
      audioSource.PlayOneShot(animalSound);
     }
    }

    private IEnumerator WalkAround()
    {
     while (true)
     {
      if (!isDragging)
      {
       // Generate a random position within the screen bounds
       Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
       float randomDistance = Random.Range(1f, 5f);
       Vector3 targetPosition = transform.position + randomDirection * randomDistance;

       // Ensure target position is within the screen bounds
       targetPosition = GetClampedPosition(targetPosition);

       // Move towards the target position
       float walkTime = randomDistance / speed; // Use speed varibale here
       float elapsedTime = 0;
       Vector3 startingPosition = transform.position;

       while (elapsedTime < walkTime)
       {
        if (isDragging) break;

        transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / walkTime);
        elapsedTime += Time.deltaTime;
        yield return null;
       }
      }
      // Wait for a random amount of time before walking again
        float waitTime = Random.Range(1f, 3f);
        yield return new WaitForSeconds(waitTime);
     }
    }

    private Vector3 GetClampedPosition(Vector3 targetPosition)
    {
     // Get the main camera
     Camera cam = Camera.main;

     // Convert the world positiob to screen position 
     Vector3 screenPos = cam.WorldToScreenPoint(targetPosition);

    // Clamp the screen position to ensure is stays within the
     screenPos.x = Mathf.Clamp(screenPos.x, 0, Screen.width);
     screenPos.y = Mathf.Clamp(screenPos.y, 0, Screen.height);

     // Convert the clamped screen position back to world position
     return cam.ScreenToWorldPoint(screenPos);
    }

    protected virtual void OnDestroy()
    {
     if (walkCoroutine != null)
     {
      StopCoroutine(walkCoroutine);
     }
    }

    // Method to change hat sprite
    public void ChangeHat(Sprite newHatSprite)
    {
     hatRenderer.sprite = newHatSprite;
    }

    // Method to change mustache sprite
    public void ChangeMustache(Sprite newMustacheSprite)
    {
     mustacheRenderer.sprite = newMustacheSprite;
    }

    // Method to change hat scale
    public void ChangeHatScale(Vector3 newScale)
    {
     hatObject.transform.localScale = newScale;
    }

    // Method to change mustache scale
    public void ChangeMustacheScale(Vector3 newScale)
    {
     mustacheObject.transform.localScale = newScale;
    }

    // Method to change hat position
    public void ChangeHatPosition(Vector3 newPosition)
    {
     hatObject.transform.localPosition = newPosition;
    }

    // Method to change mustache position
    public void ChangeMustachePosition(Vector3 newPosition)
    {
     mustacheObject.transform.localPosition = newPosition;
    }
}
