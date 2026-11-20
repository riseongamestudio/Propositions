using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    /// <summary>
    /// Keeps a proposition on a component, so several trees in the scene can share it through <see cref="PropositionExternal"/>.
    /// </summary>
    [HideMonoScript]
    public class PropositionComp : MonoBehaviour, IProposition {
        [SerializeReference, HideLabel]
        private IProposition proposition;

        public bool Evaluate() {
            return proposition.Evaluate();
        }
    }
}