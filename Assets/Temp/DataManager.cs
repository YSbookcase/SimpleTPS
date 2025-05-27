using CustomUtility.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private CsvTable _monsterCSV;

    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        TestMethod();
    }


    private void Init()
    {
        CsvReader.Read(_monsterCSV);
    }

    private void TestMethod()
    {
        Debug.Log(_monsterCSV.GetLine(0));
        Debug.Log(_monsterCSV.GetLine(2));



    }

}
