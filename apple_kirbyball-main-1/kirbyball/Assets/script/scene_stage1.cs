using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class scene_stage1 : MonoBehaviour {

  void Start(){
    Data.Instance.referer = "stage1";
  }

  public void OnClickStartButton()
  {
    SceneManager.LoadScene("Scenes/stage1");
  }
}
