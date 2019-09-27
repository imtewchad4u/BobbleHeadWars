using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Set the bullet Prefab
    public GameObject bulletPrefab;
    //Set the position of the gun barrel
    public Transform launchPosition;
    private AudioSource audioSource;
    public bool isUpgraded;
    public float upgradeTime = 10.0f;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void fireBullet()
    {
        Rigidbody bullet = createBullet();
        bullet.velocity = transform.parent.forward * 100;
        if (isUpgraded)
        {
            Rigidbody bullet2 = createBullet();
            bullet2.velocity = 
                (transform.right + transform.forward / 0.5f) * 100;
            Rigidbody bullet3 = createBullet();
            bullet3.velocity = 
                ((transform.right * -1) + transform.forward / 0.5f) * 100;
        }
        if (isUpgraded)
        {
            audioSource.PlayOneShot(SoundManager.Instance.upgradedGunFire);
        }
        else
        {
            audioSource.PlayOneShot(SoundManager.Instance.gunFire);
        }
    }

    public void UpgradeGun()
    {
        isUpgraded = true; currentTime = 0;
    }

    private Rigidbody createBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPosition.position;
        return bullet.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            //Checks if the left mouse is being held down
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }
        //Checks if the left mouse button was released
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
        currentTime += Time.deltaTime;
        if (currentTime > upgradeTime && isUpgraded == true)
        {
            isUpgraded = false;
        }
    }
}
