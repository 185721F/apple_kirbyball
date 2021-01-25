using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class retry : MonoBehaviour {
  public void OnClickStartButton()
  {
    SceneManager.LoadScene($"Scenes/{Data.Instance.referer}");
  }
}
