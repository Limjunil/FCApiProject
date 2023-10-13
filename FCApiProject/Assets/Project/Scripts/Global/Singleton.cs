using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance = default;

    public static T Instance
    {
        get
        {
            if (Singleton<T>.instance == default || instance == default)
            {
                Singleton<T>.instance = Func.CreateObj<T>(typeof(T).ToString());

                DontDestroyOnLoad(instance.gameObject);
            }   // if : 인스턴스가 비어 있을 때 새로 인스턴스화 한다.

            return instance;
        }
    }


    public void Create()
    {
        
    }   // Create()

}
