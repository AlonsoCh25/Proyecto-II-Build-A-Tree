import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;

public class Server implements Runnable{
    private int port;
    private ServerSocket Server;
    private Socket Client;
    private boolean ServerActive;
    private DataOutputStream OUT;
    private DataInputStream IN;
    private String InMessage;
    private DataInput I;
    public Server(){
        this.port = 1000;
        this.Server = null;
        this.Client = null;
        this.ServerActive = true;
    }

    public void setServerActive(boolean active){this.ServerActive = active;}
    public boolean isServerActive(){return this.ServerActive;}
    public Socket getClient(){return this.Client;}
    public ServerSocket getServer(){return this.Server;}
    public int getPort(){return this.port;}
    public void setPort(int port){this.port = port;}

    public void increasePort(){
        int port = getPort();
        setPort(port++);
    }
    public void SendMessage(String OutMessage){
        try{
            OUT = new DataOutputStream(this.Client.getOutputStream());
            OUT.writeUTF(OutMessage);
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    public void setInMessage(String inMessage) {
        this.InMessage = inMessage;
    }
    public String parseByte(byte[] b){
        String s = new String(b, StandardCharsets.UTF_8);
        return s;
    }
    public String getInMessage() {
        return InMessage;
    }
    public void run() {
        while(this.Server == null){
            try{
                this.Server = new ServerSocket(getPort());
                System.out.println("Servidor creado " + this.Server);
            } catch (Exception e) {
                System.out.println(e);
                increasePort();
            }
        }
        while (this.Client == null){
            try{
                this.Client = this.Server.accept();
                System.out.println("Cliente conectado");

            } catch (IOException e) {
                System.out.println(e);
            }
        }
        while (isServerActive()){
            try{
                System.out.println("TRY");
                IN = new DataInputStream(this.Client.getInputStream());
                int length = 100;
                System.out.println("RECIBE MENSAJE");
                if(length>0){
                    System.out.println("1");
                    byte[] message = new byte[length];
                    IN.read(message);
                    System.out.println("2");
                    String m = parseByte(message);
                    System.out.println(m);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
}