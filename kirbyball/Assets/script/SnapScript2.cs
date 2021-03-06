﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnapScript2 : MonoBehaviour
{
    Plane groudPlane;
    Vector3 downPosition3D;
    Vector3 upPosition3D;
    Vector3 y3D;
    GameObject text;
    private int bat;
    int jumpnumber = 0;
    public float jumpPower = 100.0f; 
    public GameObject sphere;
    public float thurst = 3f;
    public GameObject score_object = null;
    public Text countText;
    public Text winText;
    public Text pushText;

    private Rigidbody rb;
    private int count;
    private int num = 1;

    float rayDistance;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        groudPlane = new Plane(Vector3.up, 0f);
        this.text = GameObject.Find("Text");
        rb = GetComponent<Rigidbody>();
        bat = 5;
        
    }
        

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, Vector3.down);
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        float speed = rb.velocity.magnitude;
        Vector3 y3D = new Vector3(0f, 10f, 0f);
        if(speed == 0.00000){
            if (Input.GetMouseButtonDown(0)) //左クリックを押した時
            {
                downPosition3D = GetCursorPosition3D();
            }
            else if (Input.GetMouseButtonUp(0)) //左クリックを離した時
            {
                upPosition3D = GetCursorPosition3D();
                if (downPosition3D != ray.origin && upPosition3D != ray.origin)
                {
                    sphere.GetComponent<Rigidbody>().AddForce((downPosition3D - upPosition3D) * thurst, ForceMode.Impulse); //ボールを弾く
                    
                }
            }
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
                    sphere.GetComponent<Rigidbody>().AddForce((y3D) * thurst / 3, ForceMode.Impulse); //ボールを弾く(ジャンプだけできるようにしました)
                    jumpnumber += 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))//スペースキーを押すと飛べる
            {
                rb.AddForce(new Vector3(0.0f, jumpPower, 0.0f));
                jumpnumber += 1;
            }
        }
         
        SetCountText();
        speedzero();
    }
    Vector3 GetCursorPosition3D()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//マウスカーソルから,カメラが向く方向へのレイ

        groudPlane.Raycast(ray, out rayDistance); //レイを飛ばす

        return ray.GetPoint(rayDistance);//Planeとレイがぶつかった点の座標を返す
    }

    void speedzero(){
        float speed = rb.velocity.magnitude;
        if(speed == 0){
            this.text.GetComponent<Text>().text = "GO!GO!";
            jumpnumber = 0;
            if(num == 0){//止まった時一回だけ打つ回数を減らす
                bat = bat - 1;
                num += 1;
            }
        }
        if(speed != 0){
            this.text.GetComponent<Text>().text = " ";
            num = 0;//打ったら回数数えられるようになる。
        }
    }


    void SetCountText()
    {
        float speed = rb.velocity.magnitude;
        // 回数の表示を更新
        Text score_text = score_object.GetComponent<Text> ();
        // テキストの表示を入れ替える
        score_text.text = "残り回数:" + bat ;

        if(bat == 0){
            SceneManager.LoadScene("Scenes/gameover");
        }
        
    }
}

