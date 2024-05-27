using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misling : Animal
{

    private bool isHopping = false;
    private float hopHeight = 0.3f; // Adjust as needed


    // Variables for cycling through hat sprites
    //private int currentHatIndex = 0;
    //private int currentMustacheIndex = 0;
    //public Sprite[] hatSprites; // Array containing hat sprites for Misling
    //public Sprite[] mustacheSprites; // Array containing mustache sprites for Misling

    protected override void Awake()
    {
        // Assign specific hat and mustache sprites for Misling
        hatSprite = Resources.Load<Sprite>("Sprites/Hat1");
        mustacheSprite = Resources.Load<Sprite>("Sprites/Mustache1");


        base.Awake(); // Call base.Awake()

        // Set specific speed for Misling
        speed = 2f;
        
        // Set specific scale for Misling's hat and mustache
        ChangeHatScale(new Vector3(0.55f, 0.55f, 0.55f)); // Adjust as needed
        ChangeMustacheScale(new Vector3(0.5f, 0.5f, 0.5f)); // Adjust as needed

        // Set specific position for Misling's hat and mustache
        ChangeHatPosition(new Vector3(-3.45f, 5f, -1)); // Adjust as needed
        ChangeMustachePosition(new Vector3(-3.65f, 0.3f, -1)); // Adjust as needed

         // Assign the specific sound for Misling
        // animalSound = Resources.Load<AudioClip>("Sounds/Meow1");
        // Debug.Log("Misling sound loaded " + (animalSound != null));
    }

    protected override void Update()
    {
        base.Update(); // Call base.Update()

        if(!isDragging)
        {
            if (!isHopping && Random.value < 0.0009f) // Adjust the probability as needed 
            {
                StartCoroutine(Hop());
            }

        }
    }

    private IEnumerator Hop()
    {
        isHopping = true;

        Vector3 startPos = transform.position;
         Vector3 endPos = startPos + new Vector3(0, hopHeight, 0); // Adjust the hop height as needed
        float duration = 0.2f; // Adjust the duration of the hop as needed
        float elapsed = 0f;

         while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;

        yield return new WaitForSeconds(0.1f); // Adjust the time between hops as needed

        startPos = transform.position;
        endPos = startPos - new Vector3(0, hopHeight, 0); // Move back down
        elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;

        isHopping = false;
    }

    protected override void PlayAnimalSound()
    {
        AudioManager.Instance.PlayMeowSound(0); //  0 is the index for Misling's sound
    }

    private void Start()
    {
        // Change color of Misling
        ChangeColor(Color.white);
    }

    protected override void OnMouseDown()
    {
        // Call the base method first to perform drag behaviour ´
        base.OnMouseDown();

        // Unique behavior for Misling

        

        // Change color when tapped
        //ChangeColor(Random.ColorHSV()); // Change color to a random color

        // Check if the hat or mustache was clicked
        //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
       // if (hit.collider != null)
        //{
           // if (hit.collider.gameObject == hatObject)
           // {
                //OnHatMouseDown();
            //}
           // else if (hit.collider.gameObject == mustacheObject)
           // {
               // OnMustacheMouseDown();
           // }
       // }
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
    //protected void ChangeHatToNextSprite()
   // {
       // if (hatSprites.Length > 0)
        //{
            //currentHatIndex = (currentHatIndex + 1) % hatSprites.Length;
            //ChangeHat(hatSprites[currentHatIndex]);
        //}
    //}

    // Method to change the mustache sprite to the next one
    //protected void ChangeMustacheToNextSprite()
    //{
        //if (mustacheSprites.Length > 0)
       // {
           // currentMustacheIndex = (currentMustacheIndex + 1) % mustacheSprites.Length;
            //ChangeMustache(mustacheSprites[currentMustacheIndex]);
       // }
    //}


}



