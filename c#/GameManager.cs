using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 revivePoint;
    public GameObject player;

    public Vector3 offest = new Vector3(0, 0.5f, 0);
    private void Awake()
    {

        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//常用于切换场景时  使对象不销毁
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }


    private void Start()
    {
        //RestGame();
    }


    private void RestGame()
    {
        SceneManager.LoadScene("RunWorld");
        player = Instantiate(player, revivePoint, Quaternion.identity);
    }
  
    public void SetRevivePoint(Transform revivePoint)
    {
        this.revivePoint = revivePoint.position;
        Debug.Log("SetPoint");
    }
    public void Revive()
    {
        Debug.Log("revive");
        //RestGame();
        player.transform.position = revivePoint + offest;
    }
}
