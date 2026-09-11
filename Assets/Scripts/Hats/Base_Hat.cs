using UnityEngine;

public class Base_Hat : MonoBehaviour
{
  private BaseHero _hero;

  
  public BaseHero getHero()
  {
    return _hero;
  }

  public void setHero(BaseHero hero)
  {
    if (_hero != null)
    {
      _hero = hero;
    }
    
  }
  
  //TO improve performance, hats will be initialized and disabled rather than created and deleted. 
  
  public void SpawnHat(Transform spawnPoint)
  {
    enabled = true;
    transform.position = spawnPoint.position;
    transform.rotation = spawnPoint.rotation;
  }

  public void DespawnHat()
  {
    enabled = false;
  }
}
