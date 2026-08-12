using Unity.VisualScripting;
using UnityEngine;

public class BaseHero : MonoBehaviour
{
    private float _baseSpeed;
    private float _baseMaxHealth;
    private BaseHero _alterHero;

    private IBaseAbility _ability1;
    private IBaseAbility _ability2;
    private IBaseAbility _ability3;
    private IBaseAbility _ability4;
    
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

    public virtual void ClassPasssive()
    {
        
    }
}
