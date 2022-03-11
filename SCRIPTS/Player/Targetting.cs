using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public List<Transform> targets;
    public Transform selectedTarget;

    private Transform playerTransform;
    public float rangeOfTargetting;
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<Transform>();
        selectedTarget = null;
        playerTransform = transform;
        AddAllEnemies();
    }
    public void AddAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
            AddTarget(enemy.transform);
    }
    public void AddTarget(Transform enemy)
    {
        targets.Add(enemy);
    }
    private void SortTargetsByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2) {
            return (Vector3.Distance(t1.position, playerTransform.position)
            .CompareTo(Vector3.Distance(t2.position, playerTransform.position)));
        });
    }
    private void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            SortTargetsByDistance();
            selectedTarget = targets[0];
        }
        else
        {
            int index = targets.IndexOf(selectedTarget);

            if (index < targets.Count - 1)
                index++;
            else
                index = 0;
            DeselectTarget();
            selectedTarget = targets[index];
        }
        SelectTarget();
    }
    private void SelectTarget()
    {
        selectedTarget.GetComponent<Renderer>().material.color = Color.red;

        BattleController bc = (BattleController)GetComponent("BattleController");
        bc.target = selectedTarget.gameObject;
    }
    private void DeselectTarget()
    {
        selectedTarget.GetComponent<Renderer>().material.color = Color.blue;
        selectedTarget = null;
    }

    public void TargetIfInRange()
    {
        if (Vector3.Distance(playerTransform.position, selectedTarget.position) <= rangeOfTargetting)
        {
            TargetEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TargetIfInRange();
    }
}
