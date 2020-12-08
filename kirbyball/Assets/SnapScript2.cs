using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScript2 : MonoBehaviour
{
    Plane groundPlane;
    Vector3 downPosition3D;
    Vector3 upPosition3D;

    public GameObject sphere;
    public float thrust = 3f;

    float rayDistance;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        groundPlane = new Plane(Vector3.up, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックを押した時
        {
            downPosition3D = GetCursorPosition3D();
        }
        else if (Input.GetMouseButtonUp(0)) // 左クリックを離した時
        {
            upPosition3D = GetCursorPosition3D();

            if (downPosition3D != ray.origin && upPosition3D != ray.origin)
            {
                sphere.GetComponent<Rigidbody>().AddForce((downPosition3D - upPosition3D) * thrust, ForceMode.Impulse); // ボールをはじく
            }
        }

    }

    Vector3 GetCursorPosition3D()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // マウスカーソルから、カメラが向く方へのレイ
        groundPlane.Raycast(ray, out rayDistance); // レイを飛ばす

        return ray.GetPoint(rayDistance); // Planeとレイがぶつかった点の座標を返す

    }

}

