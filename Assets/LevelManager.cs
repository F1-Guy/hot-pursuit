using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject deathPanel;

    private void Awake(){
        if(LevelManager.instance==null) instance=this;
        else Destroy(gameObject);
    }

    public void GameOver(){
        UIManager _ui=GetComponent<UIManager>();
        if(_ui!=null){
            _ui.ToggleDeathPanel();
        }
    }


     public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    {
        deathPanel.SetActive(true);
    }
}
}
