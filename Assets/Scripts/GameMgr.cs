using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    //버튼
    public Button ScissorBtn;
    public Button RockBtn;
    public Button PaperBtn;
    public Button TAZZABtn;
    //버튼

    //유저상태, 결과
    public Text UserMoneyText;
    public Text UserStatusText;
    public Text ResultText;
    //유저상태, 결과

    int m_Money = 1000; //보유 자원
    int m_WinCount = 0; //승
    int m_LosCount = 0; //패
    enum RSP
    {
        Rock = 1,
        Scissor = 2,
        Paper = 3
    };

    public int Rock = 1;
    public int Scissor = 2;
    public int Paper = 3;

    string[] RSPResultName = new string[3] { "바위", "가위", "보" }; //결과표시용 배열

    public int Comsel;  //컴퓨터 선택
    public int UserSel; //유저 선택

    [Header("--- Gamble ---")]
    public Slider m_Gamble_Slider;
    public Text m_Gamble_Text;
    int m_Gamble = 100;

    [Header("--- CharacterImage ---")]
    public Image m_CharIMG;
    public Sprite m_Wait;
    public Sprite m_Win;
    public Sprite m_Lost;
    public Sprite m_Draw;

    public Sprite m_DongJakGooManFail;
    public Sprite m_DongJakGooManSuccess;

    public Sprite m_Rock;
    public Sprite m_Scissor;
    public Sprite m_Paper;
    public Sprite m_DecisionWait;
    public Image m_UserSel;
    public Image m_ComSel;

    public RawImage DongJakSuccess;
    public RawImage DongJakFail;
    public Text DongJakText;

    float m_WaitTimer = 5.0f;
    float m_AnimateTimer = 0.1f;
    float TAZZATimer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (ScissorBtn != null) 
            ScissorBtn.onClick.AddListener(() => 
        {
            if (m_Money <= 0)
                return;

            UserSel = Scissor;
            m_UserSel.sprite = m_Scissor;
            RSPCOM();
            RSPResult();

            if (UserMoneyText != null)
                UserMoneyText.text = "삶의 기회 : " + m_Money;
            if (UserStatusText != null)
                UserStatusText.text = "성공[" + m_WinCount + "]회 실패[" + m_LosCount + "]회";

            m_WaitTimer = 3.0f;
            m_AnimateTimer = 3.0f;
        });

        if (RockBtn != null)
            RockBtn.onClick.AddListener(()=>
            {
                if (m_Money <= 0)
                    return;

                UserSel = Rock;
                m_UserSel.sprite = m_Rock;
                RSPCOM();
                RSPResult();

                if (UserMoneyText != null)
                    UserMoneyText.text = "삶의 기회 : " + m_Money;
                if (UserStatusText != null)
                    UserStatusText.text = "성공[" + m_WinCount + "]회 실패[" + m_LosCount + "]회";

                m_WaitTimer = 3.0f;
                m_AnimateTimer = 3.0f;
            });

        if (PaperBtn != null)
            PaperBtn.onClick.AddListener(()=>
            {
                if (m_Money <= 0)
                    return;

                UserSel = Paper;
                m_UserSel.sprite = m_Paper;
                RSPCOM();
                RSPResult();

                if (UserMoneyText != null)
                    UserMoneyText.text = "삶의 기회 : " + m_Money;
                if (UserStatusText != null)
                    UserStatusText.text = "성공[" + m_WinCount + "]회 실패[" + m_LosCount + "]회";

                m_WaitTimer = 3.0f;
                m_AnimateTimer = 3.0f;
            });

        if (TAZZABtn != null)
            TAZZABtn.onClick.AddListener(TAZZABtnClick);
    }

    // Update is called once per frame

    void Update()
    {
        if (m_Money <= 0)
        {
            m_Money = 0;
            SceneManager.LoadScene("GameOverScene");
        }
        if (10000 <= m_Money)
            SceneManager.LoadScene("ClearScene");

        if(0.0f<m_AnimateTimer)
        {
            m_AnimateTimer -= Time.deltaTime;
            if(m_AnimateTimer<=0.0f)
            {
                int RandCOMIMG = Random.Range(1, 4);
                if (RandCOMIMG == 1)
                {
                    m_ComSel.sprite = m_Rock;
                    m_AnimateTimer = 0.1f;
                }
                else if (RandCOMIMG == 2)
                {
                    m_ComSel.sprite = m_Scissor;
                    m_AnimateTimer = 0.1f;
                }
                else if (RandCOMIMG == 3)
                {
                    m_ComSel.sprite = m_Paper;
                    m_AnimateTimer = 0.1f;
                }
            }
        }

        if(0.0f<m_WaitTimer)
        {
            m_WaitTimer -= Time.deltaTime;
            if(m_WaitTimer<=0.0f)
            {
                m_CharIMG.sprite = m_Wait;
                m_UserSel.sprite = m_DecisionWait;
                ResultText.text = "거 빨리빨리 내쇼";
            }
        }


        if (0.0f < TAZZATimer)
        {
            TAZZATimer -= Time.deltaTime;
            if (TAZZATimer <= 0.0f)
            {
                DongJakFail.gameObject.SetActive(false);
                DongJakSuccess.gameObject.SetActive(false);
                DongJakText.gameObject.SetActive(false);
            }
        }

        if (1.0f <= m_Gamble_Slider.value || m_Money < 100)
            m_Gamble = m_Money;
        else
            m_Gamble = 100 + (int)(m_Gamble_Slider.value * (m_Money - 100));

        if (m_Gamble_Text != null)
            m_Gamble_Text.text = "도 박 : " + m_Gamble;
    }

    void RSPCOM()
    {
        Comsel = Random.Range(1, 4);
        if (Comsel == 1)
            m_ComSel.sprite = m_Rock;
        else if (Comsel == 2)
            m_ComSel.sprite = m_Scissor;
        else if (Comsel == 3)
            m_ComSel.sprite = m_Paper;              
    }

    void RSPResult()
    {
        if (UserSel == Comsel)  //비김
        {
            ResultText.text = "당신「" + RSPResultName[UserSel - 1] + "」 악마「" + RSPResultName[Comsel - 1] + "」로 비겼습니다.";
            m_CharIMG.sprite = m_Draw;
        }

        else if ((UserSel == Rock && Comsel == Scissor)||
            (UserSel == Scissor && Comsel == Paper)||
            (UserSel == Paper && Comsel == Rock))  //이김
        {
            ResultText.text = "당신「" + RSPResultName[UserSel - 1] + "」 악마「" + RSPResultName[Comsel - 1] + "」로 이겼습니다.";
            m_WinCount++;
            m_Money += (int)(m_Gamble * 1.7f);
            m_CharIMG.sprite = m_Win;
        }

        else if (UserSel == Rock && Comsel == Paper||
            (UserSel == Scissor && Comsel == Rock)||
            (UserSel == Paper && Comsel == Scissor))    // 짐
        {
            ResultText.text = "당신「" + RSPResultName[UserSel - 1] + "」 악마「" + RSPResultName[Comsel - 1] + "」로 졌습니다.";
            m_LosCount++;
            m_Money -= (int)(m_Gamble*1.3f);
            if (m_Money <= 0)
                     m_Money = 0;
                m_CharIMG.sprite = m_Lost;
        }
    }

    void TAZZABtnClick()
    {
        if (m_Money <= 0)
            return;

        float a_DONGJAKSUCCESSFAIL = Random.Range(0.0f, 1.0f);
        if (a_DONGJAKSUCCESSFAIL <= 0.35)  //밑장빼기 성공
        {
            DongJakFail.gameObject.SetActive(false);
            DongJakSuccess.gameObject.SetActive(true);
            DongJakText.gameObject.SetActive(true);

            m_WinCount++;
            m_Money += 350;
            m_Money += (int)(m_Gamble * 2.0f);

            TAZZATimer = 1.5f;
        } //성공

        else  //실패
        {
            DongJakSuccess.gameObject.SetActive(false);
            DongJakText.text = "동작 그만, 밑장빼기냐?";

            DongJakFail.gameObject.SetActive(true);
            DongJakText.gameObject.SetActive(true);

            m_LosCount++;
            m_Money -= 300;
            if (m_Money <= 0)
                m_Money = 0;
            m_Money -= (int)(m_Gamble * 1.3f);
            if (m_Money <= 0)
                m_Money = 0;
            m_Money -= m_Gamble;

            TAZZATimer = 1.5f;
        } //실패


        if (UserMoneyText != null)
            UserMoneyText.text = "삶의 기회 : " + m_Money;
        if (UserStatusText != null)
            UserStatusText.text = "성공[" + m_WinCount + "]회 실패[" + m_LosCount + "]회";

        m_WaitTimer = 3.0f;
    }
}
