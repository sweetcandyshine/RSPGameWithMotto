using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMgr : MonoBehaviour
{
    public Button m_RestartBtn;
    public Button m_RestartWithTitleBtn;

    // Start is called before the first frame update
    void Start()
    {
        if (m_RestartBtn != null)
        {
            m_RestartBtn.onClick.AddListener(() =>
            { SceneManager.LoadScene("GameScene"); });
        }

        if (m_RestartWithTitleBtn != null)
        {
            m_RestartWithTitleBtn.onClick.AddListener(() =>
            { SceneManager.LoadScene("TitleScene"); });
        }
    }
}
