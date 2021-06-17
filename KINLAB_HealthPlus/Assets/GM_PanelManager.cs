using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class GM_PanelManager : MonoBehaviour
{
    public enum MainState
    {
        Main,
        TodayCheck,
        Eattting,
        Madicen,

    }



    [Header("Panel")]
    [Space(5f)]
    public GameObject StartPanel;
    public GameObject SetInformationPanel;
    public GameObject FiveSecPassed_Panel;
    public GameObject ApplicationMainPanel;
    public GameObject TodayCheckPanel;
    public GameObject TodayCheck_2_Panel;
    public GameObject EattingTypePanel;
    public GameObject EattingBreakFastPanel;
    public GameObject EAT_3Sec_Pass_Panel;
    public GameObject Exercise_3_Panel;
    public GameObject Exercise_Select_Panel;
    public GameObject Drug_3_Panel;
    public GameObject Drug_Controll_Panel;
    public GameObject Setting_Setup_Panel;
    public GameObject Quiz_Panel;
    public GameObject Energy_Panel;
    public GameObject PointCheck_Panel;


    [SerializeField]
    [Header("EATTING TIME")]
    public GameObject breakfastButton;


    [Header("Exercise")]
    public GameObject Exercise_Select_FirstTime;
    public bool isFirstExercise = true;

    [SerializeField]
    [Header("Eattting")]
    [Space(5f)]
    public Toggle[] rice;
    public GameObject riceImage;
    public GameObject yesterday_eatting_Image;
    public int checkriceCount = 0;
    public bool isBreakfast = false;

    [Header("Drug")]
    public GameObject DrugAdd_Panel;
    public GameObject TodayDrug_Panel;
    public GameObject DrugInformation_Panel;

    [Header("Setting")]
    public GameObject InformationSetup_Panel;
    public GameObject EattingSetup_Panel;
    public GameObject ExerciseSetup_Panel;
    public GameObject DrugInformationSetup_Panel;

    [Header("Quiz")]
    public GameObject Quiz01_Panel;
    public GameObject Quiz02_Panel;
    public GameObject Quiz03_Panel;
    public GameObject Quiz04_Panel;

    [Header("Energy")]
    public GameObject Energy01_Panel;
    public GameObject Energy02_Panel;
    public GameObject Energy03_Panel;
    public GameObject Energy04_Panel;
    public GameObject EnergyCheck01_Panel;
    public GameObject EnergyCheck02_Panel;

    [Header("PointCheck")]
    public GameObject PointCheck01_Panel;


    public void StartEvent()
    {
        PanelCloser(StartPanel);
    }
    public void Start()
    {
        PanelCloser(StartPanel);
    }

    public void ButtonClickEvent01()
    {
        PanelCloser(SetInformationPanel);
    }
    public void ButtonClickEvent02()
    {
        PanelCloser(FiveSecPassed_Panel);
        StartCoroutine(SecondDelay(5.0f, ApplicationMainPanel));
    }
    public void ButtonClick_Main()
    {
        PanelCloser(ApplicationMainPanel);
    }
    public void QuizSubPanelCloser(GameObject name)
    {
        Quiz01_Panel.SetActive(false);
        Quiz02_Panel.SetActive(false);
        Quiz03_Panel.SetActive(false);
        Quiz04_Panel.SetActive(false);

        name.SetActive(true);
    }


    public void SettingSubPanelCloser(GameObject name)
    {
        InformationSetup_Panel.SetActive(false);
        EattingSetup_Panel.SetActive(false);
        ExerciseSetup_Panel.SetActive(false);
        DrugInformationSetup_Panel.SetActive(false);

        name.SetActive(true);
    }
    public void EnergySubPanelCloser(GameObject name)
    {
        Energy01_Panel.SetActive(false);
        Energy02_Panel.SetActive(false);
        Energy03_Panel.SetActive(false);
        Energy04_Panel.SetActive(false);
        EnergyCheck01_Panel.SetActive(false);
        EnergyCheck02_Panel.SetActive(false);


        name.SetActive(true);
    }


    public void PanelCloser(GameObject name)
    {

        StartPanel.SetActive(false);
        SetInformationPanel.SetActive(false);
        FiveSecPassed_Panel.SetActive(false);
        ApplicationMainPanel.SetActive(false);
        TodayCheckPanel.SetActive(false);
        TodayCheck_2_Panel.SetActive(false);
        EattingTypePanel.SetActive(false);
        EattingBreakFastPanel.SetActive(false);
        EAT_3Sec_Pass_Panel.SetActive(false);
        Drug_3_Panel.SetActive(false);
        Drug_Controll_Panel.SetActive(false);
        Exercise_3_Panel.SetActive(false);
        Exercise_Select_Panel.SetActive(false);
        Setting_Setup_Panel.SetActive(false);
        Quiz_Panel.SetActive(false);
        Energy_Panel.SetActive(false);
        PointCheck_Panel.SetActive(false);

        name.SetActive(true);
    }

    IEnumerator SecondDelay(float a, GameObject b)
    {
        yield return new WaitForSeconds(a);
        PanelCloser(b);
    }
    IEnumerator DelayImagePopup()
    {
        yield return new WaitForSeconds(1.0f);
        
    }
    #region TodayCheck

    public void buttonEventMain_Today()
    {
        PanelCloser(TodayCheckPanel);
        StartCoroutine(SecondDelay(2.0f, TodayCheck_2_Panel));
    }
    public void buttonEventToday_Check()
    {
        PanelCloser(TodayCheckPanel);
    }
    public void buttonEventToday_Check2()
    {
        PanelCloser(ApplicationMainPanel);
    }
    #endregion
    public void buttonEventMain_EattingType()
    {
        PanelCloser(EattingTypePanel);
    }

    #region Eatting Pase
    public void buttonEvent_Eatting_Eatting_Setting_Initallize()
    {
        for (int i = checkriceCount; i < rice.Length; i++)
        {
            rice[i].isOn = false;
        }
    }
    public void buttonEvent_Eatting_checkriceCounter()
    {
        if (checkriceCount <= rice.Length)
        {
            rice[checkriceCount].interactable = false;
            checkriceCount++;
        }
    }
    public void buttonEvent_Eatting_RiceImageOn()
    {
        riceImage.SetActive(true);
    }

    public void buttonEvent_Eatting_RiceImageOff()
    {
        riceImage.SetActive(false);
    }
    public void buttonEvent_Eatting_BreakFastSettingStart()
    {
        isBreakfast = true;
        PanelCloser(EattingBreakFastPanel);
    }

    public void buttonEvent_Eatting_PaseEnd()
    {
        if(isBreakfast)
        {
            breakfastButton.SetActive(false);
        }
        PanelCloser(EAT_3Sec_Pass_Panel);
        StartCoroutine(SecondDelay(3.0f, ApplicationMainPanel));
    }
    public void buttonEvent_YesterdayOFF()
    {
        yesterday_eatting_Image.SetActive(false);
    }
    #endregion


    #region Exercise

    public void buttonEventMain_Exercise()
    {
        PanelCloser(Exercise_3_Panel);
        StartCoroutine(SecondDelay(3.0f, Exercise_Select_Panel));
        if (isFirstExercise)
        {
            Exercise_Select_FirstTime.SetActive(true);
        }
    }


    public void butttonEvent_Exercise_recommend()
    {
        isFirstExercise = false;
        Exercise_Select_FirstTime.SetActive(false);
    }

    public void butttonEvent_Exercise_MySelf()
    {
        isFirstExercise = false;
        Exercise_Select_FirstTime.SetActive(false);
    }

    #endregion


    #region Drug
    public void butttonEvent_DrugStart()
    {
        PanelCloser(Drug_3_Panel);
        StartCoroutine(SecondDelay(2.0f, Drug_Controll_Panel));
    }


    public void butttonEvent_Drug_AddDrug()
    {
        DrugAdd_Panel.SetActive(true);
    }
    public void butttonEvent_Drug_SaveDrug()
    {
       DrugAdd_Panel.SetActive(false);
    }
    public void butttonEvent_Drug_TodayDrugOn()
    {
        TodayDrug_Panel.SetActive(true);
    }
    public void butttonEvent_Drug_TodayDrugOff()
    {
        TodayDrug_Panel.SetActive(false);
    }
    public void butttonEvent_Drug_DrugInformationOn()
    {
        DrugInformation_Panel.SetActive(true);
    }
    public void butttonEvent_Drug_DrugInformationOff()
    {
        DrugInformation_Panel.SetActive(false);
    }
    #endregion

    #region Setting
    public void butttonEvent_Setting()
    {
        PanelCloser(Setting_Setup_Panel);
        InformationSetup_Panel.SetActive(false);
        EattingSetup_Panel.SetActive(false);
        ExerciseSetup_Panel.SetActive(false);
        DrugInformationSetup_Panel.SetActive(false);
    }
    public void butttonEvent_Setting_MyInformation()
    {
        SettingSubPanelCloser(InformationSetup_Panel);
    }
    public void butttonEvent_Setting_Eatting()
    {
        SettingSubPanelCloser(EattingSetup_Panel);
    }
    public void butttonEvent_Setting_Exercise()
    {
        SettingSubPanelCloser(ExerciseSetup_Panel);
    }
    public void butttonEvent_Setting_Drug()
    {
        SettingSubPanelCloser(DrugInformationSetup_Panel);
    }

    #endregion
    #region Quiz
    public void butttonEvent_Quiz()
    {
        PanelCloser(Quiz_Panel);
        Quiz01_Panel.SetActive(true);
        Quiz02_Panel.SetActive(false);
        Quiz03_Panel.SetActive(false);
        Quiz04_Panel.SetActive(false);
    }
    public void butttonEvent_Quiz01_Panel()
    {
        QuizSubPanelCloser(Quiz02_Panel);
    }
    public void butttonEvent_Quiz02_Panel()
    {
        QuizSubPanelCloser(Quiz03_Panel);
    }
    public void butttonEvent_Quiz03_Panel()
    {
        QuizSubPanelCloser(Quiz04_Panel);
    }
    public void butttonEvent_Quiz04_Panel()
    {
        Quiz04_Panel.SetActive(false);
        ButtonClick_Main();
    }

    #endregion
    #region Energy
    public void butttonEvent_Energy()
    {
        PanelCloser(Energy_Panel);
        Energy01_Panel.SetActive(true);
        Energy02_Panel.SetActive(false);
        Energy03_Panel.SetActive(false);
        Energy04_Panel.SetActive(false);
        EnergyCheck01_Panel.SetActive(false);
        EnergyCheck02_Panel.SetActive(false);
    }
    public void butttonEvent_EnergyCheck01_On()
    {
        EnergySubPanelCloser(EnergyCheck01_Panel);
    }
    public void butttonEvent_Energy01_Panel()
    {
        EnergySubPanelCloser(Energy02_Panel);
    }
    public void butttonEvent_Energy02_Panel()
    {
        EnergySubPanelCloser(Energy03_Panel);
    }
    public void butttonEvent_Energy03_Panel()
    {
        EnergySubPanelCloser(Energy04_Panel);
    }
    public void butttonEvent_Energy04_Panel()
    {
        Energy04_Panel.SetActive(false);
        ButtonClick_Main();
    }
    public void butttonEvent_EnergyCheck01_Panel()
    {
        EnergySubPanelCloser(EnergyCheck02_Panel);
    }
    public void butttonEvent_EnergyCheck02_Panel()
    {
        EnergyCheck02_Panel.SetActive(false);
        ButtonClick_Main();
    }
    #endregion
    #region PointCheck
    public void butttonEvent_PointCheck()
    {
        PanelCloser(PointCheck_Panel);
        PointCheck01_Panel.SetActive(true);
    }
    public void butttonEvent_PointCheck_PanelClose()
    {
        PointCheck01_Panel.SetActive(false);
        ButtonClick_Main();
    }
    #endregion
}