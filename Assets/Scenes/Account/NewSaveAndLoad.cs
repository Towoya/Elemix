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
    public GameObject AccountUI, MenuUI;

    public NewSaveData NSD;

    public TMP_InputField StudentNumber, StudentName, StudentSection;
    public Button StudentLogin, StudentRegister;

    Coroutine WaitCo;

    void Start()
    {
        /*PlayerPrefs.DeleteAll();
        NSD.AccountType = "";
        NSD.FullName = "";
        NSD.AccountNumber = -1;*/

        string saveData = JsonUtility.ToJson(NSD);
        Debug.Log(saveData);
        string _filePath = Application.persistentDataPath + "/Elemix.json";
        System.IO.File.WriteAllText(_filePath, saveData);

        Debug.Log(_filePath);

        /*string _filePath = Application.persistentDataPath + "/Elemix.json";
        if (File.Exists(_filePath))
        {
            string _fileContents = File.ReadAllText(_filePath);

            JsonUtility.FromJsonOverwrite(_fileContents, NSD);
        }*/

        if (NSD.FullName != "" && NSD.AccountType != "" && NSD.AccountNumber > -1)
        {
            //SaveAndLoadManager.instance.LoadStudentData();


            MenuUI.SetActive(true);
            AccountUI.SetActive(false);
        }
        else
        {
            NSD.AccountType = "";
            NSD.FullName = "";
            NSD.AccountNumber = -1;

            AccountUI.SetActive(true);
        }

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
            if (_sacc.StudentNumber == StudentNumber.text)
            {
                _studentValid = false;
            }
            if (_sacc.FullName == StudentName.text)
            {
                _studentValid = false;
            }
        }

        if (_studentValid)
        {
            StudentAccount _nsd = new StudentAccount();
            _nsd.StudentNumber = StudentNumber.text;
            _nsd.FullName = StudentName.text;
            _nsd.Section = StudentSection.text;

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
    }

    IEnumerator WaitIE()
    {
        yield return new WaitForSeconds(0.1f);

        System.Random random = new System.Random();

        List<int> ql = new List<int>();

        for (int i = 0; i < NSD.students[NSD.students.Count - 1].LevelData.numberOfLevels; i++)
        {
            ql.Add(i);
        }

        NSD.students[NSD.students.Count - 1].LevelData.questionList = ql.OrderBy(x => Guid.NewGuid()).ToList().ToArray();

        NSD.FullName = StudentName.text;
        NSD.AccountType = "Student";
        NSD.AccountNumber = NSD.students.Count - 1;

        PlayerPrefs.SetString("FullName", StudentName.text);
        PlayerPrefs.SetString("AccountType", "Student");
        PlayerPrefs.SetInt("AccountNumber", NSD.students.Count - 1);

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
            if (NSD.students[i].FullName == StudentName.text && NSD.students[i].StudentNumber == StudentNumber.text && NSD.students[i].Section == StudentSection.text)
            {
                _accAvail = true;
                _accNum = j;
            }
        }

        if (_accAvail)
        {
            NSD.FullName = StudentName.text;
            NSD.AccountType = "Student";
            NSD.AccountNumber = _accNum;

            PlayerPrefs.SetString("FullName", StudentName.text);
            PlayerPrefs.SetString("AccountType", "Student");
            PlayerPrefs.SetInt("AccountNumber", _accNum);

            //SaveAndLoadManager.instance.LoadStudentData();

            Debug.Log("Valid Student");

            MenuUI.SetActive(true);
            AccountUI.SetActive(false);
        }
        else
        {

            Debug.Log("Invalid Student");
        }
    }
}
