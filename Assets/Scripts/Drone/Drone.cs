using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Drone : MonoBehaviour
{

    // Ray
    private RaycastHit _hit;
    private Vector3 _rayDirection;
    private float _rayAngle = -45;
    private float _rayDistance = 15;


    //Movement
    public float speed = 1;
    public float maxHeight = 5;
    public float weavingDistance = 1.5f;
    public float fallbackDistance = 20f;

    public IObjectPool<Drone> Pool { get; set; }
    public float _currentHealth;

    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    private float timeToSelfDestruct = 3f;
    void Start()
    {
        _currentHealth = maxHealth;
        _rayDirection = transform.TransformDirection(Vector3.back) * _rayDistance;
        _rayDirection = Quaternion.Euler(_rayAngle, 0, 0) * _rayDirection;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, _rayDirection, Color.blue);
        if(Physics.Raycast(transform.position,_rayDirection,out _hit, _rayDistance))
        {
            if (_hit.collider)
            {
                Debug.DrawRay(transform.position, _rayDirection, Color.green);
            }
        }
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
  

    public void ApplyStrategy(IManeuverBehaviour strategy)
    {
        strategy.Maneuver(this);
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
