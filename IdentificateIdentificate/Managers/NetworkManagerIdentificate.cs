using Unity.Netcode;
using Unity;

namespace IdentificateIdentificate.Managers
{
    internal class NetworkManagerIdentificate : NetworkBehaviour
    {
        public static NetworkManagerIdentificate instance;

        void Awake()
        {
            instance = this;
        }

        [ServerRpc]
        public void RequestPlayIdentificateServerRpc()
        {
            PlayIdentificateClientRpc();
        }

        [ClientRpc]
        public void PlayIdentificateClientRpc()
        {
            IdentificateIdentificateBase.mls.LogInfo("IDENTIFICATE IDENTIFICATE");
        }

    }
}
