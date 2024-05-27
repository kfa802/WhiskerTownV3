using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This was added to manipulate the UI elements, like buttons. But not really used anymore, but I dind't see a reason to delete. Copilot was used to suggest this.

public class CustomButton : MonoBehaviour
{
    [System.Serializable]
    // This class is used to store the game objects (the cat itself) for each cat and their clothes (list of clothes)
    public class Cat
    {
        public GameObject catObject;
        public List<GameObject> clothes;
    }
    //This is the cats :)
    public Cat pusling;
    public Cat musling;
    public Cat misling;

    //These are the buttons :)
    public UnityEngine.UI.Button puslingButton;
    public UnityEngine.UI.Button muslingButton;
    public UnityEngine.UI.Button mislingButton;

    //This is the Wanted poster (a UI image, with button functionality(sends you to the main screen via scenemanager)) activated when the caemra button is pressed.
    public GameObject wantedObject;

    void Start()
    {
        // Deactivate the wanted object and calls the DeactivateAllCats method
        wantedObject.SetActive(false);
        DeactivateAllCats();
        
    }

    //This method deactivates all cats (calls the DeactivateCat method below))
    void DeactivateAllCats()
    {
        DeactivateCat(pusling);
        DeactivateCat(musling);
        DeactivateCat(misling);
    }

    //This method checks and deactivates the single cat and its clothes, if they exist (not null) we don't want two cats to be active at the same time.
    void DeactivateCat(Cat cat)
    {
        if (cat.catObject != null)
        {
            cat.catObject.SetActive(false);
        }
        foreach (GameObject cloth in cat.clothes)
        {
            if (cloth != null)
            {
                cloth.SetActive(false);
            }
        }
    }
    

    //This method activates the cat and its clothes, this method is connected to the buttons in the inspector.
    void ActivateCat(Cat cat)
    {
        // Deactivate all cats first
        DeactivateAllCats();

        // Activate the selected cat and its clothes
        if (cat.catObject != null)
        {
            cat.catObject.SetActive(true);
        }
        foreach (GameObject cloth in cat.clothes)
        {
            if (cloth != null)
            {
                cloth.SetActive(true);
            }
        }
    }

    //These methods are connected to the buttons in the inspector. Copilot was used generate these buttons.
    public void ActivatePusling()
    {
        ActivateCat(pusling);
    }

    public void ActivateMusling()
    {
        ActivateCat(musling);
    }

    public void ActivateMisling()
    {
        ActivateCat(misling);
    }
    public void ActivateWantedObject()

    {
        wantedObject.SetActive(true);
    }

}


