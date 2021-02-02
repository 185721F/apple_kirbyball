using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{

    private float s = 0.01f;

    void Update()
    {
        Vector3 currentScale = transform.localScale;

        if (currentScale.x > 2.0f || currentScale.x < 0.5f)
        {
            s *= -1;
        }

        currentScale.x += s;
        currentScale.y += s;
        currentScale.z += s;

        transform.localScale = currentScale;
    }
}
