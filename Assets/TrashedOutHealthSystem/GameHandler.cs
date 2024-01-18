using UnityEngine;
using CodeMonkey;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public Transform pfHealthBar;
    

    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0,4), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        Debug.Log("Health :"+healthSystem.GetHealthPercent());
        healthSystem.Damage(40);
        Debug.Log("Health :"+healthSystem.GetHealthPercent());
        
        CMDebug.ButtonUI(new Vector2(100, 100), "damage", () =>{
            healthSystem.Damage(10);
            Debug.Log("Damaged :"+healthSystem.GetHealth());
        } );

        CMDebug.ButtonUI(new Vector2(-100, 100), "heal", () =>{
            healthSystem.Heal(10);
            Debug.Log("Healed :"+healthSystem.GetHealth());
        } );
    }
}