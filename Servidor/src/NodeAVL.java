
public class NodeAVL {
    Object data;
    NodeAVL right;
    NodeAVL left;
    int height;

    public NodeAVL (Object data){
        this.data = data;
        this.left = null;
        this.right = null;
        this.height = 0;

    }
    public void setData(Object data) {
        this.data = data;
    }
    public Object getData() {
        return data;
    }
    public void setLeft(NodeAVL left) {
        this.left = left;
    }
    public void setRight(NodeAVL right) {
        this.right = right;
    }
    public NodeAVL getRight() {
        return right;
    }
    public NodeAVL getLeft() {
        return left;
    }
    public void setHeight(int height) {
        this.height = height;
    }
    public int getHeight() {
        return height;
    }
}
