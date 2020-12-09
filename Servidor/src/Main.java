public class Main {
    public static void main(String[] args) {
	//Server server = new Server();
	//Thread s = new Thread(server);
	//s.start();
		BTS bts = new BTS();
        System.out.println(bts.isEmpty());
		bts.insert(2);
		bts.insert(3);
		bts.insert(1);
		bts.insert(4);
        System.out.println(bts.isEmpty());
        System.out.println(bts.FindMin().getData());
        System.out.println(bts.FindMax().getData());
        bts.Delete(4);
        bts.Delete(1);
        bts.Delete(3);
        bts.Delete(2);
        System.out.println(bts.isEmpty());
    }
}
