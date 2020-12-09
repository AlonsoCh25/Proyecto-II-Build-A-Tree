public class BTS {
    Node root;
    public BTS(){
        this.root = null;
    }
    public boolean isEmpty(){
        return this.root == null;
    }
    //busca minimo
    public Node FindMax(){
        if(isEmpty()){
            return null;
        }else{
            return this.findmax();
        }
    }
    private Node findmax(){
        Node node = null;
        Node current = this.root;
        if(current.getRight() == null){
            node = current;
        }else{
            while (current.getRight() != null){
                current = current.getRight();
                node = this.root.getRight();
            }
            node = current;
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
    //busca maximo
    private Node findmin(){
        Node node = null;
        Node current = this.root;
        if(current.getLeft() == null){
            node = current;
        }else{
            while (current.getLeft() != null){
                current = current.getLeft();
                node = this.root.getLeft();
            }
        }
        return node;
    }
    public void insert(Object data){
        this.Insert(data ,this.root);
    }
    private void Insert(Object data, Node node){
        if(isEmpty()){
            this.root = new Node(data, null, null);
        }else{
            if ((int) data < (int) node.getData()) {
                if(node.getLeft() == null) {
                    node.setLeft(new Node(data, null, null));
                }else{
                    this.Insert(data, node.getLeft());
                }
            }else{
                if(node.getRight() == null) {
                    node.setRight(new Node(data, null, null));
                }else{
                    this.Insert(data, node.getRight());
                }
            }
        }
    }
    public void Delete(Object data){
        this.delete(data);
    }
    private void delete(Object data){
        if(!isEmpty()){
            Node current = this.root;
            if(current.getRight() != null && current.getLeft() != null){
                Node r = this.root.getRight();
                Node l = this.root.getLeft();
                this.root = FindMax();
            }
            if(current.getRight() == null && current.getLeft() != null){

            }
            if(current.getRight() != null && current.getLeft() == null){

            }
            if(current.getRight() == null && current.getLeft() == null){

            }

        }
    }
}
