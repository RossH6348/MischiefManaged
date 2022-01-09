using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float mouseX = 0.0f;
    public float mouseY = 0.0f;
    float sensitivity = 2.0f;
    GameObject player;
    Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        playerCamera = this.gameObject.transform.GetChild(0).GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;

        if (mouseY > 46.0f)
            mouseY = 46.0f;
        else if (mouseY < 0.0f)
            mouseY = 0.0f;

        player.transform.localRotation = Quaternion.Euler(0.0f, mouseX, 0.0f);
        playerCamera.transform.localRotation = Quaternion.Euler(mouseY, 0.0f, 0.0f);

        float zoomScale = 1.0f - (mouseY / 46.0f);
        playerCamera.fieldOfView = 45.0f + (45.0f * zoomScale);

        float speedX = 0.0f;
        float speedZ = 0.0f;

        if (Input.GetKey(KeyCode.W))
            speedZ += 1.5f;

        if (Input.GetKey(KeyCode.S))
            speedZ -= 1.5f;

        if (Input.GetKey(KeyCode.D))
            speedX += 1.5f;

        if (Input.GetKey(KeyCode.A))
            speedX -= 1.5f;

        player.transform.position += (player.transform.forward * speedZ + player.transform.right * speedX) * Time.deltaTime;

    }
}
