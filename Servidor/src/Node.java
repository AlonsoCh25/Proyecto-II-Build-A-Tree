public class Node {
    Object data;
    Node right;
    Node left;
    public Node(Object data, Node right, Node left){
        this.data = data;
        this.left = left;
        this.right = right;
    }
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
    public Node getRight() {
        return right;
    }
    public Node getLeft() {
        return left;
    }
}
