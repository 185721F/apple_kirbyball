using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private bool stop = false;

    void Update()
    {

        if (stop == false)
        {
            // 1フレームごとにY軸を中心に４５度角度を変える。
            transform.Rotate(new Vector3(0, 45, 0));
        }

        // 1フレームでストップさせて、１フレームで４５度変化していることを確認する。
        
    }
}
