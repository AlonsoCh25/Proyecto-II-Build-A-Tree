/**
 * Esta clase corresponde al codigo del arbol Splay, el cual consiste de llevar el nodo de "menor prioridad" hacia la raiz
 * @autor Kenneth Castillo, Olman Rodriguez y Montserrat Monge.
 * @version 08/12/2020
 */
public class SplayTree {
    private SplayNode root;
    private int count = 0;

    /**
     *  Constructor
     */
    public SplayTree()
    {
        root = null;
    }

    /**
     * Verifica si el arbol esta vacio
     */
    public boolean isEmpty()
    {
        return root == null;
    }

    /**
     * Limpiar el arbol
     */
    public void clear()
    {
        root = null;
        count = 0;
    }

    /**
     * Se encargade la insercion de un elemento
     */
    public void insert(int ele)
    {
        SplayNode z = root;
        SplayNode p = null;
        while (z != null)
        {
            p = z;
            if (ele > p.element)
                z = z.right;
            else
                z = z.left;
        }
        z = new SplayNode();
        z.element = ele;
        z.parent = p;
        if (p == null)
            root = z;
        else if (ele > p.element)
            p.right = z;
        else
            p.left = z;
        Splay(z);
        count++;
    }
    /**
     * rotacion del arbol
     */
    public void makeLeftChildParent(SplayNode c, SplayNode p)
    {
        if ((c == null) || (p == null) || (p.left != c) || (c.parent != p))
            throw new RuntimeException("WRONG");

        if (p.parent != null)
        {
            if (p == p.parent.left)
                p.parent.left = c;
            else
                p.parent.right = c;
        }
        if (c.right != null)
            c.right.parent = p;

        c.parent = p.parent;
        p.parent = c;
        p.left = c.right;
        c.right = p;
    }

    /**
     * rotacion del nodo por el padre
     */
    public void makeRightChildParent(SplayNode c, SplayNode p)
    {
        if ((c == null) || (p == null) || (p.right != c) || (c.parent != p))
            throw new RuntimeException("WRONG");
        if (p.parent != null)
        {
            if (p == p.parent.left)
                p.parent.left = c;
            else
                p.parent.right = c;
        }
        if (c.left != null)
            c.left.parent = p;
        c.parent = p.parent;
        p.parent = c;
        p.right = c.left;
        c.left = p;
    }

    /**
     *  Realizacion del splay
     */
    private void Splay(SplayNode x)
    {
        while (x.parent != null)
        {
            SplayNode Parent = x.parent;
            SplayNode GrandParent = Parent.parent;
            if (GrandParent == null)
            {
                if (x == Parent.left)
                    makeLeftChildParent(x, Parent);
                else
                    makeRightChildParent(x, Parent);
            }
            else
            {
                if (x == Parent.left)
                {
                    if (Parent == GrandParent.left)
                    {
                        makeLeftChildParent(Parent, GrandParent);
                        makeLeftChildParent(x, Parent);
                    }
                    else
                    {
                        makeLeftChildParent(x, x.parent);
                        makeRightChildParent(x, x.parent);
                    }
                }
                else
                {
                    if (Parent == GrandParent.left)
                    {
                        makeRightChildParent(x, x.parent);
                        makeLeftChildParent(x, x.parent);
                    }
                    else
                    {
                        makeRightChildParent(Parent, GrandParent);
                        makeRightChildParent(x, Parent);
                    }
                }
            }
        }
        root = x;
    }

    /**
     * Se encarga de remover el elemento deseado
     **/
    public void remove(int ele)
    {
        SplayNode node = findNode(ele);
        remove(node);
    }

    /**
     *  Se encarga de remover el nodo deseado
     */
    private void remove(SplayNode node)
    {
        if (node == null)
            return;
        Splay(node);
        if( (node.left != null) && (node.right !=null))
        {
            SplayNode min = node.left;
            while(min.right!=null)
                min = min.right;

            min.right = node.right;
            node.right.parent = min;
            node.left.parent = null;
            root = node.left;
        }
        else if (node.right != null)
        {
            node.right.parent = null;
            root = node.right;
        }
        else if( node.left !=null)
        {
            node.left.parent = null;
            root = node.left;
        }
        else
        {
            root = null;
        }
        node.parent = null;
        node.left = null;
        node.right = null;
        node = null;
        count--;
    }

    /**
     * Se encarga de contar el numero de nodos que contiene el arbol
     */
    public int countNodes()
    {
        return count;
    }

    /**
     * Funcion para buscar un elemento del arbol
     */
    public boolean search(int val)
    {
        return findNode(val) != null;
    }

    /**
     * Se encarga de buscar el nodo deseadp
     * @param ele elemento a buscar
     * @return
     */
    private SplayNode findNode(int ele)
    {
        SplayNode PrevNode = null;
        SplayNode z = root;
        while (z != null)
        {
            PrevNode = z;
            if (ele > z.element)
                z = z.right;
            else if (ele < z.element)
                z = z.left;
            else if(ele == z.element) {
                Splay(z);
                return z;
            }

        }
        if(PrevNode != null)
        {
            Splay(PrevNode);
            return null;
        }
        return null;
    }

    /**
     * Realiza el recorrido in/orden
     */
    public void inorder()
    {
        inorder(root);
    }
    private void inorder(SplayNode r)
    {
        if (r != null)
        {
            inorder(r.left);
            System.out.print(r.element +" ");
            inorder(r.right);
        }
    }
    /**
     * Realiza el recorrido pre/orden
     */
    public void preorder()
    {
        preorder(root);
    }
    private void preorder(SplayNode r)
    {
        if (r != null)
        {
            System.out.print(r.element +" ");
            preorder(r.left);
            preorder(r.right);
        }
    }
    /**
     * Realiza el recorrido post/orden
     */
    public void postorder()
    {
        postorder(root);
    }
    private void postorder(SplayNode r)
    {
        if (r != null)
        {
            postorder(r.left);
            postorder(r.right);
            System.out.print(r.element +" ");
        }
    }
}

