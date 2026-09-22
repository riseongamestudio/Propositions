using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("At Most")]
    public class ConnectiveAtMost : IConnective {
        [SerializeField, Min(0)]
        private int count = 1;

        public bool Evaluate(IReadOnlyList<IProposition> operands) {
            var hits = 0;

            for (var i = 0; i < operands.Count && hits <= count; ++i) {
                if (operands[i].Evaluate()) ++hits;
            }

            return hits <= count;
        }
    }
}