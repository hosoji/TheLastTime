using UnityEngine;
using System.Collections.Generic;

public class Effects : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public PlayerControl player;
    public ParticleSystem ps;
    public ParticleSystem bulletPS;

    private List<Vector3> playerTilePath = new List<Vector3>();


    private void OnEnable()
    {
        Tile.CrateDestroyed += TriggerParticlesOnCreateDestroyed;
        Tile.ProjectileHit += TriggerBulletExplosion;
    }

    private void OnDisable()
    {
        Tile.CrateDestroyed -= TriggerParticlesOnCreateDestroyed;
        Tile.ProjectileHit -= TriggerBulletExplosion;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!playerTilePath.Contains(player.CurrentTile.transform.position))
        {
            
            playerTilePath.Add(player.CurrentTile.transform.position);
            lineRenderer.positionCount = playerTilePath.Count;
        }
       

        //lineRenderer.SetPositions(playerTilePath.ToArray());


    }

    private void TriggerParticlesOnCreateDestroyed(Tile tile)
    {
        ps.transform.position = tile.transform.position;
        ps.Emit(Random.Range(5, 15));

    }

    private void TriggerBulletExplosion(Vector3 pos)
    {
        Debug.Log("Bull impact");
        bulletPS.transform.position = pos;
        bulletPS.Emit(1);


    }


}
