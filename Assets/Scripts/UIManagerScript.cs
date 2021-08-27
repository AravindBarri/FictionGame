using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private Text AmmoText;
    public static UIManagerScript UIInstance;
    [SerializeField] private GameObject coins;
    // Start is called before the first frame update
    void Start()
    {
        UIInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setAmmo(int value)
    {
        AmmoText.text = "Ammo : " + value;
    }
    public void setAmmoEmpty()
    {
        AmmoText.text = "Ammo : 0 (Reload)" ;
    }
    public void CollectCoins()
    {
        coins.SetActive(true);
    }
    public void RemoveCoins()
    {
        coins.SetActive(false);
    }
}
