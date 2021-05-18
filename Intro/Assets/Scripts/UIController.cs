using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    enum UIObj { mainUI, example1, frequentUI, example2, example3Image, example4, fingerImage, keypadPanel, cards, 
        combineModelImage, inputBoxImage, nextText, titleText, foregroundPanel, mainText, startBarImage, panelForSample,  
        card1Text, card2Text, card3Text, card4Text, startText, subtitleText, leftText, inputNumberText };

    GameObject[] obj = new GameObject[25];

    Transform tempT;
    Transform tempParentT;
    int objCount = 0;

    Text txt;
    Button[] buttons = new Button[16];
    int nextBtnCnt = 0;
    Color color;
    RectTransform fingerParent;
    const string defaultTitle = "초기 수 감각";
    const string defaultSubtitle = "1학년 1학기 - 1. 수의 크기";
    const string defaultMainText = " \" 지금부터 수의 크기를 비교하는 문제를 풀어볼게요. \"\n" + "\" 같이 연습해 볼까요? \"";
    Vector3 defaultMainTextPos = new Vector3(0, 293, 0);
    Queue expression = new Queue();
    String numToOperate = "";
    int calResult = 0;

    private void Awake()
    {
        int objNum;
        int i = 1;
        InitIterate(1, -1);

        i = 0;
        objNum = (int)UIObj.frequentUI;
        InitIterate(i, objNum);

        objNum = (int)UIObj.example4;
        InitIterate(i, objNum);

        int childIdx = 2;
        InitBGChild(childIdx); // nextText
        childIdx = 1;
        InitBGChild(childIdx); // TitleText
        childIdx = 0;
        InitBGChild(childIdx); // ForegroundPanel

        i = 1;
        objNum = (int)UIObj.foregroundPanel;
        InitIterate(i, objNum);

        objNum = (int)UIObj.cards;
        for (int j = 0; j < obj[objNum].transform.childCount; j++)
        {
            tempParentT = obj[objNum].transform.GetChild(j).transform; // "Card" + i + " Image"
            tempT = tempParentT.GetChild(0).transform; // "Card"+j+" Main Image"
            obj[objCount] = tempT.GetChild(0).gameObject;
            objCount++;
        }

        objNum = (int)UIObj.startBarImage;
        tempT = obj[objNum].transform;
        InitUsingTemp(tempT); // StartText

        objNum = (int)UIObj.titleText;
        tempParentT = obj[objNum].transform; // TitleText
        tempT = tempParentT.GetChild(0).transform; // Line Image
        InitUsingTemp(tempT); // SubtitleText

        objNum = (int)UIObj.example1;
        tempParentT = obj[objNum].transform.GetChild(0).transform; // Left Square Border Image
        tempT = tempParentT.GetChild(0).transform; // Left Square Main Image
        InitUsingTemp(tempT); // Left Text

        objNum = (int)UIObj.inputBoxImage;
        tempParentT = obj[objNum].transform;
        tempT = tempParentT.GetChild(0).transform;
        InitUsingTemp(tempT); // inputNumberText
    }

    private void InitUsingTemp(Transform t)
    {
        obj[objCount] = t.GetChild(0).gameObject; // Next Text
        objCount++;
    }

    private void InitBGChild(int childIdx)
    {
        Transform commonUIT = transform.GetChild(0).transform;
        Transform backgroundPT = commonUIT.GetChild(0).transform;
        tempT = backgroundPT.GetChild(childIdx).transform;
        obj[objCount] = tempT.GetChild(0).gameObject;
        objCount++;
    }

    private void InitIterate(int init, int objNum=-1)
    {
        int comp;
        GameObject initObj;
        if (objNum != -1)
        {
            comp = obj[objNum].transform.childCount;
            initObj = obj[objNum];
        }
        else {
            comp = transform.childCount;
            initObj = gameObject;
        }
        for (int i = init; i < comp; i++)
        {
            obj[objCount] = initObj.transform.GetChild(i).gameObject;
            objCount++;
        }
    }

    void Start()
    {
        Reset(defaultMainTextPos);

        buttons = GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(OnClickListenButton); // 음성듣기 버튼
        buttons[1].onClick.AddListener(OnClickNextButton);   // 다음으로 버튼
        for (int i = 0; i < 10; i++) {
            buttons[2 + i].onClick.AddListener(OnClickNumButton);
        }
        for (int i = 0; i < 3; i++) {
            buttons[12].onClick.AddListener(OnClickOpButton);
        }

        fingerParent = obj[(int)UIObj.frequentUI].GetComponent<RectTransform>();
    }

    // TODO : 수정해야 함. +, -, = 버튼 누르면 호출
    private void OnClickOpButton()
    {
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;
        GameObject btnChild = tempBtn.transform.GetChild(0).gameObject;
        String btnText = btnChild.GetComponent<Text>().text;
        if (numToOperate != "")
        {
            expression.Enqueue(numToOperate); // 입력된 숫자 넣기
            numToOperate = "";
            txt = obj[(int)UIObj.inputNumberText].GetComponent<Text>();
            txt.text = ""; // inputNumberText 비우기
            if (btnText == "+" | btnText == "-")
            {
                expression.Enqueue(btnText); // 연산자 넣기
            }
            else if (btnText == "=")
            {                
                int left = 0;
                int right = 0;
                while (expression.Count > 0)
                {
                    String exp = (string)expression.Dequeue();
                    if (exp == "+")
                    {
                        String temp = (string)expression.Dequeue();
                        if (temp != "+" && temp != "-") // temp가 숫자이면
                        {
                            int.TryParse(temp, out right); // right = (int)temp; 대신 사용 => 이거는 오류나서 대신
                            calResult = left + right;
                            left = calResult;
                        }
                        else { // 숫자가 아니면
                            
                        }
                    }
                    else if (exp == "-")
                    {
                        String temp = (string)expression.Dequeue();
                        if (temp != "+" && temp != "-")
                        {
                            int.TryParse(temp, out right); // right = (int)temp; 대신 사용 => 이거는 오류나서 대신
                            calResult = left - right;
                            left = calResult;
                        }
                    }
                    else
                    {
                        //String temp = (string)expression.Dequeue();
                        //int.TryParse(temp, out left);
                        int.TryParse(exp, out left);
                    }
                }
                Debug.Log(calResult);
            }

        }
        // numToOperate가 null인 경우에는 아무 동작 하지 않음. (모든 연산 기호 : +, -, = 무시)

    }

    public void OnClickNumButton()
    {
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;
        GameObject btnChild = tempBtn.transform.GetChild(0).gameObject;
        txt = obj[(int)UIObj.inputNumberText].GetComponent<Text>();
        txt.text += btnChild.GetComponent<Text>().text;
        numToOperate += txt.text;
    }

    private void OnClickNextButton()
    {
        // Debug.Log("Next Button");
        int objNum;
        nextBtnCnt++;

        if (nextBtnCnt == 1)
        {
            PlayExample1();
        }
        else if (nextBtnCnt == 2)
        {
            objNum = (int)UIObj.example1;
            obj[objNum].SetActive(false);

            String mainTxt = "\" 답을 선택하면 다음 문제로 넘어가요. \"\n" + "\" 시작하기 전에 먼저 연습문제를 풀어볼까요? \"";
            Reset(defaultMainTextPos, mainTxt);
        }
        else if (nextBtnCnt == 3)
        {
            String mainTxt = "\" 이제 시작해 볼까요? \"\n\" 시간 제한이 있어요. \"\n\" 종료될 때까지 계속 풀어봐요. \"\n\" 시작하기 버튼을 누르면 시작해요. \"";
            objNum = (int)UIObj.mainText;
            txt = obj[objNum].GetComponent<Text>();
            txt.text = mainTxt;
            txt.rectTransform.anchoredPosition = new Vector3(0, 205, 0);
        }
        else if (nextBtnCnt == 4)
        {
            String mainTxt = "\" 지금부터 수의 순서를 확인하는 문제를 풀어볼게요. \"\n\" 같이 연습해 볼까요? \"";
            objNum = (int)UIObj.mainText;
            txt = obj[objNum].GetComponent<Text>();
            txt.text = mainTxt;
            txt.rectTransform.anchoredPosition = new Vector3(0, 293, 0);

        }
        else if (nextBtnCnt == 5)
        {
            PlayExample2();
        }
        else if (nextBtnCnt == 6)
        {
            objNum = (int)UIObj.example2;
            obj[objNum].SetActive(false);

            objNum = (int)UIObj.cards;
            obj[objNum].SetActive(false);

            objNum = (int)UIObj.panelForSample;
            obj[objNum].SetActive(false);

            String mainTxt = "\" 답을 선택하면 다음 문제로 넘어가요. \"\n" + "\" 시작하기 전에 먼저 연습문제를 풀어볼까요? \"";
            String subT = "1학년 1학기 - 2. 수의 순서";
            Reset(defaultMainTextPos, mainTxt, subT);

            objNum = (int)UIObj.nextText;
            txt = obj[objNum].GetComponent<Text>();
            txt.text = "연습문제 풀기";

        }
        else if (nextBtnCnt == 7)
        {
            PlayExample3();
        }
        else if (nextBtnCnt == 8) {
            PlayExample4();
        }
    }

    private void PlayExample4()
    {
        obj[(int)UIObj.example3Image].SetActive(false);
        obj[(int)UIObj.fingerImage].SetActive(false);
        obj[(int)UIObj.cards].SetActive(false);

        obj[(int)UIObj.example4].SetActive(true);
        obj[(int)UIObj.keypadPanel].SetActive(true);

        txt = obj[(int)UIObj.subtitleText].GetComponent<Text>();
        txt.text = "2학년 1학기 - 3. 수 세기";

        int objNum = (int)UIObj.startBarImage;
        RectTransform startBG = obj[objNum].GetComponent<RectTransform>();
        startBG.sizeDelta = new Vector2(1400, 54);

        objNum = (int)UIObj.foregroundPanel;
        RectTransform frontPanel = obj[objNum].GetComponent<RectTransform>();
        frontPanel.sizeDelta = new Vector2(1400, 756);
        frontPanel.anchoredPosition = new Vector3(-240, 230, 0);

        objNum = (int)UIObj.panelForSample;
        RectTransform grayPanel = obj[objNum].GetComponent<RectTransform>();
        grayPanel.sizeDelta = new Vector2(1400, 256);

        objNum = (int)UIObj.combineModelImage;
        RectTransform imgRect = obj[objNum].GetComponent<RectTransform>();
        imgRect.SetParent(grayPanel); // TODO : 위치 바뀌는지 확인.
        imgRect.anchoredPosition = new Vector3(0, 0, 0);

        SetAboutStart();

        txt = obj[(int)UIObj.mainText].GetComponent<Text>();
        txt.text = "\" 그림의 수 모형을 보고 모두 몇 개인지 숫자 버튼을 누르세요. \"\n" + "\" 백의 자리 2개, 십의 자리 2개, 일의 자리 3개에요. \"";

        txt = obj[(int)UIObj.startText].GetComponent<Text>();
        txt.text = "※ 이렇게 해보세요";

        RectTransform inputRect = obj[(int)UIObj.inputBoxImage].GetComponent<RectTransform>();
        inputRect.SetParent(frontPanel);
        inputRect.anchoredPosition = new Vector3(0, 279, 0);
    }

    private void PlayExample3()
    {
        obj[(int)UIObj.mainUI].SetActive(false);
        obj[(int)UIObj.example3Image].SetActive(true);
        obj[(int)UIObj.cards].SetActive(true);

        string[] newCards = { "5", "6", "10", "4" };
        for (int i = 0; i < obj[(int)UIObj.cards].transform.childCount; i++) {
            int objNum = (int)UIObj.card1Text + i;
            txt = obj[objNum].GetComponent<Text>();
            txt.text = newCards[i];
        }
        obj[(int)UIObj.panelForSample].SetActive(true);

        String mainText = "\" 그림의 수 모형을 보고 모두 몇 개인지 숫자 버튼을 누르세요. \"\n" + "\" 일의 자리 모형이 5개 있으니까 숫자 5를 선택하면 돼요! \"";
        RectTransform finParent = obj[(int)UIObj.card1Text].GetComponent<RectTransform>();
        Vector3 mainTPos = new Vector3(0, 170, 0);
        Vector3 finPos = new Vector3(5, -70, 0);
        SetCommonExample(mainText, finParent, finPos, mainTPos, true);

        txt = obj[(int)UIObj.subtitleText].GetComponent<Text>();
        txt.text = "1학년 1학기 - 3. 수 세기";

        txt = obj[(int)UIObj.startText].GetComponent<Text>();
        txt.text = "※ 이렇게 해보세요";

        RectTransform grayPanel = obj[(int)UIObj.panelForSample].GetComponent<RectTransform>();
        grayPanel.sizeDelta = new Vector2(1880, 200);

        txt = obj[(int)UIObj.nextText].GetComponent<Text>();
        txt.text = "다음으로 >";
    }

    private void PlayExample2()
    {
        obj[(int)UIObj.mainUI].SetActive(false);
        obj[(int)UIObj.example2].SetActive(true);
        obj[(int)UIObj.cards].SetActive(true);
        obj[(int)UIObj.panelForSample].SetActive(true);

        String mainText = "\"윗 칸에는 연속하는 세 개의 수가 필요해요. \"\n" + "\" 빈 칸에 알맞은 수를 아래의 보기에서 찾아 선택하면 돼요. \"\n\" 16과 17 다음에 나오는 연속하는 수는 18이에요. \"";
        RectTransform finParent = obj[(int)UIObj.card2Text].GetComponent<RectTransform>();
        Vector3 mainTPos = new Vector3(0, 170, 0);
        Vector3 finPos = new Vector3(5, -70, 0);
        SetCommonExample(mainText, finParent, finPos, mainTPos, true);

    }

    /* 첫 번째 예시 페이지 보여주기 */
    private void PlayExample1()
    {
        // MainUI 비활성화
        obj[(int)UIObj.mainUI].SetActive(false);

        // Example1 활성화
        obj[(int)UIObj.example1].SetActive(true);

        String mainText = "\"두 수 중에서 작은 수를 선택하는 문제에요. \"\n" + "\" 1과 4 중 작은 수는 1이에요. \"";
        RectTransform finParent = obj[(int)UIObj.leftText].GetComponent<RectTransform>();
        Vector3 mainTPos = new Vector3(0, 225, 0);
        Vector3 finPos = new Vector3(5, -85, 0);
        SetCommonExample(mainText, finParent, finPos, mainTPos, true);
        
        
    }

    private void SetCommonExample(string mainText, RectTransform finParent, Vector3 finPos, Vector3 mainTPos, bool isFinger)
    {
        Image img = SetAboutStart();

        // 메인 텍스트 바꾸기
        txt = obj[(int)UIObj.mainText].GetComponent<Text>();
        txt.text = mainText;
        txt.rectTransform.anchoredPosition = mainTPos;

        if (isFinger) {
            // 손가락 이미지 활성화 및 위치 조정
            obj[(int)UIObj.fingerImage].SetActive(true);
            img = obj[(int)UIObj.fingerImage].GetComponent<Image>();
            img.rectTransform.SetParent(finParent); // 부모 바꾸기(anchoredPosition쓰려고)
            img.rectTransform.anchoredPosition = finPos;
            img.rectTransform.SetParent(fingerParent); // 부모를 바꾸면 hierarchy 때문에 Layer가 바뀜.. 뒤로 감... => 그냥 hierarchy 창 순서 바꿔서 해결함.
        }
    }

    private Image SetAboutStart()
    {
        // 시작하기 Text 흰색으로 바꾸기
        txt = obj[(int)UIObj.startText].GetComponent<Text>();
        txt.color = Color.white;

        // 시작하기 배경 보라색으로 바꾸기
        Image img = obj[(int)UIObj.startBarImage].GetComponent<Image>();
        ColorUtility.TryParseHtmlString("#715EC5", out color);
        img.color = color;

        return img;
    }

    private void OnClickListenButton()
    {
        Debug.Log("Listen Button");
    }

    // MainUI로 리셋하는 함수
    private void Reset(Vector3 mainTextPos, string mainText = defaultMainText, string subtitle = defaultSubtitle, string title=defaultTitle)
    {
        txt = obj[(int)UIObj.titleText].GetComponent<Text>();
        txt.text = title;

        txt = obj[(int)UIObj.subtitleText].GetComponent<Text>();
        txt.text = subtitle;

        txt = obj[(int)UIObj.startText].GetComponent<Text>();
        txt.color = new Color(44f/255, 44f/255, 44f/255);

        Image img = obj[(int)UIObj.startBarImage].GetComponent<Image>();
        img.color = Color.white;

        txt = obj[(int)UIObj.mainText].GetComponent<Text>();
        txt.text = mainText;
        txt.rectTransform.anchoredPosition = mainTextPos;

        obj[(int)UIObj.mainUI].SetActive(true);
        obj[(int)UIObj.fingerImage].SetActive(false);
    }
}
