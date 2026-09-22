using System;
using RiseOn.Serializables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    [Serializable, TypeRegistryItem("External")]
    public class PropositionExternal : Proposition {
        [SerializeField, Required]
        private SerObject<IProposition> source;
        
        public override bool Evaluate() {
            return source.Value.Evaluate();
        }
    }
}