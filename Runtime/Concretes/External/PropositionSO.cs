using Sirenix.OdinInspector;
using UnityEngine;

namespace RiseOn.Propositions {
    /// <summary>
    /// Keeps a proposition in an asset, so trees in any scene can share it through <see cref="PropositionExternal"/>.
    /// </summary>
    [CreateAssetMenu(menuName = nameof(RiseOn) + "/" + nameof(Propositions) + "/" + nameof(PropositionSO))]
    public class PropositionSO : ScriptableObject, IProposition {
        [SerializeReference, HideLabel]
        private IProposition proposition;

        public bool Evaluate() {
            return proposition.Evaluate();
        }
    }
}