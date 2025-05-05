using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "levelPieceBasedSetups")]
public class LevelPieceBasedSetup : ScriptableObject
{
    internal static int Count;
    public ArtManager.ArtType artType;
    [Header("Pieces")]
    public List<LevelPieceBase> levelPiece;

    public int pieceNumber = 3;
}