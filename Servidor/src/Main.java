public class Main {

    public static void main(String[] args) {
	Server server = new Server();
	Thread s = new Thread(server);
	s.start();
		while(true){
			if (server.getInMessage() != null){
				System.out.println(server.getInMessage());
			}server.setInMessage(null);
		}
    }
}
