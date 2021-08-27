using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                print(player);
                if(player != null)
                {
                    player.hascoin = true;
                    Destroy(this.gameObject);
                    Debug.Log("Coin Collected");
                    UIManagerScript.UIInstance.CollectCoins();
                }
                
            }
        }
    }
}
