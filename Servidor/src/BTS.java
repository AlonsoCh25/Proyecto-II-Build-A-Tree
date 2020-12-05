public class BTS {
    Node root;
    public BTS(){
        this.root = null;
    }
    public boolean isEmpty(){
        return this.root == null;
    }
    public Node FindMax(){
        if(isEmpty()){
            return null;
        }else{
            return this.findmax();
        }
    }
    private Node findmin(){
        Node node = null;
        while (this.root.getLeft() != null){
            node = this.root.getLeft();
        }
        return node;
    }
    public Node FindMin(){
        if(isEmpty()){
            return null;
        }else{
            return this.findmin();
        }
    }
    private Node findmax(){
        Node node = null;
        while (this.root.getRight() != null){
            node = this.root.getRight();
        }
        return node;
    }
    public void insert(Object data){
        this.root = this.Insert(data ,this.root);
    }
    private Node Insert(Object data, Node node){
        if(node == null){
            return new Node(data, null, null);
        }

        return node;
    }
}
