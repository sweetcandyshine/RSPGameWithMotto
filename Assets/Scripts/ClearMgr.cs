using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearMgr : MonoBehaviour
{
    public Button m_RestartBtn;
    public Button m_RestartWithTitleBtn;
    public Text m_Ending;
    private string m_text = "살아...난 건가?\n눈을 떠 보니 차마 말로 하지 못할 끔찍한 광경이 눈앞에 들어왔다.\n\n\"점호 시간인데 아직도 뭐 하고 있어! 빨리 나와!\"\n당직사관의 외침이 멀리서 들려온다.\n\n살아난 것을 기뻐해야 하는지 의문이 들기 시작했지만,\n지옥에서 영원히 가위바위보를 하는 것보단 나을 것 같았다.\n\n그런 생각이 불현듯 들어 누구보다 빠르고 힘차게 오와 열을 맞추어 밖으로 나갔다.\n이제 다시는 도박에 손을 대지 않을 것이다.\n\n\nThe End";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typeeffect());

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

    IEnumerator _typeeffect()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i <= m_text.Length; i++)
        {
            m_Ending.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
