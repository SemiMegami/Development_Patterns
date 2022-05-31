using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Drone : MonoBehaviour
{
    public IObjectPool<Drone> Pool { get; set; }
    public float _currentHealth;

    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    private float timeToSelfDestruct = 3f;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        AttackPlayer();
        StartCoroutine(SelfDestruct());
    }

    private void OnDisable()
    {
        ResetDrone();
    }
  

    private void ReturnToPool()
    {
        if(Pool != null)
        {
            Pool.Release(this);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    private void ResetDrone()
    {
        _currentHealth = maxHealth;
    }

    public void AttackPlayer()
    {
        Debug.Log("Attack Player!");
    }
    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if(_currentHealth <= 0)
        {
            ReturnToPool();
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToSelfDestruct);
        TakeDamage(maxHealth);
    }


}
