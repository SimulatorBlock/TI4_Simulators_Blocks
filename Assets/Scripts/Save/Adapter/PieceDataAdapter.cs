using UnityEngine;

namespace SaveCar{
    public class PieceDataAdapter : PieceSaveData
    {
        public PieceDataAdapter(GameObject piece){
            string _name = ""; 
            for (var i = 0; i < piece.name.Length-7; i++)
            {
                _name += piece.name[i];
            }
            name = _name;
            position = piece.transform.position;
            rotation = piece.transform.eulerAngles;
        }
    }
}