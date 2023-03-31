using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class SurfaceBuilder : MonoBehaviour
{
    [SerializeField]
    List<Vector2> _hiddenQuad = new List<Vector2>();

    [SerializeField] Transform _lowLeftAnchor, _upRightAnchor;
    [SerializeField] Vector2 _tiling = Vector2.one;

    List<Vector3> _vertices = new List<Vector3>();
    List<int> _tris = new List<int>();
    List<Vector2> _uvs = new List<Vector2>();

    int[] trisOrder = new int[6] { 0, 1, 2, 2, 1, 3 };

    [SerializeField] MeshFilter _meshFilter;

    [SerializeField] MeshCollider _meshCollider;

    Mesh _mesh;

    [SerializeField] bool _snappOnGrid;
    [SerializeField] float _griddSize = 1;

    float _down, _up, _left, _right, _downDepth, _upDepth;

    float _quadSize = 1;

    bool _needUpdate
    {
        get
        {
            if (_lowLeftAnchor.hasChanged) return true;
            if (_upRightAnchor.hasChanged) return true;

            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _mesh = new Mesh();

    }

    private void Update()
    {
        if (_needUpdate) CreateFace();
    }

    void CreateFace()
    {
        _vertices.Clear();
        _tris.Clear();
        _uvs.Clear();

        Debug.Log("Create face");
        _mesh.Clear();

        _down = _lowLeftAnchor.localPosition.y;
        _up = _upRightAnchor.localPosition.y;
        _left = _lowLeftAnchor.localPosition.x;
        _right = _upRightAnchor.localPosition.x;
        _downDepth = _lowLeftAnchor.localPosition.z;
        _upDepth = _upRightAnchor.localPosition.z;

        if (_snappOnGrid)
        {
            _down = Round(_down);
            _up = Round(_up);
            _left = Round(_left);
            _right = Round(_right);
            _downDepth = Round(_downDepth);
            _upDepth = Round(_upDepth);

            SnappCurrentOnGridd();
        }

        _lowLeftAnchor.localPosition = new Vector3(_left, _down, _downDepth);
        _upRightAnchor.localPosition = new Vector3(_right, _up, _upDepth);


        float _sizeX = (_right - _left);

        int XQuadCount = (int)(_sizeX / _quadSize);
       // if ((_sizeX / _quadSize) % 2 > 0) XQuadCount++;

        float _sizeY = (_up - _down);

        float _sqrtSizeY = (float)Math.Sqrt(((_up - _down) * (_up - _down)) + ((_upDepth - _downDepth) * (_upDepth - _downDepth)));
        int YQuadCount = (int)(_sqrtSizeY / _quadSize);
       // if ((_sqrtSizeY / _quadSize) % 2 > 0) YQuadCount++;

        float _sizeZ = (_upDepth - _downDepth);

        int _createdFaceCount = 0;

        Debug.Log(XQuadCount+"/"+ YQuadCount);

        for (int x = 0; x < XQuadCount; x++)
        {
            for (int y = 0; y < YQuadCount; y++)
            {
                if (_hiddenQuad.Contains(new Vector2(x, y))) continue;
                Vector3 _lowLeftanchor = new Vector3(x * _quadSize, (_sizeY / YQuadCount) * y, (_sizeZ / YQuadCount) * y);
                Vector3 _upRightanchor = new Vector3((x + 1) * _quadSize, (_sizeY / YQuadCount) * (y + 1), (_sizeZ / YQuadCount) * (y + 1));
                CreateQuad(_lowLeftanchor, _upRightanchor);
                AddUVS(x, y, XQuadCount, YQuadCount);
                _createdFaceCount++;
            }
        }

        //Triangles creation
        for (int i = 0; i < _createdFaceCount; i++)
        {
            for (int j = 0; j < trisOrder.Length; j++)
            {
                _tris.Add(trisOrder[j] + (i * 4));
            }
        }

        _mesh.SetVertices(_vertices);
        _mesh.SetTriangles(_tris, 0);
        _mesh.SetUVs(0, _uvs);

        _meshFilter.sharedMesh = _mesh;

        _lowLeftAnchor.hasChanged = false;
        _upRightAnchor.hasChanged = false;

        _meshCollider.sharedMesh = _mesh;
    }

    void CreateQuad(Vector3 _localLowLeftAnchor, Vector3 _localUpRightAnchor)
    {
        float _down = _localLowLeftAnchor.y;
        float _up = _localUpRightAnchor.y;
        float _left = _localLowLeftAnchor.x;
        float _right = _localUpRightAnchor.x;
        float _downDepth = _localLowLeftAnchor.z;
        float _upDepth = _localUpRightAnchor.z;

        _vertices.Add(new Vector3(_right, _up, _upDepth));
        _vertices.Add(new Vector3(_right, _down, _downDepth));
        _vertices.Add(new Vector3(_left, _up, _upDepth));
        _vertices.Add(new Vector3(_left, _down, _downDepth));
    }

    float Round(float _value)
    {
        int muliple = (int)(_value / _griddSize);

        return muliple * _griddSize;

    }

    void SnappCurrentOnGridd()
    {
        Vector3 _pos = transform.position;
        _pos.x = Round(_pos.x);
        _pos.y = Round(_pos.y);
        _pos.z = Round(_pos.z);

        transform.position = _pos;

    }

    void AddUVS(float _coordX, float _coordY, float _xQuadCount, float _YQuadCount)
    {

        float _uStep = _tiling.x;
        float _startX = _uStep * _coordX;
        float _endX = _uStep * (_coordX + 1);

        float _vStep = _tiling.y;
        float _startY = _vStep * _coordY;
        float _endY = _vStep * (_coordY + 1);

        _uvs.Add(new Vector2(_endX, _endY));
        _uvs.Add(new Vector2(_endX, _startY));
        _uvs.Add(new Vector2(_startX, _endY));
        _uvs.Add(new Vector2(_startX, _startY));
    }

}

