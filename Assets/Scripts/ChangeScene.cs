using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeBoard()
    {
        SceneManager.LoadScene("Board");
    }
    public void ChangeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ChangePass()
    {
        SceneManager.LoadScene("PassTurn");
    }
    public void ChangeScores()
    {
        SceneManager.LoadScene("Scores");
    }
    public void ChangeRules()
    {
        SceneManager.LoadScene("Rules");
    }
}
