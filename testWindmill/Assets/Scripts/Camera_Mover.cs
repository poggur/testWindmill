using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Camera_Mover : MonoBehaviour
{
    Transform transformer;
    public float sens;
    public float moveSpeed;
    [SerializeField] private Slider positionOffset;

    float xRotation, yRotation;

    Quaternion mouseDrag;
    [SerializeField] private Transform rotateAround;

    [HideInInspector] public int cameraModeInt = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformer = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (cameraModeInt == 1)
        {
            Debug.Log("camera mode on wasd");
            WASDRotation();

            WASDTranslation();
        }
        else if (cameraModeInt == 2)
        {
            PivotMovement();
        }

    }

    void WASDRotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        xRotation -= mouseY;
        yRotation += mouseX;

        transformer.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    void WASDTranslation()
    {
        if (Input.GetKey(KeyCode.W))
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

    void PivotMovement()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            xRotation -= mouseY * sens * Time.deltaTime;
            yRotation += mouseX * sens * Time.deltaTime;

            mouseDrag = Quaternion.Euler(xRotation, yRotation, 0f);

            Vector3 position = mouseDrag * new Vector3(0, 0, positionOffset.value);
            transform.position = rotateAround.position + position;
            transformer.rotation = mouseDrag;

        }
    }

    public void SwapCameraMode(int cameraMode)
    {
        cameraModeInt = cameraMode;
    }
}
