using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeapon : MonoBehaviour
{
    // l'ID de l'arme actuelle
    private int weaponID = 0;
    // Liste de nos armes (Objet qui se trouve dans la main du personnage)
    public List<GameObject> weaponList = new List<GameObject>();
    

    // Update is called once per frame
    void Update()
    {
        // Verification si une arme est ajouter a un slot 
        if(transform.childCount > 0)
        {
            weaponID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }

    }
}
