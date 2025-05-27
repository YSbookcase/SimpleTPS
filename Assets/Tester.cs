using UnityEngine;
using CustomUtility.IO;
using System;

public class Tester : MonoBehaviour
{
    // 유니티 인스펙터 및 생성자에서 초기화
    [SerializeField] private CsvTable _tableCSV;
    [SerializeField] private CsvDictionary _dictCsv = new("DataTable/CsvTemp.csv", ',');
    
    public Vector2Int dataTablePos;
    
    private void Start()
    {
        // 읽기
        CsvReader.Read(_dictCsv);
        CsvReader.Read(_tableCSV);
        
        // Table 구조는 int타입 및 Vector2Int를 사용해 데이터 참조
        Debug.Log(_tableCSV.GetData(2, 3));
        Debug.Log(_tableCSV.GetData(dataTablePos));
        
        // Dictionary 구조는 string 두 개를 사용해 행, 열 데이터 참조
        Debug.Log(_dictCsv.GetData("2", "f"));
        
        // 두 형태 모두 하나의 행을 통째로 string배열로 받아오는 GetLine기능 지원
        string[] strArr1 = _tableCSV.GetLine(4);
        string[] strArr2 = _dictCsv.GetLine("2");

        PrintArray(strArr2);


    }



    private static void PrintArray(Array array)
    {
        int[] indices = new int[array.Rank];
        PrintRecursive(array, indices, 0);
    }

    private static void PrintRecursive(Array array, int[] indices, int dimension)
    {
        int length = array.GetLength(dimension);

        for (int i = 0; i < length; i++)
        {
            indices[dimension] = i;

            if (dimension < array.Rank - 1)
            {
                // 재귀 호출로 다음 차원 탐색
                PrintRecursive(array, indices, dimension + 1);
            }
            else
            {
                // 마지막 차원까지 왔으면 요소 출력
                string result = "[";

                // 인덱스 표시
                for (int j = 0; j < indices.Length; j++)
                {
                    result += indices[j];
                    if (j < indices.Length - 1) result += ",";
                }
                result += "] = " + array.GetValue(indices);

                // Unity 콘솔에 출력
                Debug.Log(result);
            }
        }

        // 줄 개행 구분용 (2차원 이상일 때)
        if (dimension == array.Rank - 2)
            Debug.Log(""); // 빈 줄 추가
    }

}