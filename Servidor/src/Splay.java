public class Splay {
    Node root;
    public Splay() {
        this.root = null;
    }
    //empieza el insert
    public void insert (int i, Object num){
        Node n = new Node(i);
        n.content = num;
        if (root==null){
            root = n;
        }else {
            Node aux = root;
            while (aux!=null){
                n.father = aux;
                if ((int)n.content > 0){
                    aux = aux.right;
                }else{
                    aux = aux.left;
                }
            }
        if (n.key < n.father.key){
            n.father.left = n;
        }else{
            n.father.right = n;
        }
        }
    }
    //termina el insert
    public void search (Node nodo){
        if (nodo != null){
            search(nodo.left);
            System.out.println("indice: "+ nodo.key + "numero: "+ nodo.content);
            search(nodo.right);
        }
    }
    //nodo
    private class Node{
        public Node father;
        public Node left;
        public Node right;
        public int key;
        public Object content;
        //atributos del nodo
        public Node(int index) {
            this.father = null;
            this.left = null;
            this.right = null;
            this.key = index;
            this.content = null;
        }
    }
}