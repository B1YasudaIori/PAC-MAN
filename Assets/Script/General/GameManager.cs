using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] private Transform Cookies;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Cookies = GameObject.Find("Cookies")?.transform; // オブジェクト名注意
    }


    public void CheckCookies()
    {
        foreach (Transform cookie in Cookies)
        {
            if (cookie.gameObject.activeSelf)
            {
                return;
            }
        }
        Debug.Log("CLEAR");
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOver()
    {
        Debug.Log("GAMEOVER");
        ScoreManager.GetInstance().score = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void ApplicationEnd()
    {
            Application.Quit();
    }
}