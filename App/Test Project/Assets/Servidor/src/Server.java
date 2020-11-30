import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;
import static java.lang.Thread.sleep;

public class Server implements Runnable{
    //Variables 
    private int port;
    private ServerSocket Server;
    private Socket Client;
    private boolean ServerActive;
    private DataOutputStream OUT;
    private DataInputStream IN;
    private String InMessage;
    private DataInput I;
    private boolean BTS;
    private boolean B_Tree;
    private boolean AVL;
    private boolean Splay;
    private boolean Game_Active;

    //Setters
    public void setServerActive(boolean active){this.ServerActive = active;}
    public void setInMessage(String inMessage) {
        this.InMessage = inMessage;
    }
    public void setPort(int port){this.port = port;}
    public void setGame_Active(boolean game_Active) {
        Game_Active = game_Active;
    }

    //Getters
    public String getInMessage() {
        return InMessage;
    }
    public boolean GetBTS(){
        return this.BTS;
    }
    public boolean GetAVL(){
        return this.AVL;
    }
    public boolean GetB_Tree(){
        return this.B_Tree;
    }
    public boolean GetSPLAY(){
        return this.Splay;
    }
    public boolean GetGame_Active(){
        return this.Game_Active;
    }
    public Socket getClient(){return this.Client;}
    public ServerSocket getServer(){return this.Server;}
    public int getPort(){return this.port;}
    public boolean isServerActive(){return this.ServerActive;}
    public String parseByte(byte[] b){
        String s = new String(b, StandardCharsets.UTF_8);
        return s;
    }
    public String ParseString(String S) {
        String Clean = "\u0000";
        StringBuilder sb = new StringBuilder();
        char[] C = Clean.toCharArray();
        char[] chart = S.toCharArray();
        for (int i = 0; i < chart.length; i += 1){
            if(chart[i] != C[0]){
                sb.append(chart[i]);
            }
        }
        return sb.toString();
    }

    //Voids
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
    public Server(){
        this.port = 1000;
        this.Server = null;
        this.Client = null;
        this.ServerActive = true;
        this.BTS = false;
        this.B_Tree = false;
        this.AVL = false;
        this.Splay = false;
        this.Game_Active = false;
    }
    public void Eventos(){
        while(isServerActive()){
            if(GetGame_Active()){
                int a = (int) (Math.random()*4 +1);
                try {
                    sleep(5000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                switch (a){
                    case 1:
                        SendMessage("Force_Push");
                    case 2:
                        SendMessage("Shield");
                    case 3:
                        SendMessage("Air-Jump");
                    case 4:
                        SendMessage("C_BTS");
                }
            }
        }
    }
    public void Eventos_Secundarios(){
        while (isServerActive()){
            if (GetGame_Active()){
                if(GetBTS()){

                }
                if(GetAVL()){

                }
                if(GetB_Tree()){

                }
                if(GetSPLAY()){

                }
            }
        }
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
            } catch (IOException e) {
                System.out.println(e);
            }
        }
        while (isServerActive()){
            Thread event = new Thread(this::Eventos);
            event.start();
            Thread event_s = new Thread(this::Eventos_Secundarios);
            event_s.start();
            try{
                IN = new DataInputStream(this.Client.getInputStream());
                int length = 100; //Largo maximo del mensaje
                byte[] message = new byte[length];
                IN.read(message);
                String m = ParseString(parseByte(message));
                switch (m){
                    //CASOS DE LOS MENSAJES QUE RECIBE
                    case "Active":
                        setGame_Active(true);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

}