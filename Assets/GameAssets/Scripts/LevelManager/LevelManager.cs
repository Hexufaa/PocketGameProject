using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using static ArtManager;
public class LevelManager : MonoBehaviour
{

    public Transform container;
    public List<GameObject> levels;
    public List<LevelPieceBasedSetup> levelPieceBasedSetups;

    [Header("Pieces")]
    public List<LastPieceBase> levelsPieces;
    public int pieceNumber = 5;
    public float timeBetweenPieces = .3f;



    [SerializeField] private int _index;
    private GameObject _currentLevel;

    [SerializeField] private List<LastPieceBase> _spawnedPieces = new List<LastPieceBase>();


    private void Awake()
    {
        //SpawnNextlevel();
        CreateLevelPiece();

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
            CreateLevelPiece();
        }
    }

    #region

    private void CleanSpawnedPieces()
    {
    _spawnedPieces = new List<LastPieceBase>();

        var _currSetup = levelPieceBasedSetups[_index];

        if (_currSetup != null) 
        {
         
            _index++;
            if(_index >= levelPieceBasedSetups.Count)
            {
                ResetLevelIndex();
            }

        }

    }
    private void CreateLevelPieces()
    {
        //CreateLevelPiece();
        //StartCoroutine(CreateLevelPiecesCoroutine());
    }

    /*IEnumerator CreateLevelPiecesCoroutine()
    {
        CleanSpawnedPieces();

        for (int i = 0; i < pieceNumber; i++)
        {
            CreateLevelPiece();
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }*/



    private void CreateLevelPiece()
    {
        var piece = levelsPieces[Random.Range(0, levelsPieces.Count)];
        var spawnedPiece = Instantiate(piece, container);
        //ArtManager artManager = ArtManager.Instance;

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

                var _currSetup = levelPieceBasedSetups[_index]; // com erro, fala que está fora de range
        foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            //ArtManager artManager = new ArtManager();
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
        }

            _spawnedPieces.Add(spawnedPiece);
    }

    #endregion



}
