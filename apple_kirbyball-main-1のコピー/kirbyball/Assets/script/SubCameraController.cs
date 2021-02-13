using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{

    public GameObject player;
    public GameObject mainCamera;
    public float rotate_speed;
    private Vector3 offset; // 玉からカメラまでの距離

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.Find("Player");
        offset = mainCamera.transform.position - player.transform.position;
        //offset = transform.position - player.transform.position;
        //transform.position = player.transform.position + offset;
    }

    void OnEnable()
    {
        print("アクティブ");
        print(mainCamera.transform.position);
        transform.position = player.transform.position + offset;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rotateCmaeraAngle();
        }
    }

    private void rotateCmaeraAngle()
    {
        Vector3 angle = new Vector3(
            Input.GetAxis("Mouse X") * rotate_speed,
            Input.GetAxis("Mouse Y") * rotate_speed,
            0
        );

        transform.eulerAngles += new Vector3(angle.y, angle.x);
    }
}