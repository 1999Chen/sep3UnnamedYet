package SocketServer;

import APICommunication.APICommunication;
import com.google.gson.Gson;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import shared.Request;
import shared.RequestTypes;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

public class ServerThread extends Thread
{
    private Socket socket;
    private String clientUsername;
    private Gson gson;
    public ServerThread(Socket socket)
    {
        this.socket = socket;
    }

    public void InitializeServer()
    {
        try
        {
            System.out.println("server initialized");
            String json = "";

            InputStream in = socket.getInputStream();
            OutputStream out = socket.getOutputStream();

            int count;
            byte[] bytes = new byte[100];
            String token = "";
            while (true)
            {
                while ((count = in.read(bytes)) != 0)
                {
                    json += new String(bytes, 0, count);
                    if (json.contains(";"))
                    {
                        json.replace(";", "");
                        break;
                    }
                }
                JSONObject jsonObject = new JSONObject(json);
                Request request = new Request(jsonObject.getString("Type"), jsonObject.getJSONObject("Args"));//getting request type and arguments for it

                switch (request.getType()){
                    case "REGISTER" :
                        JSONObject responseCode = APICommunication.Register(request.getArgs());
                        out.write(responseCode.toString().getBytes());
                        json = "";

                    case "LOGIN" :
                        System.out.println("LOGIN CASE");
                        System.out.println(request.getArgs().getString("username"));
                        JSONObject response1 =  APICommunication.Login(request.getArgs().getString("username"), request.getArgs().getString("password"));
                        out.write(response1.toString().getBytes());

                    case "LOGINSUCCEDD":
                        ClientManager.getInstance().addClient(request.getArgs().getString("username"),socket);

                    case "EDITINFO":

                        String username=request.getArgs().getString("username");
                        JSONObject data=request.getArgs();
                        JSONObject response3=APICommunication.editUser(username,data);
                        out.write(response3.toString().getBytes());


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


                    case "GETUSERINFO":
                        JSONObject arguments = request.getArgs();
                        String name = arguments.getString("username");
                        JSONObject responseFromAPI = APICommunication.getUserInfo(name);
                        out.write(responseFromAPI.toString().getBytes());
                        json = "";

//                    case:
//
//
//                    case:
//
//
//                    case:
//
//
//                    case:




                }
                /**Register*/
//                if (request.getType().equals(RequestTypes.REGISTER.toString()))
//                {
//                    JSONObject responseCode = APICommunication.Register(request.getArgs());
//                    out.write(responseCode.toString().getBytes());
//                    json = "";
//                }
//                /**LOGIN*/
//                else if (request.getType().equals(RequestTypes.LOGIN.toString()))
//                {
//
//                    JSONObject arguments = request.getArgs();
//                    JSONObject responseFromAPILogin = APICommunication.Login(arguments.getString("username"), arguments.getString("password"));
//                    if (!(responseFromAPILogin.toString().equals("{\"message\":\"Username or password is incorrect\"}")))
//                    {
//                        try
//                        {
//                            System.out.println(responseFromAPILogin.toString());
//                            token = responseFromAPILogin.getString("Token");
//                            out.write(responseFromAPILogin.toString().getBytes());
//                            clientUsername = arguments.getString("username");
//                            ClientManager.getInstance().addClient(clientUsername,socket);
//                            json = "";
//                        } catch (JSONException e)
//                        {
//                            System.out.println(e.getMessage());
//                            out.write("{\"message\":\"Username or password is incorrect\"}".getBytes());
//                        } catch (IOException e)
//                        {
//                            e.printStackTrace();
//
//                        }
//
//                    } else
//                    {
//                        out.write(responseFromAPILogin.toString().getBytes());
//                        json = "";
//                    }
//
//                }
//
//                /**SEARCHUSERS*/
//                else if (request.getType().equals(RequestTypes.SEARCHUSERS.toString()))
//                {
//                    String firstname = request.getArgs().getString("firstname");
//                    String lastname = request.getArgs().getString("lastname");
//                    String sex = request.getArgs().getString("sex");
//                    String major = request.getArgs().getString("major");
//                    String hometown = request.getArgs().getString("hometown");
//                    Integer maxage = request.getArgs().getInt("maxage");
//                    Integer minage = request.getArgs().getInt("minage");
//                    String hobbies = request.getArgs().getString("hobbies");
//                    JSONArray jsonArray= APICommunication.searchUsers(firstname,lastname,sex,major,hometown
//                            ,maxage,minage,hobbies);
//                    out.write(jsonArray.toString().getBytes());
//
//                }
//
//
//                /**EDITUSERINFO*/
//                else if (request.getType().equals(RequestTypes.EDITINFO.toString()))
//                {
//                    String username=request.getArgs().getString("username");
//                    JSONObject data=request.getArgs();
//                    JSONObject response3=APICommunication.editUser(username,data);
//                    out.write(response3.toString().getBytes());
//                }
//                /**LIKE*/
//
//                else if (request.getType().equals(RequestTypes.GETMESSAGES.toString()))
//                {
//
//                    JSONArray responseFromAPI = APICommunication.getMessages(request.getArgs(),token);
//                    out.write(responseFromAPI.toString().getBytes());
//                    json = "";
//                } else if (request.getType().equals(RequestTypes.SENDMESSAGE.toString()))
//                {
//                    JSONObject responseFromAPI = APICommunication.sendMessage(request.getArgs(),token);
//                    out.write(responseFromAPI.toString().getBytes());
//                    json = "";
//                }else if (request.getType().equals(RequestTypes.SENDFRIENDREQUEST.toString()))
//                {
//                    JSONObject responseFromAPI = APICommunication.sendFriendRequest(request.getArgs(),token);
//                    out.write(responseFromAPI.toString().getBytes());
//                    json = "";
//                }else if (request.getType().equals(RequestTypes.ACCEPTFRIEND.toString()))
//                {
//                    JSONObject arguments = request.getArgs();
//                    Boolean accept = arguments.getBoolean("accept");
//                    JSONObject responseFromAPI = APICommunication.acceptFriendRequest(accept,token);
//                    out.write(responseFromAPI.toString().getBytes());
//                    json = "";
//                }else if (request.getType().equals(RequestTypes.DELETEFRIEND.toString()))
//                {
//                    JSONObject arguments = request.getArgs();
//                    String username = arguments.getString("username");
//                    JSONObject responseFromAPI = APICommunication.deleteFriendRequest(username,token);
//                    out.write(responseFromAPI.toString().getBytes());
//                    json = "";
//                }else if (request.getType().equals(RequestTypes.GETALLFRIENDS.toString()))
//                {
//                    JSONObject arguments = request.getArgs();
//                    String username = arguments.getString("username");
//                    JSONArray responseFromAPI = APICommunication.getAllFriendRequest(username,token);
//                    out.write(responseFromAPI.toString().getBytes());
//                    json = "";
//                }
//
//
//                /**CLOSES THE CONNECTIONS AND EXITS THE THREAD*/
//                else if (request.getType().equals(RequestTypes.LOGOUT.toString()))
//                {
//                    ClientManager.getInstance().removeClient(clientUsername);
//                    System.out.println("LOGOUT");
//                    break;
//                }

            }

        } catch (IOException e)
        {
            ClientManager.getInstance().removeClient(clientUsername);
            System.out.println(e.getMessage());
        }

    }


    public void run()
    {
        InitializeServer();
    }

}
