using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text healthText;
    public Health health;
    public TMP_Text ammoText;
    public Weapon weapon;
    

    
    void Update()
    {
        healthText.text = health.health.ToString();
        ammoText.text = weapon.ammo.ToString();

    }
}
