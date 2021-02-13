﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pullline : MonoBehaviour
{
    Plane groundPlane;
    Vector3 downPosition3D;
    Vector3 upPosition3D;
    Vector3 Position3D;


    private Text numText; // 現在の回数 UI
    public Text numText2; // 残り回数 UI
    public Text gogoText; // 負け、引っ張りすぎの UI
    public GameObject button;//ボタン

    public GameObject sphere;
    public float thrust = 3f;
    public float remain = 6;
    private int num = 0; // 回数
    float distance; //距離
    private float max = 5f; // 制限
    private float mini = -5f;
    public LineRenderer line;

    float rayDistance;
    Ray ray;

    int jumpnumber = 0;
    public float jumpPower = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        groundPlane = new Plane(Vector3.up, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 y3D = new Vector3(0f, 10f, 0f);

        // Rigidbody取得
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        //print(rb.velocity.magnitude);
        Vector3 pos = sphere.transform.position;
        if (rb.IsSleeping())
        {
            // UI の表示を更新します
            SetCountText2();
            if (Input.GetMouseButtonDown(0))
            {

                downPosition3D = GetCursorPosition3D();
            }
            else if (Input.GetMouseButton(0))
            {
                Objectfalse();
                Position3D = GetCursorPosition3D();
                distance = Vector3.Distance(downPosition3D, Position3D);
                Vector3 oppopos1 = pos - Position3D + downPosition3D;
                Vector3 oppopos2 = pos - downPosition3D + downPosition3D;
                Vector3 oppopos = oppopos1;

                line.positionCount = 2;
                line.SetPosition(0, oppopos);
                line.SetPosition(1, oppopos2);
                if (distance < 2.5)
                {
                    line.positionCount = 0;
                }
                else if (distance > 30)
                {
                    line.positionCount = 0;
                    gogoText.enabled = true;
                    gogoText.text = "引っ張りすぎ!!";
                }

            }

            else if (Input.GetMouseButtonUp(0))
            {
                Objectfalse();
                button.gameObject.SetActive(false);
                upPosition3D = GetCursorPosition3D();

                if (downPosition3D != ray.origin && upPosition3D != ray.origin)
                {
                    Vector3 v = new Vector3(1.0f, 0.0f, 1.0f);
                    Vector3 force = downPosition3D - Position3D;
                    //print(distance);
                    //矢印を戻しやすくする。
                    if (distance < 2.5)
                    {
                        force = new Vector3(0.0f, 0.0f, 0.0f);
                    }
                    else if (distance > 30)
                    {
                        force = new Vector3(0.0f, 0.0f, 0.0f);
                    }
                    Vector3 force2 = new Vector3(Mathf.Clamp(force.x, mini, max), 0, Mathf.Clamp(force.z, mini, max));
                    //print(force2);
                    sphere.GetComponent<Rigidbody>().AddForce((force) * thrust, ForceMode.Impulse); // ボールをはじく
                    line.positionCount = 0;
                    if (force != Vector3.zero)
                    {
                        num = num + 1; //回数を加算
                        remain = remain - 1;
                    }
                    // UI の表示を更新します
                    SetCountText();
                }
            }
        }
        else
        {
            numText2.enabled = false;
        }
        if(jumpnumber <= 0)//放ったら一回しか飛べない
        {
            if (Input.GetMouseButtonDown(1)) //右クリックを押した時
            {
                downPosition3D = GetCursorPosition3D();
            }
            else if (Input.GetMouseButtonUp(1)) //右クリックを離した時
            {
                upPosition3D = GetCursorPosition3D();
                if (downPosition3D != ray.origin && upPosition3D != ray.origin)
                {
                    sphere.GetComponent<Rigidbody>().AddForce((y3D) * thrust / 3, ForceMode.Impulse); //ボールを弾く(ジャンプだけできるようにしました)
                    jumpnumber += 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))//スペースキーを押すと飛べる
            {
                rb.AddForce(new Vector3(0.0f, jumpPower, 0.0f));
                jumpnumber += 1;
            }
        }



    }

    Vector3 GetCursorPosition3D()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // マウスカーソルから、カメラが向く方へのレイ
        groundPlane.Raycast(ray, out rayDistance); // レイを飛ばす

        return ray.GetPoint(rayDistance); // Planeとレイがぶつかった点の座標を返す

    }



    // UI の表示を更新する
    void SetCountText()
    {

        // 回数の表示を更新
        //numText.text = "num: " + num.ToString();
    }

    void SetCountText2()
    {
        if (remain == 0)
        {
            gogoText.enabled = true;
            gogoText.text = "You Lose!!";
        }
        else
        {
            // 回数の表示を更新
            gogoText.enabled = true;
            gogoText.text = "gogo!!";
            numText2.enabled = true;
            button.gameObject.SetActive(true);
            numText2.text = "残り" + remain.ToString() + "回";
        }

    }
    void Objectfalse()
    {
        numText2.enabled = false;
        gogoText.enabled = false;
    }


}