using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookDirection : MonoBehaviour
{
    [SerializeField]
    private float rotateXspeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + mouseX * rotateXspeed, transform.localEulerAngles.z);
    }
}
