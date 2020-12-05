import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;
import static java.lang.Thread.sleep;

public class Server implements Runnable{
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
    private boolean C_circulo;
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
    public void setServerActive(boolean active){this.ServerActive = active;}
    public boolean isServerActive(){return this.ServerActive;}
    public Socket getClient(){return this.Client;}
    public ServerSocket getServer(){return this.Server;}
    public int getPort(){return this.port;}
    public void setPort(int port){this.port = port;}
    public void SetC_circulo(boolean c_circulo){
        this.C_circulo = c_circulo;
    }
    public boolean GetC_circulo(){
        return this.C_circulo;
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
    public void setGame_Active(boolean game_Active) {
        this.Game_Active = game_Active;
    }
    public void increasePort(){
        int port = getPort();
        setPort(port++);
    }
    public void SendMessage(String OutMessage){
        try{
            OUT = new DataOutputStream(this.Client.getOutputStream());
            OUT.write(OutMessage.getBytes());
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

        Thread event = new Thread(this::Eventos);
        event.start();
        Thread event_s = new Thread(this::Eventos_Secundarios);
        event_s.start();
        while (true){
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
                        break;
                    case "Active_C_circulo":
                        SetC_circulo(true);
                        break;
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
    public void Eventos(){
        while(true){
            System.out.println(GetGame_Active());
            System.out.println(GetC_circulo());
            if(GetGame_Active()) {
                int a = (int) (Math.random()*13 +1);
                try {
                    sleep(3000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                System.out.println(a);
                switch (a){
                    case 1:
                        SendMessage("force_push");
                        break;
                    case 2:
                        SendMessage("shield");
                        break;
                    case 3:
                        SendMessage("air-jump");
                        break;
                    case 4:
                        SendMessage("c_bts");
                        break;
                    case 5:
                        if(!GetC_circulo()){
                            SendMessage("c_avl");
                        }
                        break;
                    case 6:
                        if(GetC_circulo()){
                            SendMessage("C_15");
                        }
                        break;
                    case 7:
                        if(GetC_circulo()){
                            SendMessage("C_6");
                        }
                        break;
                    case 8:
                        if(GetC_circulo()){
                            SendMessage("C_7");
                        }
                        break;
                    case 9:
                        if(GetC_circulo()){
                            SendMessage("C_4");
                        }
                        break;
                    case 10:
                        if(GetC_circulo()){
                            SendMessage("C_5");
                        }
                        break;
                    case 11:
                        if(GetC_circulo()){
                            SendMessage("C_23");
                        }
                        break;
                    case 12:
                        if(GetC_circulo()){
                            SendMessage("C_50");
                        }
                        break;
                    case 13:
                        if(GetC_circulo()){
                            SendMessage("C_71");
                        }
                        break;
                }
            }
        }
    }
    public void Eventos_Secundarios(){
        while (isServerActive()){
            if (GetGame_Active()){
                if(GetBTS()){
                    int b = (int) (Math.random()*4 +1);
                    try {
                        sleep(1000);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    switch (b){
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
                if(GetAVL()){
                    int c = (int) (Math.random()*4 +1);
                    try {
                        sleep(1000);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    switch (c){
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
                if(GetB_Tree()){
                    int d = (int) (Math.random()*4 +1);
                    try {
                        sleep(1000);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    switch (d){
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
                if(GetSPLAY()){
                    int f = (int) (Math.random()*4 +1);
                    try {
                        sleep(1000);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    switch (f){
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
            }
        }

    }
}