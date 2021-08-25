using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;
    [SerializeField]
    private float playerSpeed = 5.0f;
    private float gravity = 9.81f;
    [SerializeField]
    private GameObject muzzleFlashPrefab;
    [SerializeField]
    private GameObject HitMarkerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //raycast from the centre of the MainCamera
        if (Input.GetMouseButton(0))
        {
            muzzleFlashPrefab.SetActive(true);
            Ray ray = Camera.main.ScreenPointToRay(new Vector3( Screen.width / 2f, Screen.height / 2f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                print("Ray got hit" + hit.transform.name);
                Instantiate(HitMarkerPrefab, hit.point, Quaternion.identity);
            }
        }
        else
        {
            muzzleFlashPrefab.SetActive(false);

        }
        
    }

    private void Movement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * playerSpeed;
        velocity.y = -gravity;
        velocity = transform.transform.TransformDirection(velocity);
        character.Move(velocity * Time.deltaTime);
    }
}
