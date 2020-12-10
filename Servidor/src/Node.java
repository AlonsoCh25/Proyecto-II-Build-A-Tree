/**
 * Esta clase corresponde al nodo que usaran los arboles, splay, AVL, BTree y BTS
 * @autor Kenneth Castillo, Olman Rodriguez y Montserrat Monge.
 * @version 08/12/2020
 */
public class Node {
    Object data;
    Node right;
    Node left;
    public Node(Object data, Node right, Node left){
        this.data = data;
        this.left = left;
        this.right = right;
    }

    /**
     * cambia los valores de los datos
     * @param data dato cambiado si es nacesario
     */
    public void setData(Object data) {
        this.data = data;
    }
    public Object getData() {
        return data;
    }
    public void setLeft(Node left) {
        this.left = left;
    }
    public void setRight(Node right) {
        this.right = right;
    }

    /**
     * obtiene el valor de los datos
     * @return dato obtenido
     */
    public Node getRight() {
        return right;
    }
    public Node getLeft() {
        return left;
    }
}
