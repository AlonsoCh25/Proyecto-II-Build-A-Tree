namespace DefaultNamespace
{
    public class Node
    {
        private string tipo;
        private float x;
        private float y;
        public Node(string tipo, float x, float y)
        {
            this.tipo = tipo;
            this.x = x;
            this.y = y;
        }
        public string GetTipo()
        {
            return this.tipo;
        }
        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }
    }
}