using UnityEngine;

public class ITestAbility3 : IBaseAbility
{
    public void activate()
    {
        Debug.Log("ITestAbility3 activated");
    }

    public void tick()
    {
        Debug.Log("ITestAbility3 ticked");
    }

    public bool canActivate()
    {
        Debug.Log("ITestAbility3 can activate");
        return true;
    }

    public float getRemainingCooldown()
    {
        float remainingCooldown = 0;
        canActivate();
        Debug.Log("ITestAbility3 Cooldown finished");
        return remainingCooldown;
    }
}
