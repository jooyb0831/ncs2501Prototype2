using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float xRange = 10;
    public float horizontalInput;
    public float speed = 10.0f;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Move()
    {
        //플레이어 x범위 이동 제한
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }

        //좌우이동
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    void Fire()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
