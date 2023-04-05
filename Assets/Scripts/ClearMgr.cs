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
    private string m_text = "���...�� �ǰ�?\n���� �� ���� ���� ���� ���� ���� ������ ������ ���տ� ���Դ�.\n\n\"��ȣ �ð��ε� ������ �� �ϰ� �־�! ���� ����!\"\n��������� ��ħ�� �ָ��� ����´�.\n\n��Ƴ� ���� �⻵�ؾ� �ϴ��� �ǹ��� ��� ����������,\n�������� ������ ������������ �ϴ� �ͺ��� ���� �� ���Ҵ�.\n\n�׷� ������ ������ ��� �������� ������ ������ ���� ���� ���߾� ������ ������.\n���� �ٽô� ���ڿ� ���� ���� ���� ���̴�.\n\n\nThe End";

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
