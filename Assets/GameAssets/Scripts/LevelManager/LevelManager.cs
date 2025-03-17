using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Pieces")]
    public List<LastPieceBase> levelsPieces;
    public int pieceNumber = 5;

    [SerializeField] private int _index;
    private GameObject _currentLevel;

    private List<LastPieceBase> _spawnedPieces;
    public float timeBetweenPieces = .3f;

    private void Awake()
    {
        //SpawnNextlevel();
        CreateLevelPieces();
    }

    private void SpawnNextlevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;
            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextlevel();
        }
    }

    #region

    private void CreateLevelPieces()
    {
        StartCoroutine(CreateLevelPiecesCoroutine());
    }

    IEnumerator CreateLevelPiecesCoroutine()
    {
        _spawnedPieces = new List<LastPieceBase>();

        for (int i = 0; i < pieceNumber; i++)
        {
            CreateLevelPiece();
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }

    private void CreateLevelPiece()
    {
        var piece = levelsPieces[Random.Range(0, levelsPieces.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    #endregion

}
