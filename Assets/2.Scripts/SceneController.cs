using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController:MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);

    }
    public void LoadScene(string _scene)
    {
        //리눅스에선 코루틴이 작동하지 않는 듯 함
        if (Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.LinuxEditor)
        {
            SceneManager.LoadScene(_scene);
        }
        else
        {
            StartCoroutine(LoadSceneCoroutine(_scene));
        }
    }

    IEnumerator LoadSceneCoroutine(string _scene) {
        yield return null;
        //바꿀 장면을 불러옴
        AsyncOperation op = SceneManager.LoadSceneAsync(_scene);
        //장면 전환을 막음
        op.allowSceneActivation = false;
        //장면 불러오기가 끝날때 까지 대기
        while (!op.isDone) {
            yield return null;
            if (op.progress >= 0.9f)
            {
                break;
            }
        }
        //전부 불러와지면 장면 전환 활성화
        op.allowSceneActivation = true;
        //코루틴 종료
        yield break;
    }
}