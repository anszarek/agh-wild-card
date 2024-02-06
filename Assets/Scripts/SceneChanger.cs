using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private int sceneID;

    [SerializeField]
    private Animator transition;

    public int GetSceneID()
    {
        return sceneID;
    }

    public void SetSceneID(int newID)
    {
        sceneID = newID;
    }

    public void ChangeScene()
    {
        StartCoroutine(LoadScene());
    }

    public void LoadSubScene()
    {
        SceneManager.LoadScene(sceneID);
    }

    IEnumerator LoadScene()
    {
        transition.SetTrigger(CHANGE_SCENE);

        yield return new WaitForSeconds(TRANSITION_TIME);

        SceneManager.LoadScene(sceneID);
    }
}
