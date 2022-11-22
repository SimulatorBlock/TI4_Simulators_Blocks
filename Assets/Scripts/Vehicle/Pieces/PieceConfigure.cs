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
    [SerializeField] private List<GameObject> blocksAround;
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
    [SerializeField] private bool directlyLinkedToMain = false;
    [SerializeField] private bool linkedToMain = false;

    public class Connection {
        private GameObject father;
        private GameObject linkedBlock;
        public Connection(GameObject _father, GameObject _linkedBlock){
            father = _father;
            linkedBlock = _linkedBlock;
        }
    }
    private List<Connection> connectedBlocks = new List<Connection>();

    void Start()
    {
        /* mainBlock = GameObject.Find("BlockMain");  */
        mainBlock = GameManager.instance.GetMainBlock;
        Configure();
        IdentityBlocks();
        if (this.gameObject.name == mainBlock.name)
        {
            if (this.transform.parent.name != "Vehicle"){
                Outlines outlines;
                if (!this.gameObject.TryGetComponent<Outlines>(out outlines))
                {
                    outlines = this.gameObject.AddComponent<Outlines>();
                }else
                {
                    outlines.OutlineWidth = 2.0f;
                }
            }
        }
        else if (this.transform.parent.parent.name != "Vehicle")
        {
            Outlines outlines;
            if (!this.gameObject.TryGetComponent<Outlines>(out outlines))
            {
                outlines = this.gameObject.AddComponent<Outlines>();
            }else
            {
                outlines.OutlineWidth = 2.0f;
            }
        }
        // if (this.gameObject.name != mainBlock.name)
        // {
        //     IsLinkedToMain(this.gameObject);
        // }
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
                    blocksAround.Add(_hit[i].collider.gameObject);//Here we add to the blocksAround list all blocks linked to the block created
                    // Debug.Log(this.gameObject.name);
                    _hit[i].collider.gameObject.GetComponent<PieceConfigure>().IdentityBlocks();
                    if ((!_hit[i].collider.gameObject.GetComponent<PieceConfigure>().GetBlocksAround().Contains(this.gameObject)) && _hit[i].collider.gameObject.GetComponent<PieceConfigure>().GetBlocksAround().Count > 0)
                    {
                        List<GameObject> _blocksAround = _hit[i].collider.gameObject.GetComponent<PieceConfigure>().GetBlocksAround();
                        _blocksAround.Add(this.gameObject);
                        _hit[i].collider.gameObject.GetComponent<PieceConfigure>().SetBlocksAround(_blocksAround);
                    }
                }
            }
        }
    }
    /// <summary>
    ///     This is native function that check if the object was destroyed, i use this function to order all blocks linked in this, check the new direction without a block.
    /// </summary>
    private void OnDestroy()
    {
        foreach (GameObject block in blocksAround)
        {
            if (block != null)
            {
                block.GetComponent<PieceConfigure>().IdentityBlocks();
                block.GetComponent<PieceConfigure>().IdentityBlocksAround();
            }
        }
    }
    public void DefineConnections(){
        foreach (GameObject block in blocksAround)
        {
            connectedBlocks.Add(new Connection(this.gameObject, block));
        }
    }
    public bool IsLinkedToMain(GameObject objectRequest){
        bool isLinked = false;
        print($"Testando conexões do bloco {this.gameObject.name}");
        foreach (GameObject obj in blocksAround)
        {
            if (obj.name == mainBlock.name)
            {
                print($"o bloco {this.gameObject.name} é diretamente ligado ao principal");
                directlyLinkedToMain = true;
                isLinked = true;
            }
            else if (obj.GetComponent<PieceConfigure>().DirectlyLinkedToMain)
            {
                print($"o bloco {this.gameObject.name} ligado com um que é diretamente ligado ao principal");
                isLinked = true;
            }
            else if (obj != objectRequest)
            {
                print($"o bloco {this.gameObject.name} é diferente do bloco de requisição");
                if (obj.GetComponent<PieceConfigure>().IsLinkedToMain(this.gameObject))
                {
                    print($"o bloco {this.gameObject.name} em alguma ligação dos blocos ligados a esse existe uma ligação ao principal");
                    isLinked = true;
                }
            }
        }
        if(blocksAround.Count == 0)
            print($"O bloco {this.gameObject.name} não é ligado a nenhum bloco");
            isLinked = false;
        // if (this.gameObject.transform.parent.parent.name != "Vehicle")
        // {
        //     if (!isLinked)
        //     {
        //         Destroy(this.gameObject.GetComponent<Block.BlockBehavior>());
        //         Destroy(this.gameObject.GetComponent<PieceMaterial>());
        //         this.transform.SetParent(null);
        //         this.gameObject.AddComponent<Rigidbody>();
        //         Destroy(this);
        //     }
        // }
        linkedToMain = isLinked;
        return isLinked;
    }

    public bool DirectlyLinkedToMain => directlyLinkedToMain;

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
    public void IdentityBlocksAround()
    {
        blocksAround.Clear();
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);
            if (colliding && (_hit[i].collider.gameObject.tag == "Block" || _hit[i].collider.gameObject.tag == "Wheel"))
            {
                blocksAround.Add(_hit[i].collider.gameObject);
            }
        }
    }
    /// <summary>
    ///     Public function thats used for get the blocksAround list.
    /// </summary>
    /// <returns>
    ///     blocksAround list
    /// </returns>
    public List<GameObject> GetBlocksAround()
    {
        return blocksAround;
    }
    /// <summary>
    ///     Public function thats used for set the blocksAround list.
    /// </summary>
    public void SetBlocksAround(List<GameObject> _blocksAround)
    {
        blocksAround = _blocksAround;
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
