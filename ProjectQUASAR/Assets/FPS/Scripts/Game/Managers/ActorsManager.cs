using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Game
{
    public class ActorsManager : MonoBehaviour
    {
        // Test if player is getting set properly
        [SerializeField]
        private GameObject m_Player;

        [SerializeField]
        private List<Actor> m_Actors;
        public List<Actor> Actors
        {
            get
            {
                return m_Actors; 
            }
            private set
            {
                m_Actors = value; 
            }
        }
        public GameObject Player { get; private set; }

        public void SetPlayer(GameObject player)
        {
            
           Player = player;
            m_Player = player;
        }


        void Awake()
        {
            Actors = new List<Actor>();
        }
    }
}
