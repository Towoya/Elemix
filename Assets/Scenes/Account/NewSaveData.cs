using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data")]
public class NewSaveData : ScriptableObject
{
    public string AccountType, FullName;
    public int AccountNumber;
    public List<StudentAccount> students;
    public List<TeacherAccount> teachers;
}

[System.Serializable]
public class StudentAccount
{
    public string StudentNumber;
    public string FullName;
    public string Section;
    public levelData LevelData;
}

[System.Serializable]
public class TeacherAccount
{
    public string FullName;
    public string Section;
}