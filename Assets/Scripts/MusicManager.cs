using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public bool _isMusicScreen = false;
    private GameObject _musicCanvas;
    private GameObject[] _mBtns = new GameObject[5];
    private MusicPlayer _mPlayer;
    public AudioClip GSM, DSM, Let, Satis, Pheonix;

    private void Awake()
    {
        _mPlayer = GameObject.FindWithTag("MusicPlayer").GetComponent<MusicPlayer>();
        _musicCanvas = GameObject.Find("AudioCanvas");
        for (int i = 0; i < _mBtns.Length; i++)
        {
            _mBtns[i] = _musicCanvas.transform.GetChild(i).gameObject;
        }
    }

    public void PlayStop()
    {
        if (!_isMusicScreen)
        {
            for (int i = 0; i < _mBtns.Length; i++)
            {
                _mBtns[i].SetActive(true);
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isMusicScreen = true;
        }
        else
        {
            for (int i = 0; i < _mBtns.Length; i++)
            {
                _mBtns[i].SetActive(false);
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isMusicScreen = false;
        }
    }

    public void PlayGSM() { _mPlayer.SetMp3(GSM); }
    public void PlayDSM() { _mPlayer.SetMp3(DSM); }
    public void PlayLet() { _mPlayer.SetMp3(Let); }
    public void PlaySatis() { _mPlayer.SetMp3(Satis); }
    public void PlayPheonix() { _mPlayer.SetMp3(Pheonix); }
}
