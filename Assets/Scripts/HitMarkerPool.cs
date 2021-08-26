using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerPool : MonoBehaviour
{
    public static HitMarkerPool hitPoolInstance;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PushtoPool", 2f);
    }
    private void Update()
    {
    }
    // Update is called once per frame
    public void PushtoPool()
    {
        //HitMarkerManager.hitinstance.AddHitMarkerPool(this.gameObject);
        Destroy(this.gameObject);
    }
}
