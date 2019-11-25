using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLeap : MonoBehaviour
{
    public void SceneClass() { SceneManager.LoadScene(1); }
    public void SceneRoom() { SceneManager.LoadScene(0);}
    public void SceneAuditorium() { SceneManager.LoadScene(2); }
    public void SceneProgramming() { SceneManager.LoadScene(0); }
    public void SceneAudio_Visual() { SceneManager.LoadScene(0); }
    public void SceneOrchestra() { SceneManager.LoadScene(3); }
    public void SceneLap() { SceneManager.LoadScene(4); }
    public void SceneTraining() { SceneManager.LoadScene(0); }
    public void SceneMusic() { SceneManager.LoadScene(0); }
    public void SceneScience() { SceneManager.LoadScene(0); }
}
