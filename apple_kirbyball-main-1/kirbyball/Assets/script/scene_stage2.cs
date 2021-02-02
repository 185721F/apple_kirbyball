using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class scene_stage2 : MonoBehaviour {

  void Start(){
    Data.Instance.referer = "stage2";
  }

  public void OnClickStartButton()
  {
    SceneManager.LoadScene("Scenes/stage2");
  }
}
