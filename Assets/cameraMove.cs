using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.1f);
    private Camera mainCamera;
    private Vector2 lastMousePosition;
    private Vector2 newAngle = Vector2.zero;

    private Rigidbody rigidbody;

    [SerializeField] float power = 0.1f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        mainCamera = Camera.main;
    }

    void Update()
    {
        newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
        newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;

        mainCamera.transform.localEulerAngles = newAngle;
        lastMousePosition = Input.mousePosition;

        newAngle = mainCamera.transform.localEulerAngles;
        lastMousePosition = Input.mousePosition;

        //操作
        Move();

    }
    void Move()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 moveVector = new Vector3(mainCamera.transform.forward.x, 0.0f, mainCamera.transform.forward.z);

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.transform.position += moveVector * power;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.transform.position -= moveVector * power;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.transform.position += moveVector * power;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.transform.position += moveVector * power;
        }
    }

    //床に触れている間
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "pPlane1")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidbody.velocity = new Vector3(0, 5, 0);
            }
        }
    }
}