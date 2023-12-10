using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SFXScript :MonoBehaviour
{
    #region 跨場景使用單例模式
    //private static SFXScript _instance;
    //public static SFXScript instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = FindObjectOfType<SFXScript>();
    //            if (_instance == null)
    //            {
    //                GameObject singleton = new GameObject(typeof(SFXScript).Name);
    //                _instance = singleton.AddComponent<SFXScript>();
    //            }
    //        }
    //        return _instance;
    //    }
    //}
    //private void Awake()
    //{
    //    if (_instance == null)
    //    {
    //        _instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    #endregion
    [Header("跳躍聲音")]
    public AudioSource jumpSource;
    public AudioClip jumpClip;
    [Header("跑步聲音")]
    public AudioSource runSource;
    public AudioClip runClip;
    [Header("NPC甦醒聲音")]
    public AudioSource npcWakeUpSource;
    public AudioClip npcWakeUpClip;
    [Header("開寶箱聲音")]
    public AudioSource chestSource;
    public AudioClip chestClip;
    [Header("開門聲音")]
    public AudioSource doorSource;
    public AudioClip doorClip;
    public AudioSource doorCantSource;
    public AudioClip doorCantClip;
    [Header("按鈕聲音")]
    public AudioSource buttonSource;
    public AudioClip buttonClip;
    [Header("喝水聲音")]
    public AudioSource drinkSource;
    public AudioClip drinkClip;
    [Header("喘氣聲音")]
    public AudioSource breathSource;
    public AudioClip breathClip;
    [Header("笑聲")]
    public AudioSource laughSource;
    public AudioClip laughClip;
}