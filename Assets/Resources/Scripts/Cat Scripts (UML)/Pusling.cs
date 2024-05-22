using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusling : Animal
{
    protected override void Awake()
    {
        // Assign specific hat and mustache sprites for Misling
        hatSprite = Resources.Load<Sprite>("Sprites/Hat3");
        mustacheSprite = Resources.Load<Sprite>("Sprites/Mustache3");


        base.Awake();
        
        // Assign the specific sound for the dog
        // animalSound = Resources.Load<AudioClip>("Sounds/Meow3");
        // Debug.Log("Pusling sound loaded " + (animalSound != null));

        // Set specific speed for Pusling
        speed = 0.5f;

        // Set specific scale for Pusling's hat and mustache
        ChangeHatScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed
        ChangeMustacheScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed

        // Set specific position for Pusling's hat and mustache
        ChangeHatPosition(new Vector3(-4.5f, 5f, -1)); // Adjust as needed
        ChangeMustachePosition(new Vector3(-4.6f, 0.5f, -1)); // Adjust as needed
    }

    protected override void PlayAnimalSound()
    {
        AudioManager.Instance.PlayMeowSound(2); // Assumming 2 is the index for Pusling's sound
    }
}