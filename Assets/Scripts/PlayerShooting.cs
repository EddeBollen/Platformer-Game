using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject bulletPrefab; 
    public float bulletSpeed = 20f;
    public float fireRate = 2f; 

    private Camera mainCamera;
    private float lastShotTime;

    private void Start()
    {
        mainCamera = Camera.main; 
    }

    private void Update()
    {
        Aim();

        if (Input.GetButton("Fire1") && Time.time >= lastShotTime + 1f / fireRate)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    private void Aim()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 aimDirection = (mousePosition - firePoint.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Shoot()
    {
       
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}
