using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musling : Animal
{
     // Variables for cycling through hat sprites
    private int currentHatIndex = 0;
    private int currentMustacheIndex = 0;
    public Sprite[] hatSprites; // Assuming this array contains different hat sprites for Misling
    public Sprite[] mustacheSprites; // Assuming this array contains different mustache sprites for Misling

      protected override void Awake()
    {
        // Assign specific hat and mustache sprites for Musling
        hatSprite = Resources.Load<Sprite>("Sprites/Hat2");
        mustacheSprite = Resources.Load<Sprite>("Sprites/Mustache2");


        base.Awake();
        // Assign the specific sound for the dog
        // animalSound = Resources.Load<AudioClip>("Sounds/Meow2");
        // Debug.Log("Musling sound loaded " + (animalSound != null));

        // Set specific speed for Musling
        speed = 1f;

        // Set specific scale for Musling's hat and mustache
        ChangeHatScale(new Vector3(0.55f, 0.55f, 0.55f)); // Adjust as needed
        ChangeMustacheScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed

        // Set specific position for Musling's hat and mustache
        ChangeHatPosition(new Vector3(-2.6f, 5f, -1)); // Adjust as needed
        ChangeMustachePosition(new Vector3(-2.7f, 0.3f, -1)); // Adjust as needed
    }

    protected override void PlayAnimalSound()
    {
        AudioManager.Instance.PlayMeowSound(1); // Assumming 1 is the index for Musling's sound
    }

    private void Start()
    {
        // Change color of Musling
        ChangeColor(Color.white);
    }

     protected override void OnMouseDown()
    {
        // Call the base method first to perform drag behaviour ´
        base.OnMouseDown();

        // Change color when tapped
        ChangeColor(Random.ColorHSV()); // Change color to a random color

         // Check if the hat or mustache was clicked
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == hatObject)
            {
                OnHatMouseDown();
            }
            else if (hit.collider.gameObject == mustacheObject)
            {
                OnMustacheMouseDown();
            }
        }
    }

     protected override void OnHatMouseDown()
    {
        // Call the base method first to perform hat tap behavior
        base.OnHatMouseDown();

        // Change the hat to the next sprite
        ChangeHatToNextSprite();
    }

    protected override void OnMustacheMouseDown()
    {
        // Call the base method first to perform mustache tap behavior
        base.OnMustacheMouseDown();

        // Change the mustache to the next sprite
        ChangeMustacheToNextSprite();
    }

    
    // Method to change the hat sprite to the next one
    protected void ChangeHatToNextSprite()
    {
        if (hatSprites.Length > 0)
        {
            currentHatIndex = (currentHatIndex + 1) % hatSprites.Length;
            ChangeHat(hatSprites[currentHatIndex]);
        }
    }

    // Method to change the mustache sprite to the next one
    protected void ChangeMustacheToNextSprite()
    {
        if (mustacheSprites.Length > 0)
        {
            currentMustacheIndex = (currentMustacheIndex + 1) % mustacheSprites.Length;
            ChangeMustache(mustacheSprites[currentMustacheIndex]);
        }
    }


}
