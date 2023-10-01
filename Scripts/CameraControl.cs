using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float cam_y = 8.5f;
    public float cam_x = 0f;
    public float cam_z = -10f;

    [Range(0.0f, 360.0f)]
    public float position = 0.0f;
    private float last_position = 0.0f;

    private float radius = 30f;
    float scroll = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(cam_x, cam_y, cam_z);
        transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        scroll += Input.GetAxis("Mouse ScrollWheel");
        // Debug.Log(scroll);
        position = map_scroll(scroll);
        if (position != last_position){
            changePosition(position);
            last_position = position;
        }
    }

    public void changePosition(float angle)
    {
        float rad = angle * (Mathf.PI / 180f);
        float x = radius * Mathf.Sin(rad);
        float y = radius * Mathf.Cos(rad);
        transform.position = new Vector3(x, transform.position.y, y);

        transform.LookAt(new Vector3(0, 2, 0));
    }

    public float map_scroll(float scroll){
        return 180.0f * scroll * 0.1f + 180;
    }
}
