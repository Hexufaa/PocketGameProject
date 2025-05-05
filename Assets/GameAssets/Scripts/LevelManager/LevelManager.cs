using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using System.Linq;
//using static ArtManager;
public class LevelManager : MonoBehaviour
{
    // funcionando, falta arrumar o spawn de peças que sempre spawna algumas iguais no começo
    public Transform container;
    public List<GameObject> Levels;

    public List<LevelPieceBase> levelPieces;
    //public int pieceNumber = 5;
    public List<LevelPieceBasedSetup> levelPieceBasedSetups;
    public ArtManager.ArtType artType;


    [SerializeField] private int _index;
    private GameObject _currentLevel;
    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();

    private LevelPieceBasedSetup _currSetup;


    private void Awake()
    {
        _currSetup = levelPieceBasedSetups.FirstOrDefault(setup => setup.artType == artType);

        SpawnNextLevel();
        CreateLevelPIECES();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextLevel();
            CreateLevelPIECES();
        }
    }
    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
        }
            _index++;
        
        if(_index >= Levels.Count)
        {
            ResetLevelIndex();
        }
        _currentLevel = Instantiate(Levels[_index], container); 
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
       
        var piece = list[UnityEngine.Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            var artSetup = ArtManager.Instance.GetSetupByType(_currSetup.artType);
            if (artSetup != null)
                p.ChangePiece(artSetup.gameObject);
        }
                ColorManager.Instance.ChangeColorByType(_currSetup.artType);
        _spawnedPieces.Add(spawnedPiece);
    }
    private void CreateLevelPIECES()
    {
        CleanSpawnedPieces();
        _index++;
        if (_index >= levelPieceBasedSetups.Count) { ResetLevelIndex(); }
            _currSetup = levelPieceBasedSetups[_index];

        if (_currSetup != null)
        {
            for (int i = 0; i < _currSetup.pieceNumber; i++)
            {
                CreateLevelPiece(_currSetup.levelPiece);
            }
        }//


    }
    
    private void CleanSpawnedPieces()
    {
        for(int i = _spawnedPieces.Count-1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();

    }
}
