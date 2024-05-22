using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musling : Animal
{
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
        ChangeHatScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed
        ChangeMustacheScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed

        // Set specific position for Musling's hat and mustache
        ChangeHatPosition(new Vector3(-2.7f, 5f, -1)); // Adjust as needed
        ChangeMustachePosition(new Vector3(-2.7f, 0.3f, -1)); // Adjust as needed
    }

    protected override void PlayAnimalSound()
    {
        AudioManager.Instance.PlayMeowSound(1); // Assumming 1 is the index for Musling's sound
    }

}
