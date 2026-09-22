using UnityEngine;

namespace RiseOn.Propositions {
    public abstract class PropositionSO : ScriptableObject, IProposition {
        protected const string ASSET_MENU_PATH = nameof(RiseOn) + "/" + nameof(Propositions) + "/";

        public abstract bool Evaluate();
    }
}