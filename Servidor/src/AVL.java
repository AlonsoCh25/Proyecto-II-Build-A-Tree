public class AVL{
    private NodeAVL root;

    public AVL(){
        root = null;
    }
    public NodeAVL obtenerRaiz(){
        return root;
    }
    //Buscar
    public NodeAVL buscar(int d, NodeAVL r){
        if (root == null){
            return null;
        }else if ((int)r.data == d){
            return r;
        }else if  ((int) r.data < d){
            return buscar(d,r.right);
        }else{
            return buscar(d,r.left);
        }
    }
    //Obtener el Factor de Equilibrio
    public int obtenerFE(NodeAVL x){
        if (x == null){
            return -1;
        }else {
            return x.height;
        }
    }
    //rotacion Simple izquierda
    public NodeAVL rotacionIzquierda(NodeAVL c){
        NodeAVL auxiliar = c.left;
        c.left = auxiliar.right;
        auxiliar.right = c;
        c.height = Math.max(obtenerFE(c.left),obtenerFE(c.right))+1;
        auxiliar.height = Math.max(obtenerFE(auxiliar.left),obtenerFE(auxiliar.right))+1;
        return auxiliar;
    }
    //Rotacion simple derecha
    public NodeAVL rotacionDerecha(NodeAVL c){
        NodeAVL auxiliar = c.right;
        c.right = auxiliar.left;
        auxiliar.left = c;
        c.height = Math.max(obtenerFE(c.left),obtenerFE(c.right))+1;
        auxiliar.height = Math.max(obtenerFE(auxiliar.left),obtenerFE(auxiliar.right))+1;
        return auxiliar;
    }
    //Rotacion Doble a la Derecha
    public NodeAVL rotacionDobleIzquierda(NodeAVL c){
        NodeAVL temporal;
        c.left = rotacionDerecha(c.left);
        temporal = rotacionIzquierda(c);
        return temporal;
    }
    //Rotacion Doble a la Izquierda
    public NodeAVL rotacionDobleDerecha(NodeAVL c){
        NodeAVL temporal;
        c.right = rotacionIzquierda(c.right);
        temporal = rotacionDerecha(c);
        return temporal;
    }
    //Metodo insertar AVL
    public NodeAVL insertarAVL(NodeAVL nuevo, NodeAVL subAr){
        NodeAVL nuevoPadre = subAr;
        if ((int)nuevo.data < (int)subAr.data){
            if (subAr.left == null){
                subAr.left = nuevo;
            }else {
                subAr.left = insertarAVL(nuevo, subAr.left);
                if((obtenerFE(subAr.left))-(obtenerFE(subAr.right)) == 2){
                    if ((int)nuevo.data < (int)subAr.right.data){
                        nuevoPadre = rotacionIzquierda(subAr);
                    }else {
                        nuevoPadre = rotacionDobleIzquierda(subAr);
                    }
                }
            }
        }else if ((int)nuevo.data > (int)subAr.data){
            if (subAr.right == null){
                subAr.right = nuevo;
            }else{
                subAr.right = insertarAVL(nuevo,subAr.right);
                if ((obtenerFE(subAr.right))-(obtenerFE(subAr.left)) == 2){
                    if ((int)nuevo.data > (int)subAr.right.data){
                        nuevoPadre = rotacionDerecha(subAr);
                    }else{
                        nuevoPadre = rotacionDobleDerecha(subAr);
                    }
                }
            }
        } else {
            System.out.println("Nodo duplicado");
        }
        //Actualizar la altura
        if ((subAr.left == null) && (subAr.right != null)){
            subAr.height = subAr.right.height+1;
        }else if ((subAr.right==null) && (subAr.left != null)){
            subAr.height = subAr.left.height+1;
        }else {
            subAr.height = Math.max(obtenerFE(subAr.left),obtenerFE(subAr.right))+1;
        }
        return nuevoPadre;
    }
    //Metodo para insertar
    public void insertar(int d){
        NodeAVL nuevo = new NodeAVL(d);
        if (root == null){
            root = nuevo;
        }else {
            root = insertarAVL(nuevo, root);
        }
    }
    //Recorridos
    //Método para recorrer el Arbol InOrden
    public void inOrden(NodeAVL r){
        if(r != null){
            inOrden(r.left);
            System.out.println(r.data + ", ");
            inOrden(r.right);
        }
    }
    //Metodo para recorrer el Arbol Preorden
    public void preOrden(NodeAVL r){
        if (r != null){
            System.out.println(r.data + ", ");
            preOrden(r.left);
            preOrden(r.right);
        }
    }
    //Metodo para recorrer el Arbol PostOrden
    public void postOrden(NodeAVL r){
        if(r != null){
            System.out.println(r.data + ", ");
            preOrden(r.left);
            preOrden(r.right);
        }
    }
    //Metodo eliminar
    public boolean soloRaiz(NodeAVL nodo){
        if (nodo.getRight() == null && nodo.getLeft() == null){
            nodo = null;
            return true;
        }
        return false;
    }
    public NodeAVL EliminarNodo(NodeAVL nodo, int dato){
        NodeAVL subAr;
        subAr = root;
        if(soloRaiz(nodo)){
            return null;
        }
        if(nodo == null){
            System.out.println("No se encuentra el nodo");
        }else if (dato < (int)nodo.getData()){
            NodeAVL left;
            left = EliminarNodo(nodo.getLeft(), dato);
            nodo.setLeft(left);
        }else if (dato > (int)nodo.getData()){
            NodeAVL right;
            right = EliminarNodo(nodo.getRight(),dato);
            nodo.setData(right);
        }else{
            NodeAVL eliminar;
            eliminar = nodo;
            if (eliminar.getLeft() == null){
                nodo = eliminar.getRight();
            }else if (eliminar.getRight() == null){
                nodo = eliminar.getLeft();
            }else {
                eliminar = reemplazar(eliminar);
            }
            eliminar = null;
            if ((subAr.left == null) && (subAr.right != null)){
                subAr.height = subAr.right.height+1;
            }else if ((subAr.right==null) && (subAr.left != null)){
                subAr.height = subAr.left.height+1;
            }else {
                subAr.height = Math.max(obtenerFE(subAr.left),obtenerFE(subAr.right))+1;
            }

        }
        return nodo;
    }
    //Metodo para eliminar
    public void eliminar(int d){
        NodeAVL nuevo = new NodeAVL(d);
        if (root == null){
            root = nuevo;
        }else {
            root = EliminarNodo(root, d);
        }
    }
    public NodeAVL reemplazar(NodeAVL nodo){
        NodeAVL N1;
        NodeAVL N2;
        N2 = nodo;
        N1 = nodo.getLeft();

        while (N1.getRight() != null){
            N2 = N1;
            N1 = N1.getRight();
        }
        nodo.setData(N1.getData());
        if (N2 == nodo){
            N2.setLeft(N1.getLeft());
        }
        else {
            N2.setRight(N1.getLeft());
        }
        return N1;
    }

}
