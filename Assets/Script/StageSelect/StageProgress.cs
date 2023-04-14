using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageProgress : MonoBehaviour
{
    public int StageProgressNum;
    // Start is called before the first frame update
    void Start()
    {
        // ステージ進行度のロード
        StageProgressNum = PlayerPrefs.GetInt("STAGEPROGRESS", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNextStage(int StageNum)
    {
        PlayerPrefs.SetInt("STAGEPROGRESS", StageNum);
        PlayerPrefs.Save();
    }

    public void OnStageRestart()
    {
        PlayerPrefs.SetInt("STAGEPROGRESS", 1);
        PlayerPrefs.Save();
    }

    public void OnHomeButton()
    {
        SceneManager.LoadScene("Stage");
    }
}
