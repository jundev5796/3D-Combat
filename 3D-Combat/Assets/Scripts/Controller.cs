using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Camera")]
    public Transform camAxis_Central; // Camera Axis
    public Transform cam; // Camera
    public float camSpeed; // Camera rotation speed
    float mouseX; // mouse x-coord movement
    float mouseY; // mouse y-coord movement
    float wheel; // mouse wheel


    void Start()
    {
        wheel = -5;
        mouseY = 3;
    }


    void Update()
    {
        CamMove(); // 카메라 회전
        Zoom(); // 카메라 위치 조정
    }


    void CamMove()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        if (mouseY > 10)
            mouseY = 10;
        if (mouseY < -5)
            mouseY = -5;

        camAxis_Central.rotation = Quaternion.Euler(new Vector3(
            camAxis_Central.rotation.x + mouseY, 
            camAxis_Central.rotation.y + mouseX, 
            0
        ) * camSpeed); // camera rotation
    }


    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel") * 10; // 마우스 휠 이동
        if (wheel >= -5)
            wheel = -5;
        if (wheel <= -20)
            wheel = -20;

        cam.localPosition = new Vector3(0, 0, wheel); // 카메라 위치
    }
}
