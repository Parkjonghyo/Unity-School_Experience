using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    private Transform _tr;
    private Transform _camTr;
    private Vector3 _movement;
    private Vector3 _angle;
    private PlayerLiftUpItem _pli;
    private MenuOpen _mOpen;
    private MusicManager _musicManager;

    private float Speed { get; } = 10f;

    private void Awake()
    {
        _tr = gameObject.GetComponent<Transform>();
        _camTr = cam.transform;
        _pli = cam.GetComponent<PlayerLiftUpItem>();
        _mOpen = GameObject.Find("SceneCanvas").GetComponent<MenuOpen>();
        _musicManager = GameObject.Find("MusicReader").GetComponent<MusicManager>();
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        _pli.LiftUpItem();
        if (!_mOpen.isSelectScreen && !_musicManager._isMusicScreen)
        {
            RotationMove(mouseX, mouseY);
            Move(h,v);   
        }
    }

    private void Update()
    {
    }

    private void RotationMove(float mouseX, float mouseY)
    {
        _tr.Rotate (new Vector3 (0,mouseX,0) * 3);
        _camTr.Rotate(new Vector3(mouseY * -1, 0, 0));
    }

    private void Move(float h, float v)
    {
        _movement.Set(h, 0, v);
        _movement = Time.deltaTime * Speed * _movement.normalized;
        
        _tr.Translate(_movement);
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, _tr.up * -1, 0.6f))
            {
                GetComponent<Rigidbody>().AddForce(0,2.7f,0,ForceMode.Impulse);   
            }
        }
        /*var position = _tr.position;*/
        /*position = new Vector3(position.x + Input.GetAxis("Horizontal") * Time.deltaTime * Speed, position.y, position.z + Input.GetAxis("Vertical") * Time.deltaTime * Speed);*/
        /*_tr.position = position;*/
    }
}