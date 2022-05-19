using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    bool LevelFinished = false;

    [Header("UI")]
    public Slider timerSlider;
    public GameObject deadUI;
    public GameObject WinUI;

    [Header("Hearts")]
    public int MaxHearts = 3;
    public int numOfHearts = 3;

    public Image[] Hearts;

    [Header("Parameters")]
    public Vector2 lastJumpPos;
    public CameraFollow cameraFollow;

    public PlatformerPlayerMovement platformerPlayer;

    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = platformerPlayer.MaxTime;
        timerSlider.value = platformerPlayer.timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        
        float time = platformerPlayer.timeRemaining;

        timerSlider.value = time;

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                Hearts[i].enabled = true;
            } else {
                Hearts[i].enabled = false;
            }
        }

        if (LevelFinished == true && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
        if (gameEnded == true && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        if (LevelFinished == false)
        {
            LevelFinished = true;

            platformerPlayer.enabled = false;

            WinUI.SetActive(true);
        }
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;

            cameraFollow.enabled = false;

            deadUI.SetActive(true);
        }
    }
}
