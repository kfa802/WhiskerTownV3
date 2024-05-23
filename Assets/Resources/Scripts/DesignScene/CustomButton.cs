using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
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

    public UnityEngine.UI.Button puslingButton;
    public UnityEngine.UI.Button muslingButton;
    public UnityEngine.UI.Button mislingButton;

    public GameObject wantedObject;

    void Start()
    {
        // Deactivate all cats and their clothes at the start (and wanted object)
        wantedObject.SetActive(false);
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
    public void ActivateWantedObject()

    {
        wantedObject.SetActive(true);
    }

}


