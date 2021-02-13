using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    // 大きさをInspector上で自由に設定できるようにする
    public Vector3 scale;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
    }
}
