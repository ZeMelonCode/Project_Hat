using UnityEngine;

public class ITestAbility1 : IBaseAbility
{
    public void activate()
    {
        Debug.Log("ITestAbility1 activated");
    }

    public void tick()
    {
        Debug.Log("ITestAbility1 ticked");
    }

    public bool canActivate()
    {
        Debug.Log("ITestAbility1 can activate");
        return true;
    }

    public float getRemainingCooldown()
    {
        float remainingCooldown = 0;
        canActivate();
        Debug.Log("ITestAbility1 Cooldown finished");
        return remainingCooldown;
    }
}
