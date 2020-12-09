public class Main {
    public static void main(String[] args) {
	//Server server = new Server();
	//Thread s = new Thread(server);
	//s.start();
		BTS bts = new BTS();
        Btree btree = new Btree(2);
        btree.Insert(3);
        btree.Insert(4);
        btree.Insert(7);
        btree.Insert(9);
        btree.Show();
        System.out.println("________________");
        btree.Remove(4);
        btree.Remove(3);
        btree.Remove(7);
        btree.Remove(9);
        btree.Show();
        System.out.println("________________");
        btree.Insert(3);
        btree.Insert(4);
        btree.Insert(7);
        btree.Insert(9);
        btree.Show();

    }
}
