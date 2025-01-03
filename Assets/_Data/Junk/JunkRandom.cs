using UnityEngine;

[RequireComponent(typeof(JunkCtrl))]
public class JunkRandom : BaseMonobehaviour
{
    [Header(" Elements")]
    [SerializeField] protected JunkCtrl _junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (_junkCtrl != null) return;
        _junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Vector3 spawnPos = transform.position;
        Quaternion rotation = Quaternion.identity;

        Transform junkTransfom = _junkCtrl.JunkSpawner.Spawn(JunkSpawner.ASTEROID_1, spawnPos, rotation);
        junkTransfom.gameObject.SetActive(true);

        Invoke(nameof(JunkSpawning), 1f);
    }
}
