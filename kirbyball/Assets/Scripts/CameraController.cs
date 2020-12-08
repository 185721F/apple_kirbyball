using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController: MonoBehaviour
{

    private Vector3 initialPosition;

    public float count;
    public Text timeLabel;

    // ★★（追加）Lightオブジェクトの情報を入れるための箱を作る。
    private GameObject lightA;
    private GameObject lightB;

    void Start()
    {

        initialPosition = transform.position;

        // ★★（追加）名前で指定して、箱の中に情報を入れる。
        lightA = GameObject.Find("DLight_A");
        lightB = GameObject.Find("DLight_B");
    }

    void Update()
    {
        // ★★（修正）ここが「-=」となっている場合には「+=」に修正しましょう。
        // -=はカウントダウン
        // +=はカウントアップ
        count += Time.deltaTime;

        timeLabel.text = "" + count.ToString("0");
        timeLabel.text = "" + count.ToString("f2");

        // ★★（追加）一定時間が経過すると、Lightオブジェクトを非アクティブにする。
        if (count > 10)
        {
            lightA.SetActive(false);
        }

        if (count > 15)
        {
            lightB.SetActive(false);
            transform.position = new Vector3(Mathf.Sin(Time.time) * 2.0f + initialPosition.x, initialPosition.y, initialPosition.z);
        }

    }
}
