using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLiftUpItem : MonoBehaviour
{
    private Vector3 _screenCenter;
    private Transform _holdingSpace;
    private Transform _tr;
    private GameObject _holding;
    private Quaternion _holdOriginalRotate;
    private Rigidbody _holdRb;
    private MenuOpen _mOpen;
    private MusicManager _musicManager;
    private bool _isHold = false;

    private void Awake()
    {
        _screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        _tr = gameObject.GetComponent<Transform>();
        _holdingSpace = gameObject.transform.GetChild(0).GetComponent<Transform>();
        _mOpen = GameObject.Find("SceneCanvas").GetComponent<MenuOpen>();
        _musicManager = GameObject.Find("MusicReader").GetComponent<MusicManager>();
    }

    public void LiftUpItem()
    {
        if (_holding != null)
        {
            // 한 방향으로만 보이게 하려면 이 코드
            _holding.transform.rotation = _tr.rotation * _holdOriginalRotate;
            _holding.transform.position = _holdingSpace.position;
            _holdRb.velocity = new Vector3(0, 0, 0);
        }

        if (!_mOpen.isSelectScreen && !_musicManager._isMusicScreen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(_screenCenter);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit))
                {
                    if (hit.collider.tag == "Item" && !_isHold)
                    {
                        _holding = hit.collider.gameObject;
                        _holdRb = _holding.GetComponent<Rigidbody>();
                        _holdOriginalRotate = _holding.GetComponent<Transform>().rotation;
                        _holdRb.useGravity = false;
                        _isHold = true;
                    }else if (hit.collider.tag == "MusicPlayer" && !_isHold)
                    {
                        _musicManager.PlayStop();
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && !_isHold && !_musicManager._isMusicScreen)
        {
            _mOpen.OpenClose();
        }
        else if (Input.GetMouseButtonDown(1) && _isHold)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                _holdRb.AddForce(transform.forward * 10f,ForceMode.Impulse);
            }
            _holdRb.useGravity = true;
            _holding = null;
            _isHold = false;
        }else if (Input.GetMouseButtonDown(1) && _musicManager._isMusicScreen)
        {
            _musicManager.PlayStop();
        }
    }
}
