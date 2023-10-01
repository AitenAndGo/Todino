using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float delayTimeInSeconds = 1f;

    private bool nextShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextShoot){
            GameObject closedObject = findClosedEnemy();

            if (closedObject != null)
            {
                // Debug.Log(closedObject);
                // Vector3 direction = (closedObject.transform.position - transform.position).normalized;
                // Shoot after some time
                Shoot(closedObject);
                StartCoroutine(ShootAfterDelay(delayTimeInSeconds));
                nextShoot = false;
            }
        }
    }


    // finding closed enemy

    public string targetTag = "Enemy";
    public float searchRadius = 10f;
    public float closestDistance = Mathf.Infinity;
    GameObject closestObject = null;

    GameObject findClosedEnemy()
    {
        closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(currentPosition, searchRadius);

        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag(targetTag))
            {
                float distance = Vector3.Distance(currentPosition, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = col.gameObject;
                }
            }
        }
        return closestObject;

    }

    // shooting
    void Shoot(GameObject target)
    {
        Vector3 direction = (target.transform.position - firePoint.position).normalized;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        rb.velocity = direction * bulletForce;
    }

    IEnumerator ShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        nextShoot = true;
    }
}
