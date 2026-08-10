using Unity.VisualScripting;
using UnityEngine;

public class BaseHero : MonoBehaviour
{
    private float _baseSpeed;
    private float _baseMaxHealth;
    private BaseHero _alterHero;

    public void SetBaseSpeed(float speed) 
    {
        _baseSpeed = speed;
    }
    public float GetBaseSpeed()
    {
        return _baseSpeed;
    }

    public void SetBaseMaxHealth(float maxHealth)
    {
        _baseMaxHealth = maxHealth;
    }

    public float GetBaseMaxHealth()
    {
        return _baseMaxHealth;
    }
    
    public virtual void Ability1()
    {
        
    }
    public virtual void Ability2()
    {
        
    }
    public virtual void Ability3()
    {
        
    }
    public virtual void Ability4()
    {
        
    }
    
}
