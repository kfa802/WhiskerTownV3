using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [System.Serializable]
    public class Cat
    {
        public GameObject catObject;
        public List<GameObject> clothes;
    }

    public Cat pusling;
    public Cat musling;
    public Cat misling;

    public Button puslingButton;
    public Button muslingButton;
    public Button mislingButton;

    void Start()
    {
        // Deactivate all cats and their clothes at the start
        DeactivateAllCats();
    }

    void DeactivateAllCats()
    {
        DeactivateCat(pusling);
        DeactivateCat(musling);
        DeactivateCat(misling);
    }

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
}


