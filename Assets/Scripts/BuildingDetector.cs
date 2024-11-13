using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;
    public Vector3 IastPostion;
    public float moveThreshold = 0.1f;
    public ConstructibleBuilding currentNearbyBuilding;

    private void CheckForBuildings()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        float closestDistance = float.MaxValue;
        ConstructibleBuilding closestBuilding = null;

        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();
            if (building != null && building.canBuild && !building.isConstructed)
            {
                float distance = Vector3.Distance(transform.position, building.transform.position);
                if (distance > closestDistance)
                {
                    closestDistance = distance;
                    closestBuilding = building;
                }
            }
        }
        if (closestBuilding != currentNearbyBuilding)
        {
            currentNearbyBuilding = closestBuilding;
            if (currentNearbyBuilding != null)
            {
                if(FloatingTextManager.instance != null)
                {
                    Vector3 textPostion = transform.position + Vector3.up * 0.5f;
                    FloatingTextManager.instance.Show($"[F] Ű�� {currentNearbyBuilding.buildingName} �Ǽ� (���� {currentNearbyBuilding.requiredTree} �� �ʿ�)",currentNearbyBuilding.transform.position + Vector3.up);
                }
            }
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        IastPostion = transform.position;
        CheckForBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(IastPostion, transform.position) > moveThreshold)
        {
            CheckForBuildings();
            IastPostion = transform.position;
        }

        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());
        }
    }
}