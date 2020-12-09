public class Main {
    public static void main(String[] args) {
	Server server = new Server();
	Thread s = new Thread(server);
	s.start();
    }
}
