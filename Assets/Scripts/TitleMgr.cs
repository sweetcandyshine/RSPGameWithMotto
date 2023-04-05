using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{
    public Button m_StartBtn;
    public Text m_Synopsis;
    private string m_text = "��ҿ� �ҹ� ���ڰ� ���並 ���� ���ΰ�(20��, ����)...\n��� �� ���� �� ���� ����� ��Ÿ�� �������� ���� ǳ���̾���.\n\n��Ȳ�Ͽ� �ٴڿ� �������� ���ΰ�,\n�׶� ��𼱰� ��Ҹ��� ����´�.\n\n\"������������ �� �̱�ٸ� �ʸ� �̰����� �������ְڴ�.\"\n\n����������? ���� ���� ��� �ִ����� �𸣴µ�,\n��Ҹ����� �������� ���̰� ������.\n\n\"�� ���̸� �ȴ�. �̸��� �����ô���.\"\n\n�ƽþ� �ֻ����� �������� 5�� ������ �������� ������ ���� ������ �ϴٴ�?\n��ٷ� �ŷ��� �޾Ƶ鿴��.\n\n\n\n��ư ���� ���";
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
