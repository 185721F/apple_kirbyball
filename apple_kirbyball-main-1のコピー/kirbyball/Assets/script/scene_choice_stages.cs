using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class scene_choice_stages : MonoBehaviour {

    public void OnClickStartButton()
    {
      SceneManager.LoadScene("Scenes/choice_stages");
    }

}

public class Data
{
	public readonly static Data Instance = new Data ();

	public string referer = string.Empty;
}
