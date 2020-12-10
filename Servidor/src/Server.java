import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

import static java.lang.Thread.sleep;

public class Server implements Runnable{
    private Btree btree;
    private BTS bts;
    private SplayTree splay;
    private AVL avl;
    private ArrayList<Integer> L_avl;
    private ArrayList<Integer> L_bts;
    private ArrayList<Integer> L_btree;
    private ArrayList<Integer> L_splay;
    private int port;
    private ServerSocket Server;
    private Socket Client;
    private boolean ServerActive;
    private DataOutputStream OUT;
    private DataInputStream IN;
    private String InMessage;
    private String Ult_C;
    private String Ult_Cu;
    private String Ult_T;
    private String Ult_R;
    private DataInput I;
    private boolean BTS;
    private boolean B_Tree;
    private boolean AVL;
    private boolean Splay;
    private boolean Game_Active;
    private boolean C_circulo;
    private boolean C_cuadrado;
    private boolean C_rombo;
    private boolean C_triangulo;
    public Server(){
        this.L_avl = new ArrayList<Integer>();
        this.L_splay = new ArrayList<Integer>();
        this.L_btree = new ArrayList<Integer>();
        this.L_bts = new ArrayList<Integer>();
        this.avl = new AVL();
        this.btree = new Btree(2);
        this.bts = new BTS();
        this.splay = new SplayTree();
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
    public void SetC_cuadrado(boolean c_cuadrado){
        this.C_cuadrado = c_cuadrado;
    }
    public boolean GetC_cuadrado(){
        return this.C_cuadrado;
    }
    public void SetC_rombo(boolean c_rombo){
        this.C_rombo = c_rombo;
    }
    public boolean GetC_rombo(){
        return this.C_rombo;
    }
    public void SetC_triangulo(boolean c_triangulo){
        this.C_triangulo = c_triangulo;
    }
    public boolean GetC_triangulo(){
        return this.C_triangulo;
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
    public void setUlt_C(String ult_token) {
        Ult_C = ult_token;
    }
    public void setUlt_Cu(String ult_Cu) {
        Ult_Cu = ult_Cu;
    }
    public void setUlt_R(String ult_R) {
        Ult_R = ult_R;
    }
    public void setUlt_T(String ult_T) {
        Ult_T = ult_T;
    }
    public String getUlt_Cu() {
        return Ult_Cu;
    }
    public String getUlt_R() {
        return Ult_R;
    }
    public String getUlt_T() {
        return Ult_T;
    }
    public String getUlt_C() {
        return Ult_C;
    }
    public void DeleteTrees(String tree){
        int rango;
        if(tree == "Splay"){
            if(!splay.isEmpty()){
                rango = L_splay.size();
                for(int i = 0; i < rango; i++){
                    splay.remove(L_splay.get(i));
                }
                L_splay.clear();
                setUlt_T("T_11");
            }
        }
        if(tree == "Btree"){
            rango = L_btree.size();
            for(int i = 0; i < rango; i++){
                btree.Delete(L_btree.get(i));
            }
            L_btree.clear();
            setUlt_Cu("Cu_45");

        }
        if(tree == "BTS"){
            rango = L_bts.size();
            for(int i = 0; i < rango; i++){
                bts.Delete(L_bts.get(i));
            }
            L_bts.clear();
            setUlt_R("R_44");
        }
        if(tree == "AVL"){
            rango = L_avl.size();
            for(int i = 0; i < rango; i++){
                avl.eliminar(L_avl.get(i));
            }
            L_avl.clear();
            setUlt_C("C_15");
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
        Thread event_poderes = new Thread(this::Eventos_poderes);
        event_poderes.start();
        Thread event_arboles = new Thread(this::Eventos_arboles);
        event_arboles.start();
        Thread event_s = new Thread(this::Eventos_Secundarios);
        event_s.start();
        Thread event_circulo = new Thread(this::Eventos_Circulo);
        event_circulo.start();
        Thread event_cuadrado = new Thread(this::Eventos_Cuadrado);
        event_cuadrado.start();
        Thread event_rombo = new Thread(this::Eventos_Rombo);
        event_rombo.start();
        Thread event_triangulo = new Thread(this::Eventos_Triangulo);
        event_triangulo.start();
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
                    case "InActive":
                        setGame_Active(false);
                        break;
                    case "Active_C_circulo":
                        SetC_circulo(true);
                        setUlt_C("C_15");
                        break;
                    case "Active_C_cuadrado":
                        SetC_cuadrado(true);
                        setUlt_Cu("Cu_45");
                        break;
                    case "Active_C_rombo":
                        SetC_rombo(true);
                        setUlt_R("R_44");
                        break;
                    case "Active_C_triangulo":
                        SetC_triangulo(true);
                        setUlt_T("T_11");
                        break;
                    case "Completo_C":
                        SetC_circulo(false);
                        break;
                    case "Completo_Cu":
                        SetC_cuadrado(false);
                        break;
                    case "Completo_R":
                        SetC_rombo(false);
                        break;
                    case "Completo_T":
                        SetC_triangulo(false);
                        break;
                    case "Reiniciar_C":
                        DeleteTrees("AVL");
                        break;
                    case "Reiniciar_Cu":
                        DeleteTrees("Btree");
                        break;
                    case "Reiniciar_R":
                        DeleteTrees("BTS");
                        break;
                    case "Reiniciar_T":
                        DeleteTrees("Splay");
                        break;
                    case "C_15":
                        setUlt_C("C_6");
                        avl.insertar(15);
                        L_avl.add(15);
                        break;
                    case "C_6":
                        setUlt_C("C_50");
                        avl.insertar(6);
                        L_avl.add(6);
                        break;
                    case "C_50":
                        setUlt_C("C_4");
                        avl.insertar(50);
                        L_avl.add(50);
                        break;
                    case "C_4":
                        setUlt_C("C_7");
                        avl.insertar(4);
                        L_avl.add(4);
                        break;
                    case "C_7":
                        setUlt_C("C_23");
                        avl.insertar(7);
                        L_avl.add(7);
                        break;
                    case "C_23":
                        setUlt_C("C_71");
                        avl.insertar(23);
                        L_avl.add(23);
                        break;
                    case "C_71":
                        setUlt_C("C_5");
                        avl.insertar(71);
                        L_avl.add(71);
                        break;
                    case "C_5":
                        avl.insertar(5);
                        L_avl.add(5);
                        //setUlt_C("C_15");
                        break;
                    case "T_11":
                        setUlt_T("T_12");
                        splay.insert(11);
                        L_splay.add(11);
                        break;
                    case "T_12":
                        setUlt_T("T_55");
                        splay.insert(12);
                        L_splay.add(12);
                        break;
                    case "T_55":
                        setUlt_T("T_59");
                        splay.insert(55);
                        L_splay.add(55);
                        break;
                    case "T_59":
                        setUlt_T("T_44");
                        splay.insert(59);
                        L_splay.add(59);
                        break;
                    case "T_44":
                        setUlt_T("T_70");
                        splay.insert(44);
                        L_splay.add(44);
                        break;
                    case "T_70":
                        setUlt_T("T_15");
                        splay.insert(70);
                        L_splay.add(70);
                        break;
                    case "T_15":
                        //setUlt_T("T_11");
                        splay.insert(15);
                        L_splay.add(15);
                        break;
                    case "Cu_45":
                        setUlt_Cu("Cu_23");
                        btree.Insert(45);
                        L_btree.add(45);
                        break;
                    case "Cu_23":
                        setUlt_Cu("Cu_58");
                        btree.Insert(23);
                        L_btree.add(23);
                        break;
                    case "Cu_58":
                        setUlt_Cu("Cu_71");
                        btree.Insert(58);
                        L_btree.add(58);
                        break;
                    case "Cu_71":
                        setUlt_Cu("Cu_44");
                        btree.Insert(71);
                        L_btree.add(71);
                        break;
                    case "Cu_44":
                        setUlt_Cu("Cu_55");
                        btree.Insert(44);
                        L_btree.add(44);
                        break;
                    case "Cu_55":
                        setUlt_Cu("Cu_77");
                        btree.Insert(55);
                        L_btree.add(55);
                        break;
                    case "Cu_77":
                        btree.Insert(77);
                        L_btree.add(77);
                        //setUlt_Cu("Cu_45");
                        break;
                    case "R_44":
                        setUlt_R("R_36");
                        bts.insert(44);
                        L_bts.add(44);
                        break;
                    case "R_36":
                        setUlt_R("R_69");
                        bts.insert(36);
                        L_bts.add(36);
                        break;
                    case "R_69":
                        setUlt_R("R_34");
                        bts.insert(69);
                        L_bts.add(69);
                        break;
                    case "R_34":
                        setUlt_R("R_38");
                        bts.insert(34);
                        L_bts.add(34);
                        break;
                    case "R_38":
                        setUlt_R("R_50");
                        bts.insert(38);
                        L_bts.add(38);
                        break;
                    case "R_50":
                        setUlt_R("R_91");
                        bts.insert(50);
                        L_bts.add(50);
                        break;
                    case "R_91":
                        setUlt_R("R_39");
                        bts.insert(91);
                        L_bts.add(91);
                        break;
                    case "R_39":
                        bts.insert(39);
                        L_bts.add(39);
                        //setUlt_R("R_44");
                        break;
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
    public void Eventos_poderes(){
        while(true){
            System.out.println(GetGame_Active());
            System.out.println(GetC_circulo());
            if(GetGame_Active()) {
                int a = (int) (Math.random()*3 +1);
                try {
                    sleep(12000);
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
                }
            }
        }
    }
    public void Eventos_arboles(){
        while(true){
            System.out.println(GetGame_Active());
            System.out.println(GetC_circulo());
            if(GetGame_Active()) {
                int a = (int) (Math.random()*4 +1);
                try {
                    sleep(12000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                System.out.println(a);
                switch (a){
                    case 1:
                        if (!GetC_rombo()) {
                            SendMessage("c_bts");
                            break;
                        }
                        break;
                    case 2:
                        if(!GetC_circulo()){
                            SendMessage("c_avl");
                            break;
                        }
                        break;
                    case 3:
                        if(!GetC_cuadrado()){
                            SendMessage("c_btree");
                            break;
                        }
                        break;
                    case 4:
                        if (!GetC_triangulo()){
                            SendMessage("c_splay");
                            break;
                        }
                        break;
                }
            }
        }
    }
    public void Eventos_Circulo(){
        while(true){
            System.out.println(GetGame_Active());
            System.out.println(GetC_circulo());
            try {
                sleep(12000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            if(GetC_circulo() && GetGame_Active()) {
                for(int i = 1; i<=8; i++){
                    System.out.println(i);
                    switch (i){
                        case 1:
                            if(GetC_circulo() && getUlt_C() == "C_15"){
                                SendMessage("C_15");
                            }
                            break;
                        case 2:
                            if(GetC_circulo() && getUlt_C() == "C_6"){
                                SendMessage("C_6");
                            }
                            break;
                        case 3:
                            if(GetC_circulo() && getUlt_C() == "C_7"){
                                SendMessage("C_7");
                            }
                            break;
                        case 4:
                            if(GetC_circulo() && getUlt_C() == "C_4"){
                                SendMessage("C_4");
                            }
                            break;
                        case 5:
                            if(GetC_circulo()  && getUlt_C() == "C_5"){
                                SendMessage("C_5");
                            }
                            break;
                        case 6:
                            if(GetC_circulo() && getUlt_C() == "C_23"){
                                SendMessage("C_23");
                            }
                            break;
                        case 7:
                            if(GetC_circulo() && getUlt_C() == "C_50"){
                                SendMessage("C_50");
                            }
                            break;
                        case 8:
                            if(GetC_circulo()  && getUlt_C() == "C_71"){
                                SendMessage("C_71");
                            }
                            break;
                    }
                }
            }
        }
    }
    public void Eventos_Cuadrado(){
        while(true){
            System.out.println(GetGame_Active());
            System.out.println(GetC_cuadrado());
            try {
                sleep(12000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            if(GetC_cuadrado() && GetGame_Active()) {
                for(int i = 1; i<=8; i++){
                    System.out.println(i);
                    switch (i){
                        case 1:
                            if(GetC_cuadrado() && getUlt_Cu() == "Cu_21"){
                                SendMessage("Cu_21");
                            }
                            break;
                        case 2:
                            if(GetC_cuadrado() && getUlt_Cu() == "Cu_23"){
                                SendMessage("Cu_23");
                            }
                            break;
                        case 3:
                            if(GetC_cuadrado() && getUlt_Cu() == "Cu_44"){
                                SendMessage("Cu_44");
                            }
                            break;
                        case 4:
                            if(GetC_cuadrado() && getUlt_Cu() == "Cu_45"){
                                SendMessage("Cu_45");
                            }
                            break;
                        case 5:
                            if(GetC_cuadrado() && getUlt_Cu() == "Cu_55"){
                                SendMessage("Cu_55");
                            }
                            break;
                        case 6:
                            if(GetC_cuadrado() && getUlt_Cu() == "Cu_58"){
                                SendMessage("Cu_58");
                            }
                            break;
                        case 7:
                            if(GetC_cuadrado() && getUlt_Cu() == "Cu_77"){
                                SendMessage("Cu_77");
                            }
                            break;

                    }
                }

            }
        }
    }
    public void Eventos_Rombo(){
        while(true){
            System.out.println(GetGame_Active());
            System.out.println(GetC_cuadrado());
            try {
                sleep(12000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            if(GetC_rombo() && GetGame_Active()) {
                for(int i = 1; i<=8; i++){
                    System.out.println(i);
                    switch (i){
                        case 1:
                            if(GetC_rombo() && getUlt_R() == "R_34"){
                                SendMessage("R_34");
                            }
                            break;
                        case 2:
                            if(GetC_rombo() && getUlt_R() == "R_36"){
                                SendMessage("R_36");
                            }
                            break;
                        case 3:
                            if(GetC_rombo() && getUlt_R() == "R_38"){
                                SendMessage("R_38");
                            }
                            break;
                        case 4:
                            if(GetC_rombo() && getUlt_R() == "R_39"){
                                SendMessage("R_39");
                            }
                            break;
                        case 5:
                            if(GetC_rombo() && getUlt_R() == "R_44"){
                                SendMessage("R_44");
                            }
                            break;
                        case 6:
                            if(GetC_rombo() && getUlt_R() == "R_50"){
                                SendMessage("R_50");
                            }
                            break;
                        case 7:
                            if(GetC_rombo() && getUlt_R() == "R_69"){
                                SendMessage("R_69");
                            }
                            break;
                        case 8:
                            if(GetC_rombo() && getUlt_R() == "R_91"){
                                SendMessage("R_91");
                            }
                            break;
                    }
                }

            }
        }
    }
    public void Eventos_Triangulo(){
        while(true){
            System.out.println(GetGame_Active());
            System.out.println(GetC_cuadrado());
            try {
                sleep(12000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            if(GetC_triangulo() && GetGame_Active()) {
                for(int i = 1; i<=7; i++){
                    System.out.println(i);
                    switch (i){
                        case 1:
                            if(GetC_triangulo() && getUlt_T() == "T_11"){
                                SendMessage("T_11");
                            }
                            break;
                        case 2:
                            if(GetC_triangulo() && getUlt_T() == "T_12"){
                                SendMessage("T_12");
                            }
                            break;
                        case 3:
                            if(GetC_triangulo() && getUlt_T() == "T_15"){
                                SendMessage("T_15");
                            }
                            break;
                        case 4:
                            if(GetC_triangulo() && getUlt_T() == "T_44"){
                                SendMessage("T_44");
                            }
                            break;
                        case 5:
                            if(GetC_triangulo() && getUlt_T() == "T_55"){
                                SendMessage("T_55");
                            }
                            break;
                        case 6:
                            if(GetC_triangulo() && getUlt_T() == "T_59"){
                                SendMessage("T_59");
                            }
                            break;
                        case 7:
                            if(GetC_triangulo() && getUlt_T() == "T_70"){
                                SendMessage("T_70");
                            }
                            break;
                    }
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