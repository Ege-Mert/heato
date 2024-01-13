using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float heatMeterValue;
    public float maxHeatValue = 100f;
    public float defaultCoolingRate = 1f;
    public float cooldownCoolingRate = 100f; 
    public float heatPerShot = 20f;
    public float projectileForce = 10f;
    public float cooldownDuration = 2f; 


    private bool isCoolingDown = false;
    private float cooldownTimer = 0f;

    public Transform firePoint;
    public GameObject projectilePrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && heatMeterValue < maxHeatValue && !isCoolingDown)
        {
            Shoot();
        }

        if (isCoolingDown)
        {
            heatMeterValue = Mathf.Clamp(heatMeterValue - cooldownCoolingRate * Time.deltaTime, 0f, maxHeatValue);
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                isCoolingDown = false;
            }
        }
        else
        {
            heatMeterValue = Mathf.Clamp(heatMeterValue - defaultCoolingRate * Time.deltaTime, 0f, maxHeatValue);

            if (heatMeterValue >= maxHeatValue)
            {
                StartCooldown();
            }
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
        }

        heatMeterValue += heatPerShot;
    }

    void StartCooldown()
    {
        isCoolingDown = true;
        cooldownTimer = cooldownDuration;
    }
}
