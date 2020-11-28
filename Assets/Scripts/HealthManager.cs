using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public playerMovement thePlayer;

    public Renderer blob;

    public Material hurtMaterial;
    public Material neutralMaterial;

    public static bool isHurt = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        thePlayer = FindObjectOfType<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHurt)
        {
            blob.material = hurtMaterial;
        }
        else if(blob.material != neutralMaterial)
        {
            blob.material = neutralMaterial;
            isHurt = false;
        }

    }

    public void HurtPlayer(int damage, Vector3 knockbackDirection)
    {
        currentHealth -= damage;
        thePlayer.Knockback(knockbackDirection);
        isHurt = true;
    }

    public void HealPlayer(int healAmmount)
    {
        currentHealth += healAmmount;
        
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }    
    }
}
