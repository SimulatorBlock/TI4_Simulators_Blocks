using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceConfigure : MonoBehaviour
{
    [Header("Only rayDistance, breakForce and\nbreakTorque must be sets by hand.")]
    [Space(30)]
    [Tooltip("The MainBlock, Gets on start by the GameManager.cs")]
    [SerializeField] private GameObject mainBlock;

    [Header("Lists")]
    [Space(10)]
    [Tooltip("List of all directions that not have a block")]
    [SerializeField] private List<int> nonCollidingDirs;
    [Tooltip("List of all blocks jointed to this block")]
    [SerializeField] private List<GameObject> linkedBlocks;
    [Tooltip("Ray Distance to capture other block around this block")]

    [Header("Floats")]
    [Space(10)]
    [SerializeField] private float rayDistance = 0.75f;
    private readonly RaycastHit[] _hit = new RaycastHit[6];
    private readonly Vector3[] _directions = {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
        Vector3.up,
        Vector3.down
    };

    [SerializeField] private bool linkedToMain = false;

    void Start()
    {
        /* mainBlock = GameObject.Find("BlockMain");  */
        mainBlock = GameManager.instance.GetMainBlock;
        Configure();
        IdentityBlocks();
        if (this.gameObject.name != mainBlock.name)
        {
            IsLinkedToMain();
        }
        // InEditMode();
    }
    void Update()
    {
        TestDraw();
    }

    /// <summary>
    ///     Function that must be called in the main function, this function creates a ray in all directions and add to list linked all blocks found
    /// </summary>
    private void Configure()
    {
        if (this.gameObject != mainBlock)
        {
            //Here we tells which block is around then this
            for (int i = 0; i < _directions.Length; i++)
            {
                bool colliding = Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);

                if (colliding && (_hit[i].collider.gameObject.tag == "Block" || _hit[i].collider.gameObject.tag == "Wheel"))
                {
                    linkedBlocks.Add(_hit[i].collider.gameObject);//Here we add to the linkedBlocks list all blocks linked to the block created
                    // Debug.Log(this.gameObject.name);
                    _hit[i].collider.gameObject.GetComponent<PieceConfigure>().IdentityBlocks();
                    if ((!_hit[i].collider.gameObject.GetComponent<PieceConfigure>().GetLinkedBlocks().Contains(this.gameObject)) && _hit[i].collider.gameObject.GetComponent<PieceConfigure>().GetLinkedBlocks().Count > 0)
                    {
                        List<GameObject> _linkedBlocks = _hit[i].collider.gameObject.GetComponent<PieceConfigure>().GetLinkedBlocks();
                        _linkedBlocks.Add(this.gameObject);
                        _hit[i].collider.gameObject.GetComponent<PieceConfigure>().SetLinkedBlocks(_linkedBlocks);
                    }
                }
            }
        }
    }
    /// <summary>
    ///     This is native function that check if the mouse is clicked over the block, i used this function to set the selected block to camera lock over he.
    /// </summary>
    private void OnMouseDown()
    {
        GameManager.instance.SetSelectedBlock(this.gameObject);
    }
    /// <summary>
    ///     This is native function that check if the object was destroyed, i use this function to order all blocks linked in this, check the new direction without a block.
    /// </summary>
    private void OnDestroy()
    {
        foreach (GameObject block in linkedBlocks)
        {
            if (block != null)
            {
                block.GetComponent<PieceConfigure>().IdentityBlocks();
                block.GetComponent<PieceConfigure>().IdentityLinkedBlocks();
            }
        }
    }

    private void IsLinkedToMain(){
        foreach (GameObject obj in linkedBlocks)
        {
            if (obj.name == mainBlock.name)
            {
                linkedToMain = true;
            }
            else if(obj.GetComponent<PieceConfigure>().LinkedToMain)
            {
                linkedToMain = true;
            }
            else
            {
                linkedToMain = false;
            }
        }
        if(linkedBlocks.Count == 0)
            linkedToMain = false;
        if (this.gameObject.transform.parent.parent.name != "Vehicle")
        {
            if (!linkedToMain)
            {
                Destroy(this.gameObject.GetComponent<Block.BlockBehavior>());
                Destroy(this.gameObject.GetComponent<PieceMaterial>());
                this.transform.SetParent(null);
                this.gameObject.AddComponent<Rigidbody>();
                Destroy(this);
            }
        }
    }

    /// <summary>
    ///     This public function is used for check directions that's not contains a block.
    /// </summary>
    public void IdentityBlocks()
    {
        // Debug.Log($"chamou: {this.gameObject.name}");
        nonCollidingDirs.Clear();
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);
            if (!colliding)
            {
                // print(name + " - " + "Direção: " + i + ";");
                nonCollidingDirs.Add(i);
            }
        }
    }
    public void IdentityLinkedBlocks()
    {
        linkedBlocks.Clear();
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);
            if (colliding && (_hit[i].collider.gameObject.tag == "Block" || _hit[i].collider.gameObject.tag == "Wheel"))
            {
                linkedBlocks.Add(_hit[i].collider.gameObject);
            }
        }
    }
    /// <summary>
    ///     Public function thats used for get the linkedBlocks list.
    /// </summary>
    /// <returns>
    ///     linkedBlocks list
    /// </returns>
    public List<GameObject> GetLinkedBlocks()
    {
        return linkedBlocks;
    }
    /// <summary>
    ///     Public function thats used for set the linkedBlocks list.
    /// </summary>
    public void SetLinkedBlocks(List<GameObject> _linkedBlocks)
    {
        linkedBlocks = _linkedBlocks;
    }
    /// <summary>
    ///     Public function thats used for get the nonCollidingDirs list.
    /// </summary>
    /// <returns>
    ///     nonCollidingDirs list
    /// </returns>
    public List<int> GetNonColliderDirs()
    {
        return nonCollidingDirs;
    }

    public bool LinkedToMain => linkedToMain;
    /// <summary>
    ///     Private function that is used to draw and debug casted rays
    /// </summary>
    private void TestDraw()
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            if (Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance))
            {
                if (_hit[i].collider.gameObject.tag == "Block" || _hit[i].collider.gameObject.tag == "Wheel")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(_directions[i]) * _hit[i].distance, Color.red);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, _directions[i] * rayDistance, Color.white);
            }
        }
    }
}
