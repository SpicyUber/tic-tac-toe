using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class BoardView : MonoBehaviour
{
    private SpriteRenderer[,] _boardCellRenderers;
    private bool _instantiatedCells = false;
    private ThemeSO _theme;
     

    public void InstantiateCells(GameObject boardCellPrefab, Grid grid ,int boardSize)
    {
        if (_instantiatedCells) return;
        _instantiatedCells = true;

        _theme = Settings.Instance.Theme;

        _boardCellRenderers = new SpriteRenderer[boardSize,boardSize];

         

        for (int i = 0; i < boardSize; i++) 
        {

            for (int j = 0; j < boardSize; j++) 
            {
                Vector3 cellPosition = grid.GetCellCenterWorld(new Vector3Int(i, 0, j));
                var obj = Instantiate(boardCellPrefab, cellPosition, Quaternion.LookRotation(Vector3.up, Vector3.forward), null);
                _boardCellRenderers[i,j] = obj.GetComponent<SpriteRenderer>();
            }
        
        }
             
    }

    public void UpdateView(BoardCellState boardCellState, Vector2Int cellPosition, PlaceEffectSO effect=null)
    {
        if (!_instantiatedCells) return;

        _boardCellRenderers[cellPosition.x, cellPosition.y].sprite = _theme.GetSprite(boardCellState);

        if(effect != null)
        StartCoroutine(DoEffect(_boardCellRenderers[cellPosition.x, cellPosition.y],boardCellState,effect));

    }

    public void DrawLine(Vector3 firstPointWorldSpace, Vector3 secondPointWorldSpace, BoardCellState state, Material lineMaterial ,float durationInSeconds = 2f)
    {
        LineRenderer line = new GameObject().AddComponent<LineRenderer>();
        line.useWorldSpace = true;

        line.material=lineMaterial;
        Color color = _theme.GetColor(state)*new Color(0.5f,0.5f,0.5f);

        line.startColor = color;
        line.endColor = color;

        StartCoroutine(DrawLineCoroutine(line,firstPointWorldSpace,secondPointWorldSpace,durationInSeconds));
    }

    private IEnumerator DrawLineCoroutine(LineRenderer line, Vector3 firstPointWorldSpace, Vector3 secondPointWorldSpace, float durationInSeconds)
    {
        float t = 0;
        while(t<durationInSeconds) 
        {
            LineUtility.LerpLine(line,firstPointWorldSpace, secondPointWorldSpace, t/durationInSeconds);
            yield return null;
            t+=Time.deltaTime;
        }

        LineUtility.LerpLine(line, firstPointWorldSpace, secondPointWorldSpace, 1);
    }

    private IEnumerator DoEffect(SpriteRenderer renderer, BoardCellState boardCellState, PlaceEffectSO effect)
    {
        Vector3 particlePosition = renderer.transform.position;
        Color particleColor = _theme.GetColor(boardCellState);

        InstantiateParticle(effect.StartParticlePrefab,particleColor,particlePosition);
        new AudioSource().PlaySFX(effect.StartSound);

        float t = 0;
        while (t < effect.DurationInSeconds) 
        {
            renderer.color = Color.Lerp(effect.StartColor,effect.EndColor,t/effect.DurationInSeconds);
            yield return null;
            t+=Time.deltaTime;
        }
        renderer.color = effect.EndColor;

        new AudioSource().PlaySFX(effect.EndSound);
        InstantiateParticle(effect.EndParticlePrefab, particleColor ,particlePosition);
        
        
    }

    private void InstantiateParticle(GameObject particlePrefab, Color color, Vector3 position)
    {
        var instance = Instantiate(particlePrefab, position, Quaternion.identity);

        var particleSystems = instance.GetComponentsInChildren<ParticleSystem>();

        foreach(var ps in particleSystems)
        {
            var main = ps.main;
            main.startColor = color;
        }
    }
}
