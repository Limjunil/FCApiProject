using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class UserData
{
    public string accessId;
    public string nickname;
    public int level;
}


public class UserInfo : MonoBehaviour
{

    string characterName = string.Empty;
    string apiKey = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJYLUFwcC1SYXRlLUxpbWl0IjoiNTAwOjEwIiwiYWNjb3VudF9pZCI6IjIwOTc2Nzc1NDYiLCJhdXRoX2lkIjoiMiIsImV4cCI6MTcxMjcyOTU5OSwiaWF0IjoxNjk3MTc3NTk5LCJuYmYiOjE2OTcxNzc1OTksInNlcnZpY2VfaWQiOiI0MzAwMTE0ODEiLCJ0b2tlbl90eXBlIjoiQWNjZXNzVG9rZW4ifQ.mybfk01dZTI08cl0iKVEwIx88kq1V8gwII5WcxeVSdM";
        characterName = UnityWebRequest.EscapeURL("리바이브장풀");
        StartCoroutine(UserInfoRequest(characterName));
    }

    IEnumerator UserInfoRequest(string nickName)
    {
        string url_ = $"https://public.api.nexon.com/openapi/fconline/v1.0/users?nickname={nickName}";

        UnityWebRequest www = UnityWebRequest.Get(url_);

        www.SetRequestHeader("Authorization", apiKey);

        yield return www.SendWebRequest();

        if(www.error == null)
        {

            var userData_ = JsonUtility.FromJson<UserData>(www.downloadHandler.text);

            print(userData_.nickname);
        }
        else
        {
            Debug.Log("ERROR");
        }
    }
}
