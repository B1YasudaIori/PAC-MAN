using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[DisallowMultipleComponent]
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    #region シングルトン
    public static ScoreManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<ScoreManager>();
        }
        return Instance;
    }
    private void Awake()
    {
        if (this != GetInstance())
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public int score = 0;
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        UpdateScoreUI();
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
        // 再ロード後に ScoreText を探す
        ScoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        UpdateScoreUI();
    }


    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if(ScoreText != null)
        {
            ScoreText.text = "Score:" + score.ToString();
        }
    }
}
