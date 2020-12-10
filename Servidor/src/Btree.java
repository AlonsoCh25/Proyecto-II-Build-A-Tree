import java.util.Stack;
/**
 * Esta clase corresponde al codigo del B Tree, el cual se encarga de mantener el las inserciones y eliminaciones de los datos en orden.
 * @autor Kenneth Castillo, Olman Rodriguez y Montserrat Monge.
 * @version 08/12/2020
 * @see https://gist.github.com/YuryShatilin/4217870
 */
public class Btree {
    private int T;
    public class Node {
        int n;
        int llave[] = new int[2*T-1];
        Node hijo[] = new Node[2*T];
        boolean hoja = true;

        public int Find(int k){
            for (int i = 0 ; i < this.n ; i++) {
                if (this.llave[i] == k) {
                    return i;
                }
            }
            return -1;
        };
    }

    /**
     * Atributos del arbol
     * @param _T entrada del arbol
     */
    public Btree(int _T) {
        T = _T;
        raiz = new Node();
        raiz.n = 0;
        raiz.hoja = true;
    }
    private Node raiz;
    private Node Search (Node x,int llave) {
        int i = 0;
        if (x == null) return x;
        for (i = 0 ; i < x.n ; i++) {
            if (llave < x.llave[i]) {
                break;
            }
            if (llave == x.llave[i]) {
                return x;
            }
        }
        if (x.hoja) {
            return null;
        } else {
            return Search(x.hijo[i],llave);
        }
    }

    /**
     * @param x posis x del arbol
     * @param pos posicion que se desea acceder
     * @param y posis y dela rbol
     */
    private void Split (Node x , int pos , Node y) {
        Node z = new Node();
        z.hoja = y.hoja;
        z.n = T - 1;
        for (int j = 0 ; j < T - 1 ; j++) {
            z.llave[j] = y.llave[j+T];
        }
        if (! y.hoja) {
            for (int j = 0 ; j < T ; j++) {
                z.hijo[j] = y.hijo[j+T];
            }
        }
        y.n = T-1;
        for (int j = x.n ; j >= pos+1 ; j--) {
            x.hijo[j+1] = x.hijo[j];
        }
        x.hijo[pos+1] = z;

        for (int j = x.n-1 ; j >= pos ; j--) {
            x.llave[j+1] = x.llave[j];
        }
        x.llave[pos] = y.llave[T-1];
        x.n = x.n + 1;
    }

    /**
     * Realiza el insert de los nodos deseados a partir de una llave
     * @param llave llave que determinara el insert
     */
    public void Insert (final int llave) {
        Node r = raiz;
        if (r.n == 2*T - 1 ) {
            Node s = new Node();
            raiz = s;
            s.hoja = false;
            s.n = 0;
            s.hijo[0] = r;
            Split(s,0,r);
            _Insert(s,llave);
        } else {
            _Insert(r,llave);
        }
    }
    final private void _Insert (Node x , int k) {
        if (x.hoja) {
            int i = 0;
            for (i = x.n - 1; i >= 0 && k < x.llave[i]; i--) {
                x.llave[i + 1] = x.llave[i];
            }
            x.llave[i + 1] = k;
            x.n = x.n + 1;
        } else {
            int i = 0;
            for (i = x.n - 1; i >= 0 && k < x.llave[i]; i--) {
            }
            ;
            i++;
            Node tmp = x.hijo[i];
            if (tmp.n == 2 * T - 1) {
                Split(x, i, tmp);
                if (k > x.llave[i]) {
                    i++;
                }
            }
            _Insert(x.hijo[i], k);
        }
    }

    /**
     * Borra el nodo seleccionado
     * @param x nodo que se seleccionara
     * @param llave llave que mantiene el orden del arbol
     */
    private void Delete (Node x , int llave) {
        int pos = x.Find(llave);
        if (pos != -1) {
            if (x.hoja) {
                int i = 0 ;
                for (i = 0 ; i < x.n && x.llave[i] != llave ; i++){};
                for ( ; i < x.n ; i++) {
                    if (i != 2*T - 2){
                        x.llave[i] = x.llave[i+1];
                    }
                }
                x.n--;
                return;
            }
            if (!x.hoja){
                //if (x.hijo[pos].n >= T){
                // Если это внутрений узел.

                // Случай 2а

                Node pred = x.hijo[pos];
                int predllave = 0;
                //System.out.println(pos);
                if (pred.n >= T) {
                    // Ищем предшественика
                    //System.out.println("2a");
                    for (;;) {
                        if (pred.hoja) {
                            System.out.println(pred.n);
                            predllave = pred.llave[pred.n - 1];
                            break;
                        } else {
                            pred = pred.hijo[pred.n];
                        }
                    }
                    // Удаляем предшественика
                    Delete (pred, predllave);
                    x.llave[pos] = predllave;
                    return;
                }
                Node nextNode = x.hijo[pos+1];
                if (nextNode.n >= T) {
                    int nextllave = nextNode.llave[0];
                    if (!nextNode.hoja){
                        nextNode = nextNode.hijo[0];
                        for (;;) {
                            if (nextNode.hoja) {
                                nextllave = nextNode.llave[nextNode.n-1];
                                break;
                            } else {
                                nextNode = nextNode.hijo[nextNode.n];
                            }
                        }
                    }
                    Delete(nextNode, nextllave);
                    x.llave[pos] = nextllave;
                    return;
                }
                int temp = pred.n + 1;
                pred.llave[pred.n++] = x.llave[pos];
                for (int i = 0, j = pred.n ; i < nextNode.n ; i++) {
                    pred.llave[j++] = nextNode.llave[i];
                    pred.n++;
                }
                for (int i = 0 ; i < nextNode.n+1 ; i++){
                    pred.hijo[temp++] = nextNode.hijo[i];
                }
                x.hijo[pos] = pred;
                // Смещаем ключи(удаляем ключ)
                for (int i = pos ; i < x.n ; i++) {
                    if (i != 2*T - 2) {
                        x.llave[i] = x.llave[i+1];
                    }
                }
                for (int i = pos+1 ; i < x.n+1 ; i++) {
                    if (i != 2*T - 1) {
                        x.hijo[i] = x.hijo[i+1];
                    }
                }
                x.n--;
                if (x.n == 0) {
                    if (x == raiz) {
                        raiz = x.hijo[0];
                    }
                    x = x.hijo[0];
                }
                Delete(pred,llave);
                return;
            }
        } else {
            for (pos = 0 ; pos < x.n ; pos++) {
                if (x.llave[pos] > llave) {
                    break;
                }
            }
            Node tmp = x.hijo[pos];
            if (tmp.n >= T) {
                Delete (tmp,llave);
                return;
            }
            if (true) {
                Node nb = null;// Hermano de la raiz del subarbol
                int divisor = -1;
                if (pos != x.n && x.hijo[pos+1].n >= T) {
                    divisor = x.llave[pos];
                    nb = x.hijo[pos+1];
                    x.llave[pos] = nb.llave[0];
                    tmp.llave[tmp.n++] = divisor;
                    tmp.hijo[tmp.n] = nb.hijo[0];
                    for (int i = 1 ; i < nb.n ; i++) {
                        nb.llave[i-1] = nb.llave[i];
                    }
                    for (int i = 1 ; i <= nb.n ; i++) {
                        nb.hijo[i-1] = nb.hijo[i];
                    }
                    nb.n--;
                    Delete(tmp,llave);
                    return;
                } else if (pos != 0 && x.hijo[pos-1].n >= T){
                    divisor = x.llave[pos-1];
                    nb = x.hijo[pos-1];
                    x.llave[pos-1] = nb.llave[nb.n-1];
                    Node hijo = nb.hijo[nb.n];
                    nb.n--;
                    // Se mueve a la derecha y acciona el separador
                    for(int i = tmp.n ; i > 0 ; i--) {
                        tmp.llave[i] = tmp.llave[i-1];
                    }
                    tmp.llave[0] = divisor;
                    for(int i = tmp.n + 1 ; i > 0 ; i--) {
                        tmp.hijo[i] = tmp.hijo[i-1];
                    }
                    tmp.hijo[0] = hijo;
                    tmp.n++;
                    Delete(tmp,llave);
                    return;
                } else {
                    // Caso en el que ambos contienen claves t-1
                    Node lt = null;
                    Node rt = null;
                    boolean last = false;
                    if (pos != x.n) {
                        divisor = x.llave[pos];
                        lt = x.hijo[pos]; // Seccion izquierda del divisor
                        rt = x.hijo[pos+1];
                    } else {
                        divisor = x.llave[pos-1];
                        rt = x.hijo[pos];
                        lt = x.hijo[pos-1];
                        last = true;
                        pos--;
                    }
                    //Elimina la Llave
                    for (int i = pos; i < x.n-1  ; i++){
                        x.llave[i] = x.llave[i+1];
                    }
                    for(int i = pos+1 ; i < x.n ; i++) {
                        x.hijo[i] = x.hijo[i+1];
                    }
                    x.n--;
                    lt.llave[lt.n++] = divisor;
                    int numhijo = 0;
                    for (int i = 0, j = lt.n; i < rt.n+1 ; i++,j++) {
                        if (i < rt.n) {
                            lt.llave[j] = rt.llave[i];
                        }
                        lt.hijo[j] = rt.hijo[i];
                    }
                    lt.n += rt.n;
                    if (x.n == 0) {
                        if (x == raiz) {
                            raiz = x.hijo[0];
                        }
                        x = x.hijo[0];
                    }
                    Delete(lt,llave);
                    return;
                }
            }
        }
    }
    public void Delete (int llave) {
        Node x = Search(raiz, llave);
        if (x == null) {
            return;
        }
        Delete(raiz,llave);
    }

    /**
     * Busca las llaves correspondientes segun el orden del arbol
     * @param a parametro de entrada para la busqueda de llaves
     * @param b parametro de entrada para la busqueda de llaves
     * @param x parametro de entrada para la busqueda de llaves
     * @param st lugar donde se posicionara la llave
     */
    private void Findllaves (int a, int b, Node x, Stack<Integer> st){
        int i = 0;
        for (i = 0 ; i < x.n && x.llave[i] < b; i++) {
            if ( x.llave[i] > a  ) {
                st.push(x.llave[i]);
            }
        }
        if (!x.hoja) {
            for (int j = 0 ; j < i+1 ; j++) {
                Findllaves(a,b,x.hijo[j],st);
            }
        }
    }
}