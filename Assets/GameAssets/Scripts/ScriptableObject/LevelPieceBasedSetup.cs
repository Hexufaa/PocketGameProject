using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;
    [Header("Pieces")]
    public List<LevelPieceBase> levelPiece;



    public int pieceNumber = 3;
}