using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponswap : MonoBehaviour
{
    public GameObject sword, gun1, gun2;
    public shooting s;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            sword.SetActive(true);
            gun1.SetActive(false);
            gun2.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            sword.SetActive(false);
            gun1.SetActive(true);
            gun2.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            sword.SetActive(false);
            gun1.SetActive(false);
            gun2.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            sword.SetActive(false);
            gun1.SetActive(false);
            gun2.SetActive(false);
            s.StopShootAnimation();
        }
    }
   
}
