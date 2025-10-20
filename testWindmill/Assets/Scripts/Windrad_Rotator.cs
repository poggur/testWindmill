using UnityEngine;

public class Windrad_Rotator : MonoBehaviour
{
    private Transform transformer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transformer.transform.Rotate(0f, 0.05f, 0f);
    }
}
