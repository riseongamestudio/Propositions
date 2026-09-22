using System;
using RiseOn.Serializables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("Not")]
    public class PropositionNot : Proposition {
        [SerializeField, Required]
        private SerRef<IProposition> proposition;

        public override bool Evaluate() {
            return !proposition.Value.Evaluate();
        }
    }
}