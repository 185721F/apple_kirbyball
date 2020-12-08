using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMove : MonoBehaviour
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
            transform.position = new Vector3(-5, 1, 0);

            yield return new WaitForSeconds(1.5f);
            transform.position = new Vector3(5, 1, 0);

            yield return new WaitForSeconds(1.5f);
            transform.position = new Vector3(5, 5, 0);

            yield return new WaitForSeconds(1.5f);
            transform.position = new Vector3(-5, 5, 0);
        }
    }
}
