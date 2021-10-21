using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Admin : MonoBehaviour
{
    public CameraMove CameraMove;
    public Player Ari;
    public Player Sol;
    public Player Kayn;
    public Player Gabriel;
    public Player Clara;

    public GameObject MainCamera;
    public GameObject AriCamera;
    public GameObject SolCamera;
    public GameObject KaynCamera;
    public GameObject GabrielCamera;
    public GameObject ClaraCamera;

    public static Admin instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CameraSwich();
    }
    void CameraSwich()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CameraClear();
            MainCamera.SetActive(true);
            CameraMove.speed = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CameraClear();
            AriCamera.SetActive(true);
            Ari.speed = 9;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CameraClear();
            SolCamera.SetActive(true);
            Sol.speed = 9;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CameraClear();
            KaynCamera.SetActive(true);
            Kayn.speed = 9;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CameraClear();
            GabrielCamera.SetActive(true);
            Gabriel.speed = 9;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CameraClear();
            ClaraCamera.SetActive(true);
            Clara.speed = 9;
        }
    }
    void CameraClear()
    {
        CameraMove.speed = 0f;
        Ari.speed = 0f;
        Sol.speed = 0f;
        Kayn.speed = 0f;
        Gabriel.speed = 0f;
        Clara.speed = 0f;

        MainCamera.SetActive(false);
        AriCamera.SetActive(false);
        SolCamera.SetActive(false);
        KaynCamera.SetActive(false);
        GabrielCamera.SetActive(false);
        ClaraCamera.SetActive(false);
    }
}
