using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCRC : MonoBehaviour
{
    [System.Serializable]
    public class Weapon
    {
        public int type;
        public int power;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 同じ結果が返るかテスト
        {
            var weapon = new Weapon
            {
                type = 5,
                power = 10,
            };

            var crcA = weapon.CalcCRC();
            var crcB= weapon.CalcCRC();
            Debug.Assert(crcA == crcB);
        }

        // 異なる結果が返るかテスト
        {
            var weapon = new Weapon
            {
                type = 5,
                power = 10,
            };
            var crcA = weapon.CalcCRC();

            // 中身を書き換えてCRC値算出
            weapon.type = 10;
            weapon.power = 20;
            var crcB = weapon.CalcCRC();
            Debug.Assert(crcA != crcB);
        }
    }
}
