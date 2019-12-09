using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CubeVisu : MonoBehaviour
{
    public GameObject _CubePreFab;
    GameObject[] _Cube = new GameObject[8];

    public float _MaxScale;
    public bool _useBuffer = true;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject _InstanceCube = Instantiate(_CubePreFab);

            _InstanceCube.transform.SetParent(transform);
            _InstanceCube.name = "Cube [" + i + "]";

            //_InstanceCube.GetComponent<RectTransform>().localPosition = new Vector3(-8f + (i * 12f), 0, 0);
            _InstanceCube.transform.position = new Vector3(-8f + (i * 1f), -0.5f, 0);
            _InstanceCube.transform.localScale = new Vector3(0.5f, 0.1f, 1f);


            _Cube[i] = _InstanceCube;
        }
    }

    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_Cube != null)
            {
                if (_useBuffer)
                    _Cube[i].transform.localScale = new Vector3(0.5f, (A_MainClass._bandBuffer[i] * _MaxScale) + 0.1f, 1);
                else
                    _Cube[i].transform.localScale = new Vector3(0.5f, (A_MainClass._freqBand[i] * _MaxScale) + 0.1f, 1);
            }
        }
    }
}
