using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
	public UnityEvent onRightClick;


	public GameObject bulletPrefab;

	public int maxAmmo = 10;
	public int ammo;
	public bool isRealoading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;
	public float recoilAngle;
	public int bulletsPerShot = 1;

	


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

		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			onRightClick.Invoke();
		}
	}



	public void Shoot()
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

		for (int i = 0; i < bulletsPerShot; i++)
		{
			var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
			var offsetX = Random.Range(-recoilAngle, recoilAngle);
			var offsetY = Random.Range(-recoilAngle, recoilAngle);
			bullet.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
		}

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