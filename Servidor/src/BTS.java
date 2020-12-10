/**
 * Esta clase corresponde a la implementacion del codigo del arbol BTS
 * @autor Kenneth Castillo, Olman Rodriguez y Montserrat Monge.
 * @version 08/12/2020
 */
public class BTS {
    Node root;
    Node last;
    public BTS(){
        this.root = null;
    }
    public boolean isEmpty(){
        return this.root == null;
    }
    public Node Findmax(Node node){
        if(isEmpty()){
            return null;
        }else{
            return this.findmax(node);
        }
    }

    /**
     * busca el nodo de valor mayor
     * @return retorna el nodo de mayor valor
     */
    public Node FindMax(){
        if(isEmpty()){
            return null;
        }else{
            return this.findmax(null);
        }
    }
    private Node findmax(Node no){
        Node node = null;
        Node current = this.root;
        if(no!=null){
            current = no;
        }
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

    /**
     * busca el nodo de menor valor en el arbol
     * @param node noso que se busca
     * @return el nodo de menor valor del arbol
     */
    public Node Findmin(Node node){
        if(isEmpty()){
            return null;
        }else{
            return this.findmin(node);
        }
    }
    public Node FindMin(){
        if(isEmpty()){
            return null;
        }else{
            return this.findmin(null);
        }
    }
    private Node findmin(Node no){
        Node node = null;
        Node current = this.root;
        if(no!=null){
            current = no;
        }
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

    /**
     * insercion de datos
     * @param data dato a insertar
     */
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

    /**
     * Borrado de datos
     * @param data dato que sera eliminado
     */
    public void Delete(Object data){
        this.delete(data, this.root);
    }
    private void delete(Object data, Node no){
        if(!isEmpty()){
            Node current = no;
            if(current.getData() == data){
                if(current.getRight() != null && current.getLeft() != null){
                    Node r = current.getRight();
                    Node l = current.getLeft();
                    current = Findmin(r);
                    current.setRight(r);
                    current.setLeft(l);
                    this.delete(current.getData(), current.getRight());
                }
                if(current.getRight() == null && current.getLeft() != null){
                    current = current.getLeft();
                    this.delete(current.getData(), current.getLeft());
                }
                if(current.getRight() != null && current.getLeft() == null){
                    Node r = current.getRight();
                    Node l = current.getLeft();
                    current = Findmin(r);
                    current.setRight(r);
                    current.setLeft(l);
                    this.delete(current.getData(), current.getRight());
                }
                if(current.getRight() == null && current.getLeft() == null){
                    if(this.last!=null){
                        if(this.last.getRight() == current){
                            this.last.setRight(null);
                            this.last = null;
                        }else{
                            this.last.setLeft(null);
                            this.last = null;
                        }
                    }else{
                        this.root = null;
                    }

                    current = null;
                }
            }
            if(current != null){
                if((int)data > (int)current.getData()){
                    this.last = current;
                    this.delete(data, current.getRight());
                }else{
                    this.last = current;
                    this.delete(data, current.getLeft());
                }
            }
        }
    }
}
