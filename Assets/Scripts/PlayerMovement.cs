using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;
    [SerializeField] float timer = 5f;
    private CharacterController character;
    [SerializeField] private float playerSpeed = 5.0f;
    private float gravity = 9.81f;
    [SerializeField] private GameObject muzzleFlashPrefab;
    [SerializeField] private GameObject HitMarkerPrefab;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClip;

    public int bulletCount = 50;
    // Start is called before the first frame update
    void Start()
    {
        character = this.GetComponent<CharacterController>();
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        /*audioSource.clip = audioClip[0];
        audioSource.Play();
        audioSource.loop = true;*/
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        timer += Time.deltaTime;
        if(timer>fireRate)
        {
            
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                if (Input.GetMouseButton(0))
                {
                    timer = 0f;
                    if (bulletCount > 0)
                    {
                        Shoot();
                    }
                    else
                    {
                        print("Not enough bullets");
                    }

                }
                else
                {
                    muzzleFlashPrefab.SetActive(false);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    /*audioSource.clip = audioClip[1];
                    audioSource.Play();
                    audioSource.loop = true;*/
                    audioSource.PlayOneShot(audioClip[1], 0.1F);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    //audioSource.Stop();
                }

            }
            

            //raycast from the centre of main camera


        }
    //raycast from the centre of the MainCamera
        /*if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        else
        {
            muzzleFlashPrefab.SetActive(false);
            audioSource.Stop();


        }*/
        
    }

    private void Shoot()
    {
        muzzleFlashPrefab.SetActive(true);
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            print("Ray got hit" + hit.transform.name);
            HitMarkerManager.hitinstance.instancePoint = hit.point;
            HitMarkerManager.hitinstance.SpawnMarker();

            
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