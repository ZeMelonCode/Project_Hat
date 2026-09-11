using UnityEngine;

public class HatFactory : MonoBehaviour
{
    [SerializeField] private GameObject hatPrefab;
    [SerializeField] private Transform hatSpawnPoint;
    [SerializeField] private BaseHero _typeOfHat;
    
    public void SpawnHat(Base_Hat hat)
    {
        
    }
}
