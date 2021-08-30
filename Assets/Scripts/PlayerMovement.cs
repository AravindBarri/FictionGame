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


    [SerializeField] private int MaximumAmmo = 50;
    public int CurrentAmmo = 0;
    public bool hascoin = false;

    [SerializeField] private GameObject weapon;
    private bool weaponstate = false;

    public static PlayerMovement playerinstance;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        character = this.GetComponent<CharacterController>();
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        /*audioSource.clip = audioClip[0];
        audioSource.Play();
        audioSource.loop = true;*/
        CurrentAmmo = MaximumAmmo;
        playerinstance = this;
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
                if(weaponstate == true)
                {
                    if (Input.GetMouseButton(0))
                    {
                        CurrentAmmo--;
                        print(CurrentAmmo);
                        timer = 0f;
                        if (CurrentAmmo > 0)
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
               

            }
            

            //raycast from the centre of main camera


        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("ReloadBullets", 1f);
        }
        if (CurrentAmmo > 0)
        {
            UIManagerScript.UIInstance.setAmmo(CurrentAmmo);
        }
        if(CurrentAmmo<=0)
        {
            UIManagerScript.UIInstance.setAmmoEmpty();
        }
        
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
            if(hit.transform.tag == "WoodenCrate")
            {
                DestroyableObjects.destroyInstance.CrateDestroy();
            }
            
            
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
    void ReloadBullets()
    {
        CurrentAmmo = MaximumAmmo;
    }
    public void ActiveWeapon()
    {
        weapon.SetActive(true);
        weaponstate = true;
    }
}