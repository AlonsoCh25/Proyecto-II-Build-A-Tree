public class Main {
    public static void main(String[] args) {
	//Server server = new Server();
	//Thread s = new Thread(server);
	//s.start();
        Splay splay = new Splay();

        splay.insert(5,1);
        splay.insert(4,2);
        splay.insert(3,3);
        splay.insert(6,5);
        splay.search(splay.root);

       /* BTS bts = new BTS();
        System.out.println(bts.isEmpty());
		bts.insert(2);
		bts.insert(3);
		bts.insert(1);
		bts.insert(4);
        System.out.println(bts.isEmpty());
        System.out.println(bts.FindMin().getData());
        System.out.println(bts.FindMax().getData());*/
    }
}
