using UnityEngine;


public class jellymesh : MonoBehaviour
{
    public float Intensity = 1f;
    public float Mass = 1f;
    public float stiffness = 1f;
    public float damping = 0.7f; 
    private Mesh OriginalMesh, MeshClone;
    private MeshRenderer renderer;

    private JellyVertex[] jv;
    private Vector3[] vertexArray;
    private void Start()
    {
        OriginalMesh = GetComponent<MeshFilter>().sharedMesh;
        MeshClone = Instantiate(OriginalMesh);
        GetComponent<MeshFilter>().sharedMesh = MeshClone;
        renderer = GetComponent<MeshRenderer>();
        jv = new JellyVertex[MeshClone.vertices.Length];
        for (int i =0; i<MeshClone.vertices.Length; i++)
        {
            jv[i]= new JellyVertex(i, transform.TransformPoint(MeshClone.vertices[i]));
        }
    }
    private void FixedUpdate()
    {
        vertexArray = OriginalMesh.vertices;
        for(int i =0; i<jv.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[jv[i].ID]);
            float intensity = (1-(renderer.bounds.max.y- target.y)/ renderer.bounds.size.y)*Intensity;
            jv[i].Shake(target, Mass, stiffness, damping);
            target = transform.InverseTransformPoint(jv[i].position);
            vertexArray[jv[i].ID] = Vector3.Lerp(vertexArray[jv[i].ID], target, intensity);
        }
        MeshClone.vertices = vertexArray;
    }
    public class JellyVertex
    {
        public int ID;
        public Vector3 position;
        public Vector3 velocity, force;
        public JellyVertex(int _id, Vector3 _pos)
        {
            ID = _id;
            position = _pos;

        }
        public void Shake(Vector3 target, float m, float s,float d)
        {
            force = (target - position) * s;
            velocity = (velocity + force / m) * d;
            position += velocity;
            if ((velocity + force + force / m).magnitude < 0.001f)
                position = target;
        }
    }

}