using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class JSONTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        string jsonText = File.ReadAllText(Application.dataPath + "/Scenes/JSONTest/TESTJSON.json");
        var jsonParsed = new JSONObject(jsonText);

        /* 사실 JSON엔 숫자가 들어가는 건 Number 자료형밖에 없고, 아래 integer, float는 그 Number를 어떻게 파싱하냐에 따라 나옴 */
        if(jsonParsed["integer"] != null)
        {
            /* JSONObject에선 Integer는 long이 기본형이며 int 형의 자료에 써야하는 경우 System.Convert.ToInt32() 메서드를 쓰거나 (int) 캐스팅으로 변환해서 사용 */ 
            long integer = jsonParsed["integer"].i; 
            PrintJSONLog(string.Format("JSON integer: {0}\n", integer));
        }

        if(jsonParsed["floatNum"] != null)
        {
            float floatNum = jsonParsed["floatNum"].f;  /* 혹은 jsonParsed["floatNum"].n */
            PrintJSONLog(string.Format("JSON float: {0}\n", floatNum));
        }

        if(jsonParsed["boolean"] != null)
        {
            bool boolean = jsonParsed["boolean"].b;
            PrintJSONLog(string.Format("JSON bool: {0}\n", boolean));
        }

        if(jsonParsed["str"] != null)
        {
            string str = jsonParsed["str"].str;
            PrintJSONLog(string.Format("JSON string: {0}\n", str));
        }

        if(jsonParsed["array"] != null)
        {
            var array = jsonParsed["array"].list;
            foreach(var i in array)
            {
                PrintJSONLog(string.Format("JSON array: {0}\n", i.i));
            }
        }

        if(jsonParsed["arrayString"] != null)
        {
            var array = jsonParsed["arrayString"].list;
            foreach(var i in array)
            {
                PrintJSONLog(string.Format("JSON arrayString: {0}\n", i.str));
            }
        }

        if(jsonParsed["nested"] != null && jsonParsed["nestedInteger"] != null)
        {
            long nestedInteger = jsonParsed["nested"]["nestedInteger"].i;
            PrintJSONLog(string.Format("JSON nestedInteger: {0}\n", nestedInteger));
        }

        PrintJSONLog("\n");

        /* JSONObject를 사용하여 JSON을 생성하는 예제 */
        var JSONcreate = new JSONObject();
        JSONcreate.AddField("number", 123);
        JSONcreate.AddField("string", "string");
        JSONcreate.AddField("newField", new JSONObject(JSONObject.Type.ARRAY));
        JSONcreate["newField"].Add("A"); JSONcreate["newField"].Add("B"); JSONcreate["newField"].Add("C");
        JSONcreate.AddField("nested", new JSONObject());
        JSONcreate["nested"].AddField("nestedString", "nested string");

        PrintJSONLog("created JSON: ");
        PrintJSONLog(JSONcreate.ToString());
        
    }

    private void PrintJSONLog(string JSONLog)
    {
        m_textMeshPro.text += JSONLog;
        Debug.LogError(JSONLog);
    }
}
