using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShop : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                if(player != null)
                {
                    print(player.hascoin);
                    if(player.hascoin == true)
                    {
                        player.hascoin = false;
                        /*UIManagerScript Uimanager = GameObject.Find("UIManagerObject").GetComponent<UIManagerScript>();
                        if(Uimanager != null)
                        {
                            Uimanager.RemoveCoins();
                        }*/
                        UIManagerScript.UIInstance.RemoveCoins();
                        PlayerMovement.playerinstance.ActiveWeapon();
                    }
                    else
                    {
                        Debug.Log("Please go and collect some coins !");
                    }
                }
            }
        }
    }
}
