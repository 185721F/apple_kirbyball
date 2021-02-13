using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMove1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Warp());
    }

    private IEnumerator Warp()
    {
        while (true)
        {
            // 1.5秒後ごとにワープ移動する。
            yield return new WaitForSeconds(1.5f);
            transform.position = new Vector3(-5, 1, -8);

            yield return new WaitForSeconds(1.5f);
            transform.position = new Vector3(-2, 1, 3);

            yield return new WaitForSeconds(1.5f);
            transform.position = new Vector3(10, 1, 0);

            yield return new WaitForSeconds(1.5f);
            transform.position = new Vector3(23, 1, -6);
        }
    }
}
