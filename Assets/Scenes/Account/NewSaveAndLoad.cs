using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using System.IO;

public class NewSaveAndLoad : MonoBehaviour
{
    public GameObject AccountUI, MenuUI, ListUI;

    public NewSaveData NSD;

    public TMP_InputField StudentNumber, StudentName, StudentSection;
    public Button StudentLogin, StudentRegister;


    public TMP_InputField TeacherName, TeacherSection;
    public Button TeacherLogin, TeacherRegister;

    Coroutine WaitCo;

    public List<int> StudentListInt;
    public List<GameObject> StudentListTransform;

    public Transform ListParent;
    public GameObject ItemPrefab;

    public TMP_Text TeacherNameTxt, TeacherSectionTxt, StudentNameTxt;

    public GameObject TeacherErr, StudentErr;

    void Start()
    {
        /*PlayerPrefs.DeleteAll();
        NSD.AccountType = "";
        NSD.FullName = "";
        NSD.AccountNumber = -1;*/

        /*string saveData = JsonUtility.ToJson(NSD);
        Debug.Log(saveData);
        string _filePath = Application.persistentDataPath + "/Elemix.json";
        System.IO.File.WriteAllText(_filePath, saveData);*/

        string _filePath = Application.persistentDataPath + "/Elemix.json";
        if (File.Exists(_filePath))
        {
            string _fileContents = File.ReadAllText(_filePath);

            JsonUtility.FromJsonOverwrite(_fileContents, NSD);
        }

        Debug.Log(_filePath);

        if (NSD.FullName != "" && NSD.AccountType != "" && NSD.AccountNumber > -1)
        {
            //SaveAndLoadManager.instance.LoadStudentData();

            AccountUI.SetActive(false);

            if (NSD.AccountType == "Student")
            {

                StudentNameTxt.text = NSD.FullName.ToUpper();
                MenuUI.SetActive(true);
            }
            else if (NSD.AccountType == "Teacher")
            {
                TeacherNameTxt.text = NSD.FullName.ToUpper();
                ListUI.SetActive(true);
                SectionList();
            }
        }
        else
        {
            NSD.AccountType = "";
            NSD.FullName = "";
            NSD.AccountNumber = -1;

            AccountUI.SetActive(true);
        }
    }

    public void TeacherCheckInputField()
    {
        if (TeacherName.text != null && TeacherName.text != "" && TeacherSection.text != null && TeacherSection.text != "")
        {
            TeacherLogin.interactable = true;
            TeacherRegister.interactable = true;
        }
        else
        {
            TeacherLogin.interactable = false;
            TeacherRegister.interactable = false;
        }
    }

    public void TeacherRegisterFunc()
    {
        bool _teacherValid = true;

        foreach (TeacherAccount _tacc in NSD.teachers)
        {
            if (_tacc.FullName == TeacherName.text.ToUpper())
            {
                _teacherValid = false;
            }
        }

        if (_teacherValid)
        {
            TeacherErr.SetActive(false);
            TeacherErr.GetComponent<TMP_Text>().text = "";
            TeacherAccount _nsd = new TeacherAccount();

            _nsd.FullName = TeacherName.text.ToUpper();
            _nsd.Section = TeacherSection.text.ToUpper();

            NSD.teachers.Add(_nsd);

            if (WaitCo != null)
            {
                StopCoroutine(WaitCo);
                WaitCo = null;
            }
            else
            {
                WaitCo = StartCoroutine(WaitTeacherIE());
            }
        }
        else
        {
            TeacherErr.GetComponent<TMP_Text>().text = "Existing Account";
            TeacherErr.SetActive(true);
        }
    }

    IEnumerator WaitTeacherIE()
    {
        yield return new WaitForSeconds(0.1f);

        NSD.FullName = TeacherName.text.ToUpper();
        NSD.AccountType = "Teacher";
        NSD.AccountNumber = NSD.teachers.Count - 1;

        SaveToJson();

        TeacherNameTxt.text = NSD.FullName.ToUpper();
        ListUI.SetActive(true);
        AccountUI.SetActive(false);

        SectionList();

        StopCoroutine(WaitCo);
        WaitCo = null;
    }

    public void TeacherLoginFunc()
    {
        if (TeacherName.text.ToUpper() == "DELETE" && TeacherSection.text.ToUpper() == "DELETE")
        {

            NSD.AccountType = "";
            NSD.FullName = "";
            NSD.AccountNumber = -1;

            NSD.students.Clear();
            NSD.teachers.Clear();

            SaveToJson();

            TeacherName.text = "";
            TeacherSection.text = "";
        }
        else
        {
            bool _accAvail = false;
            int _accNum = -1;
            for (int i = 0; i < NSD.teachers.Count; i++)
            {
                int j = i;
                if (NSD.teachers[i].FullName.ToUpper() == TeacherName.text.ToUpper())
                {
                    _accAvail = true;
                    _accNum = j;
                }
            }

            if (_accAvail)
            {
                NSD.FullName = TeacherName.text.ToUpper();
                NSD.AccountType = "Teacher";
                NSD.AccountNumber = _accNum;

                NSD.teachers[_accNum].Section = TeacherSection.text.ToUpper();

                Debug.Log("Valid Teacher");

                SaveToJson();

                TeacherNameTxt.text = NSD.FullName.ToUpper();
                ListUI.SetActive(true);
                AccountUI.SetActive(false);

                TeacherErr.SetActive(false);
                TeacherErr.GetComponent<TMP_Text>().text = "";

                SectionList();
            }
            else
            {
                TeacherErr.GetComponent<TMP_Text>().text = "Invalid Account";
                TeacherErr.SetActive(true);

                Debug.Log("Invalid Teacher");
            }
        }

    }

    public void SectionList()
    {
        Debug.Log("SectionInit");

        TeacherSectionTxt.text = NSD.teachers[NSD.AccountNumber].Section;

        ClearInputs();

        for (int i = 0; i < NSD.students.Count; i++)
        {
            int j = i;

            if (NSD.students[j].Section == NSD.teachers[NSD.AccountNumber].Section)
            {
                StudentListInt.Add(j);
            }
        }

        for (int i = 0; i < StudentListInt.Count; i++)
        {

            int j = i;

            GameObject _go = Instantiate(ItemPrefab, ListParent);

            _go.transform.Find("StudentNumber").GetComponent<TMP_Text>().text = NSD.students[StudentListInt[j]].StudentNumber;
            _go.transform.Find("StudentName").GetComponent<TMP_Text>().text = NSD.students[StudentListInt[j]].FullName;
            _go.transform.Find("Level1").GetComponent<TMP_Text>().text = NSD.students[StudentListInt[j]].LevelData.levelScore[0].ToString();
            _go.transform.Find("Level2").GetComponent<TMP_Text>().text = NSD.students[StudentListInt[j]].LevelData.levelScore[1].ToString();
            _go.transform.Find("Level3").GetComponent<TMP_Text>().text = NSD.students[StudentListInt[j]].LevelData.levelScore[2].ToString();
            _go.transform.Find("Level4").GetComponent<TMP_Text>().text = NSD.students[StudentListInt[j]].LevelData.levelScore[3].ToString();
            _go.transform.Find("Level5").GetComponent<TMP_Text>().text = NSD.students[StudentListInt[j]].LevelData.levelScore[4].ToString();

            _go.transform.Find("Total").GetComponent<TMP_Text>().text = (NSD.students[StudentListInt[j]].LevelData.levelScore[0]
             + NSD.students[StudentListInt[j]].LevelData.levelScore[1]
             + NSD.students[StudentListInt[j]].LevelData.levelScore[2]
             + NSD.students[StudentListInt[j]].LevelData.levelScore[3]
             + NSD.students[StudentListInt[j]].LevelData.levelScore[4]).ToString();


            StudentListTransform.Add(_go);
        }
    }

    public void TeacherLogout()
    {
        foreach (GameObject _go in StudentListTransform)
        {
            Destroy(_go);
        }

        StudentListTransform.Clear();

        StudentListInt.Clear();


        NSD.AccountType = "";
        NSD.FullName = "";
        NSD.AccountNumber = -1;

        SaveToJson();

        ListUI.SetActive(false);
        AccountUI.SetActive(true);
    }

    public void CheckInputField()
    {
        if (StudentNumber.text != null && StudentName.text != null && StudentSection.text != null && StudentNumber.text != "" && StudentName.text != "" && StudentSection.text != "")
        {
            StudentLogin.interactable = true;
            StudentRegister.interactable = true;
        }
        else
        {
            StudentLogin.interactable = false;
            StudentRegister.interactable = false;
        }
    }

    public void Register()
    {
        bool _studentValid = true;

        foreach (StudentAccount _sacc in NSD.students)
        {
            if (_sacc.StudentNumber.ToUpper() == StudentNumber.text.ToUpper())
            {
                _studentValid = false;
            }
            if (_sacc.FullName.ToUpper() == StudentName.text.ToUpper())
            {
                _studentValid = false;
            }
        }

        if (_studentValid)
        {

            StudentErr.GetComponent<TMP_Text>().text = "";
            StudentErr.SetActive(false);

            StudentAccount _nsd = new StudentAccount();
            _nsd.StudentNumber = StudentNumber.text.ToUpper();
            _nsd.FullName = StudentName.text.ToUpper();
            _nsd.Section = StudentSection.text.ToUpper();

            _nsd.LevelData = new levelData();

            System.Random random = new System.Random(); 


            List<int> ql = new List<int>();

            for (int i = 0; i < _nsd.LevelData.numberOfLevels; i++)
            {
                ql.Add(i);
            }

            _nsd.LevelData.questionList = ql.OrderBy(x => Guid.NewGuid()).ToList().ToArray();

            NSD.students.Add(_nsd);

            Debug.Log(NSD.students.Count - 1);

            if (WaitCo != null)
            {
                StopCoroutine(WaitCo);
                WaitCo = null;
            }
            else
            {
                WaitCo = StartCoroutine(WaitIE());
            }
        }
        else
        {
            StudentErr.GetComponent<TMP_Text>().text = "Existing Account";
            StudentErr.SetActive(true);
        }
    }

    IEnumerator WaitIE()
    {
        yield return new WaitForSeconds(0.2f);

        Debug.Log("waiting");
        /*System.Random random = new System.Random();

        List<int> ql = new List<int>();

        for (int i = 0; i < NSD.students[NSD.students.Count - 1].LevelData.numberOfLevels; i++)
        {
            ql.Add(i);
        }

        NSD.students[NSD.students.Count - 1].LevelData.questionList = ql.OrderBy(x => Guid.NewGuid()).ToList().ToArray();*/

        NSD.FullName = StudentName.text.ToUpper();
        NSD.AccountType = "Student";
        NSD.AccountNumber = NSD.students.Count - 1;

        /*PlayerPrefs.SetString("FullName", StudentName.text);
        PlayerPrefs.SetString("AccountType", "Student");
        PlayerPrefs.SetInt("AccountNumber", NSD.students.Count - 1);*/

        SaveToJson();

        StudentNameTxt.text = NSD.FullName.ToUpper();

        ClearInputs();

        MenuUI.SetActive(true);
        AccountUI.SetActive(false);

        StopCoroutine(WaitCo);
        WaitCo = null;
    }

    public void Login()
    {
        bool _accAvail = false;
        int _accNum = -1;
        for (int i = 0; i < NSD.students.Count; i++)
        {
            int j = i;
            if (NSD.students[i].FullName.ToUpper() == StudentName.text.ToUpper() && NSD.students[i].StudentNumber.ToUpper() == StudentNumber.text.ToUpper() && NSD.students[i].Section.ToUpper() == StudentSection.text.ToUpper())
            {
                _accAvail = true;
                _accNum = j;
            }
        }

        if (_accAvail)
        {
            NSD.FullName = StudentName.text.ToUpper();
            NSD.AccountType = "Student";
            NSD.AccountNumber = _accNum;

            /*PlayerPrefs.SetString("FullName", StudentName.text);
            PlayerPrefs.SetString("AccountType", "Student");
            PlayerPrefs.SetInt("AccountNumber", _accNum);*/

            //SaveAndLoadManager.instance.LoadStudentData();

            Debug.Log("Valid Student");

            SaveToJson();

            StudentNameTxt.text = NSD.FullName.ToUpper();

            StudentErr.GetComponent<TMP_Text>().text = "";
            StudentErr.SetActive(false);

            ClearInputs();

            MenuUI.SetActive(true);
            AccountUI.SetActive(false);
        }
        else
        {

            StudentErr.GetComponent<TMP_Text>().text = "Invalid Account";
            StudentErr.SetActive(true);
            Debug.Log("Invalid Student");
        }
    }

    public void ClearInputs()
    {
        StudentNumber.text = string.Empty;
        StudentName.text = string.Empty;
        StudentSection.text = string.Empty;
        TeacherName.text = string.Empty;
        TeacherSection.text = string.Empty;
    }

    public void Logout()
    {
        NSD.AccountType = "";
        NSD.FullName = "";
        NSD.AccountNumber = -1;

        SaveToJson();


        StudentNameTxt.text = "";

        MenuUI.SetActive(false);
        AccountUI.SetActive(true);
    }
    public void SaveToJson()
    {
        string saveData = JsonUtility.ToJson(NSD);
        Debug.Log(saveData);
        string _filePath = Application.persistentDataPath + "/Elemix.json";
        System.IO.File.WriteAllText(_filePath, saveData);
    }
}
