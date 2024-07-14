using System;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace AssemblyCSharp {
    sealed class CollectibleCollector : MonoBehaviour {
        [SerializeField]
        uint amountCollected = 0;

        public void Collect(uint amount) {
            amountCollected += amount;
        }
    }
}
