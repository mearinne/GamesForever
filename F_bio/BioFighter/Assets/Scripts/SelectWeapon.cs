using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour
{
  
    public void chooseWeapon()
    {
        Debug.LogWarning(gameObject.name);
        showHideWeapons.objectNameSelected = gameObject.name;
    }

}
