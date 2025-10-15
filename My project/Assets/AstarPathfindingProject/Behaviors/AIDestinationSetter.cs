using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>

		
        public float playerdistance;
		public int distance;
        public Transform target;
		public Transform player;
		public Transform currentPath;
		public int path1dis;
        private float path1distance;
        public Transform path1;
		public int path2dis;
		private float path2distance ;
		public Transform path2;
		public bool chasePlayer = false;
        public float distanceFromBait;
		public bool isBait = false;

        IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}



        /// <summary>Updates the AI's destination every frame</summary>
        void Update() {

			
				playerdistance = Vector2.Distance(player.position, transform.position);
				

			if (playerdistance < distance && chasePlayer == true && isBait == false)
			{
				target = player;
				ai.maxSpeed = 7;
			}

			else if (isBait == false && playerdistance < distance || chasePlayer == false && isBait == false)
			{
				target = currentPath;
				ai.maxSpeed = 3;
            }

			if (playerdistance > distance)
			{
				chasePlayer = false;
            }


			path1distance = Vector2.Distance(path1.position, transform.position);
           
			if (path1distance < path1dis)
			{
				currentPath = path2;
			}
			
			path2distance = Vector2.Distance(path2.position, transform.position);


             if (path2distance < path2dis)
			{

				currentPath = path1;
            }
            if (target != null && ai != null) ai.destination = target.position;

            GameObject playerObject = GameObject.FindWithTag("Bait");
            if (playerObject != null)
            {
                target = playerObject.transform;
                isBait = true;
            }
            else
            {
                isBait = false;
            }
        }
	}
}

