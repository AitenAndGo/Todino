using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    Rigidbody boddy;
    public float speed = 5f;
    private Vector3 m_Velocity = Vector3.zero;
    List<Vector2> road;
    private int currentPointIndex = 0;
    public int roadIndex = 0;
    public float dinoDamage = 5f;
    private bool canDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        boddy = GetComponent<Rigidbody> ();
        Map map = FindObjectOfType<Map>();

        if (map != null && map.roads != null)
        {
            List<Vector2> _road = map.roads[roadIndex];
            setRoad(_road);
        }
        else
        {
            Debug.LogError("Nie można znaleźć Mapy lub drogi.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera_position = FindObjectOfType<CameraControl>().transform.position;
        rotate(camera_position);
    }

    void rotate(Vector3 targetPosition)
    {
        // Pobierz aktualną pozycję obiektu
        Vector3 objectPosition = transform.position;
        // Ustaw y na takie same, aby obiekt nie obracał się wokół osi y
        targetPosition.y = objectPosition.y;
        // Obróć obiekt w stronę kamery
        transform.LookAt(targetPosition);
    }

    public void setRoad(List<Vector2> _road){
        road = _road;
    }


    void FixedUpdate() {
        if (road != null){
            if (currentPointIndex < road.Count)
            {
                Vector2 targetPoint = road[currentPointIndex];
                // Debug.Log("target: " + targetPoint);
                // Debug.Log("position: " + transform.position);
                

                float x_dir = Mathf.Sign(targetPoint.x - transform.position.x);
                float y_dir = Mathf.Sign(targetPoint.y - transform.position.z);

                Vector3 targetVelocity = new Vector3(x_dir * speed, 0f, y_dir * speed);

                // Vector3 targetVelocity = new Vector3(x_dir * speed, 0f, y_dir * speed);
                // Debug.Log("velocity: " + targetVelocity);
                transform.position += targetVelocity * Time.fixedDeltaTime;

                float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), targetPoint);

                if (distance < 0.1f)
                {
                    currentPointIndex++;
                }
            } else if (canDamage){
                HealthMainTower health = FindObjectOfType<HealthMainTower>();
                if (health != null)
                {
                    // Wywo�ujemy funkcj� TakeDamage, aby odj�� zdrowie
                    StartCoroutine(ShootAfterDelay(1f, health));
                    canDamage = false;
                }
            }
        }
    }

    IEnumerator ShootAfterDelay(float delay, HealthMainTower health)
    {
        yield return new WaitForSeconds(delay);
        health.TakeDamage(dinoDamage);
        canDamage = true;
    }
}
