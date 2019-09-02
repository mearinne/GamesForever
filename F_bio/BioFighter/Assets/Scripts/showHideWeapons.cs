using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHideWeapons : MonoBehaviour
{
    public GameObject weaponsContainer;

    public static string objectNameSelected;

    public Sprite bow;
    public Sprite grenade;
    public Sprite knife;
    public Sprite pistol;
    public Sprite rifle;
    public Sprite rpg;

    private void Awake()
    {
        weaponsContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (objectNameSelected == "bow")
        {
            this.gameObject.GetComponent<Image>().sprite = bow;
        }
        if (objectNameSelected == "grenade")
        {
            this.gameObject.GetComponent<Image>().sprite = grenade;
        }
        if (objectNameSelected == "knife")
        {
            this.gameObject.GetComponent<Image>().sprite = knife;
        }
        if (objectNameSelected == "pistol")
        {
            this.gameObject.GetComponent<Image>().sprite = pistol;
        }
        if (objectNameSelected == "rifle")
        {
            this.gameObject.GetComponent<Image>().sprite = rifle;
        }
        if (objectNameSelected == "rpg")
        {
            this.gameObject.GetComponent<Image>().sprite = rpg;
        }

    }

    public void showHide()
    {
        if (!weaponsContainer.activeSelf)
        {
            weaponsContainer.SetActive(true);
        }
        else
        {
            weaponsContainer.SetActive(false);
        }
    }

    
}
