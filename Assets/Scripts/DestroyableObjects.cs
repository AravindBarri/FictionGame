using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject CrackerCrate;

    public static DestroyableObjects destroyInstance;
    // Start is called before the first frame update
    void Start()
    {
        destroyInstance = this;
    }

  
    public void CrateDestroy()
    {
        Destroy(this.gameObject);
        Instantiate(CrackerCrate, this.transform.position, this.transform.rotation);
    }
}
