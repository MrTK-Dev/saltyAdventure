using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_InstantiateCubes : MonoBehaviour
{
    public GameObject _CubePreFab;
    GameObject[] _Cube = new GameObject[512];

    public float _MaxScale;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _InstanceCube = (GameObject)Instantiate(_CubePreFab);

            _InstanceCube.transform.position = transform.position;
            _InstanceCube.transform.SetParent(transform);
            _InstanceCube.name = "Cube [" + i + "]";

            transform.eulerAngles = new Vector3(0, -360f * i / 512f, 0);
            _InstanceCube.transform.position = Vector3.forward * 100;

            _Cube[i] = _InstanceCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_Cube != null)
            {
                _Cube[i].transform.localScale = new Vector3(1, (A_MainClass._Samples[i] * _MaxScale) + 2, 1);
            }
        }
    }
}
