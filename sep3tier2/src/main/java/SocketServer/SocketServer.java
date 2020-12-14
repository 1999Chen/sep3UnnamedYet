package SocketServer;

import Model.ChatMessage;
import Model.User;
import com.google.gson.Gson;
import org.json.JSONArray;
import org.json.JSONObject;
import shared.Request;
import APICommunication.APICommunication;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;


public class SocketServer implements Runnable {


    public SocketServer() {
    }

    public void conntectStart() {

        try {

            ArrayList<Socket> socketArrayList = new ArrayList<>();
            HashMap<String, Socket> loginclients = new HashMap<>();
            ServerSocket serverSocket = new ServerSocket(8500);
            System.out.println("server creates connection succedds");
            while (true) {

                new Thread(() -> { // Lambda Expression

                    try {

                        Socket socket = serverSocket.accept();

                        System.out.println("connect to client succedds");
                        socketArrayList.add(socket);

                        InputStream in = socket.getInputStream();
                        OutputStream out = socket.getOutputStream();


                        byte[] bytes = new byte[1024];
                        int len = 0;
                        len = in.read(bytes);

                        String a = new String(bytes, 0, len);
                        System.out.println(a);

                        Gson gson = new Gson();

                        Request request = gson.fromJson(a, Request.class);

//                       User[] users = gson.fromJson(a, User[].class);
//            System.out.println(user.getName()+ " and age is "+user.getAge());

                        System.out.println(request.getType());
                        switch (request.getType()) {

                            case "LOGIN":
//                                User user= new User();
//                                user.setName(request.getArgs().getString("name"));
//                                user.setPassword(request.getArgs().getString("password"));
//
                                JSONObject response1 =  APICommunication.Login(request.getArgs().getString("username"), request.getArgs().getString("password"));
                                out.write(response1.toString().getBytes());


                            case "REGISTER":
                                 JSONObject response2 = APICommunication.Register(request.getArgs()) ;

                            case "LOGINSUCCEDD":
                                loginclients.put(request.getArgs().getString("username"), socket);

                            case "EDITINFO":
                                String username=request.getArgs().getString("username");
                                JSONObject data=request.getArgs();
                                JSONObject response3=APICommunication.editUser(username,data);
                                out.write(response3.toString().getBytes());

                            case "SENDMESSAGE":
                                String nameRecv = request.getArgs().getString("nameRecv");
                                ChatMessage chatMessage=gson.fromJson(request.getArgs().toString(),ChatMessage.class);
                                if (loginclients.containsKey(nameRecv)) {
                                    chatMessage.setOnline(true);
                                    APICommunication.storeMessage(chatMessage);
                                    OutputStream outToOther = loginclients.get(nameRecv).getOutputStream();
                                    outToOther.write(request.getArgs().toString().getBytes());
                                }
                                else {
                                    chatMessage.setOnline(false);
                                    APICommunication.storeMessage(chatMessage);
                                }


                            case "LOGOUT":
                                String name = request.getArgs().getString("username");
                                loginclients.remove(name);
                                break;

                            case "SENDFRIENDREQUEST":

                                




                            case "GETALLUSERS":




                            case "SEARCHUSERS":
                                String firstname = request.getArgs().getString("firstname");
                                String lastname = request.getArgs().getString("lastname");
                                String sex = request.getArgs().getString("sex");
                                String major = request.getArgs().getString("major");
                                String hometown = request.getArgs().getString("hometown");
                                Integer maxage = request.getArgs().getInt("maxage");
                                Integer minage = request.getArgs().getInt("minage");
                                String hobbies = request.getArgs().getString("hobbies");
                                JSONArray jsonArray= APICommunication.searchUsers(firstname,lastname,sex,major,hometown
                                ,maxage,minage,hobbies);
                                out.write(jsonArray.toString().getBytes());


                        }

//                        String toSend = "okkkkkk";
//                        byte[] toSendBytes = toSend.getBytes();
//                        int toSendLen = toSendBytes.length;
//                        byte[] toSendLenBytes = new byte[4];
//                        toSendLenBytes[0] = (byte) (toSendLen & 0xff);
//                        toSendLenBytes[1] = (byte) ((toSendLen >> 8) & 0xff);
//                        toSendLenBytes[2] = (byte) ((toSendLen >> 16) & 0xff);
//                        toSendLenBytes[3] = (byte) ((toSendLen >> 24) & 0xff);
//
//                        out.write(toSendLenBytes);
//
//                        out.write(toSendBytes);


                    } catch (IOException e) {
                        e.printStackTrace();
                    }

                }
                ).start();
            }


        } catch (IOException ioException) {
            ioException.printStackTrace();
        }

    }

    @Override
    public void run()
    {
        conntectStart();
    }

}





