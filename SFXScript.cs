using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SFXScript :MonoBehaviour
{
    #region ������ϥγ�ҼҦ�
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
    [Header("���D�n��")]
    public AudioSource jumpSource;
    public AudioClip jumpClip;
    [Header("�]�B�n��")]
    public AudioSource runSource;
    public AudioClip runClip;
    [Header("NPC�d���n��")]
    public AudioSource npcWakeUpSource;
    public AudioClip npcWakeUpClip;
    [Header("�}�_�c�n��")]
    public AudioSource chestSource;
    public AudioClip chestClip;
    [Header("�}���n��")]
    public AudioSource doorSource;
    public AudioClip doorClip;
    public AudioSource doorCantSource;
    public AudioClip doorCantClip;
    [Header("���s�n��")]
    public AudioSource buttonSource;
    public AudioClip buttonClip;
    [Header("�ܤ��n��")]
    public AudioSource drinkSource;
    public AudioClip drinkClip;
    [Header("�ݮ��n��")]
    public AudioSource breathSource;
    public AudioClip breathClip;
    [Header("���n")]
    public AudioSource laughSource;
    public AudioClip laughClip;
}