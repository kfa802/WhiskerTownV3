using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misling : Animal
{
    protected override void Awake()
    {

        // Assign specific hat and mustache sprites for Misling
        hatSprite = Resources.Load<Sprite>("Sprites/Hat1");
        mustacheSprite = Resources.Load<Sprite>("Sprites/Mustache1");


        base.Awake(); // Call base.Awake()

        // Assign the specific sound for Misling
        // animalSound = Resources.Load<AudioClip>("Sounds/Meow1");
        // Debug.Log("Misling sound loaded " + (animalSound != null));

        // Set specific speed for Misling
        speed = 2f;

        // Set specific scale for Misling's hat and mustache
        ChangeHatScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed
        ChangeMustacheScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed

        // Set specific position for Misling's hat and mustache
        ChangeHatPosition(new Vector3(-3.2f, 5f, -1)); // Adjust as needed
        ChangeMustachePosition(new Vector3(-3.5f, 0.3f, -1)); // Adjust as needed
    }

    protected override void PlayAnimalSound()
    {
        AudioManager.Instance.PlayMeowSound(0); // Assumming 0 is the index for Misling's sound
    }



}


