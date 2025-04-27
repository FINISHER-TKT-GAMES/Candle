using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NavMesh : MonoBehaviour {

    public PlayerManager player;

    public NavMeshAgent agent;
    public Transform npc;

    public Vector3 origin;
    public Transform pattern;
    public bool arrived;

    public enum State {at_origin, at_pattern, travelling}
    public State state;


    void Start() {
        origin = npc.position;
        arrived = false;
        player.data.isInteracting = false;
    }

    void Update() {
        if (!player.data.isInteracting) {
            if (!agent.isStopped) {
                Cycle();
            } 
            else {
                agent.isStopped = false;
                Cycle();
            }
        } 
        else {
            agent.isStopped = true;
        }
    }

    // Check the current state of the agent
    private void CheckState() {
        if (npc.position.z == origin.z && npc.position.x == origin.x) {
            state = State.at_origin;
            arrived = false;
        }
        else if (npc.position.z == pattern.position.z && npc.position.x == pattern.position.x) {
            state = State.at_pattern;
            arrived = true;
        }
        else {
            state = State.travelling;
        }
    }

    private void Cycle() {
        CheckState();
        if (state == State.at_origin) {
            agent.SetDestination(pattern.position);
        }
        else if (state == State.at_pattern) {
            agent.SetDestination(origin);
        }
    }
}
