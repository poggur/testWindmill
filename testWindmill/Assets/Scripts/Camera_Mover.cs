using UnityEngine;

public class Camera_Mover : MonoBehaviour
{
    Transform transformer;
    public float sensX;
    public float sensY;

    public float moveSpeed;

    float xRotation, yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformer = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();

        Translation();
    }

    void Rotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        xRotation -= mouseY;
        yRotation += mouseX;

        transformer.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    void Translation()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += (Vector3.forward.z * transform.forward) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.back.z * transform.forward) * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.right.x * transform.right) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.left.x * transform.right) * Time.deltaTime * moveSpeed;
        }
    }
}
