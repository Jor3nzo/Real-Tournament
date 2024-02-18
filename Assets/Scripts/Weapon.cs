using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;

	public int maxAmmo = 10;
	public int ammo;
	public bool isRealoading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;


    private void Start()
    {
		ammo = maxAmmo;
		
    }


    void Update()
	{
		if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();		
		}

		if (isAutoFire && Input.GetKey(KeyCode.Mouse0))
		{
			Shoot();
		}

		if (Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
        {
			Reload();
        }

		fireCooldown -= Time.deltaTime;

	}

	void Shoot()
	{
		if (isRealoading) return;
		if (ammo <= 0)
        {
			Reload();
			return;
        }
		if (fireCooldown > 0) return;
  
		ammo--;
		fireCooldown = fireInterval;
		Instantiate(bulletPrefab,transform.position,transform.rotation);
	}

	async void Reload()
	{
		if (isRealoading) return;
		isRealoading = true;
		await new WaitForSeconds(2f);
		ammo = maxAmmo;
		isRealoading = false;
		print("Realoaded");
	}

	
}