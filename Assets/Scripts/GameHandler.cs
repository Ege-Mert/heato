using UnityEngine;
using CodeMonkey;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public HealthBar healthBar;

    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);


        healthBar.Setup(healthSystem);
        
        Debug.Log("Health :"+healthSystem.GetHealthPercent());
        healthSystem.Damage(10);
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