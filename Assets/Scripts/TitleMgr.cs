using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{
    public Button m_StartBtn;
    public Text m_Synopsis;
    private string m_text = "평소에 불법 도박과 토토를 즐기던 주인공(20대, 남성)...\n어느 날 눈을 떠 보니 사방이 불타는 지옥과도 같은 풍경이었다.\n\n당황하여 바닥에 주저앉은 주인공,\n그때 어디선가 목소리가 들려온다.\n\n\"가위바위보로 날 이긴다면 너를 이곳에서 내보내주겠다.\"\n\n가위바위보? 내가 지금 어디 있는지도 모르는데,\n헛소리까지 들으려니 어이가 없었다.\n\n\"만 점이면 된다. 쫄리면 뒈지시던가.\"\n\n아시아 최상위권 갬블러이자 5대 도박을 마스터한 나에게 감히 도발을 하다니?\n곧바로 거래를 받아들였다.\n\n\n\n버튼 눌러 계속";
    public Text Gamestart;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typeeffect());

        if (m_StartBtn != null)
        {
            m_StartBtn.onClick.AddListener(() =>
              { SceneManager.LoadScene("GameScene"); });
        }
    }

    IEnumerator _typeeffect()
    {
        yield return new WaitForSeconds(0.1f);
        for(int i=0; i<=m_text.Length; i++)
        {
            m_Synopsis.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }

        Gamestart.text = "GAME START";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
