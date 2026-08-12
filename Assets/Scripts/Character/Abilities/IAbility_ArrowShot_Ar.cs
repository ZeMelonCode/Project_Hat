using UnityEngine;

public class IAbility_ArrowShot_Ar : IBaseAbility
{
    private float _cooldown;
    private float _minBowPower;
    private float _maxBowPower;
    private float _bowPower;
    private bool _drawing;
    
    public void activate()
    {
        if (canActivate() && _drawing == false)
        {
            _drawing = true;
        }

        if (canActivate() && _drawing == true)
        {
            Release();
        }
        
    }
    
    public void tick()
    {
        if(_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
        }

        if (_drawing && canActivate())
        {
            if (_bowPower < _maxBowPower)
            {
                _bowPower += Time.deltaTime;
            }
        }
    }
    public bool canActivate()
    {
        return true;
    }

    public float getRemainingCooldown()
    {
        return _cooldown;
    }

    private void Release()
    {
        //Shoot logic here (bowpower + arrow )

        // cd tbd 
        _cooldown = 1; 
    }

    private void Update()
    {
        tick();
    }
}
