package APICommunication;

import Model.ChatMessage;
import Model.User;
import com.google.gson.Gson;
import org.apache.http.HttpResponse;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.*;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.json.JSONArray;
import org.json.JSONObject;

import javax.net.ssl.*;
import java.io.*;
import java.lang.management.GarbageCollectorMXBean;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;
import java.security.cert.X509Certificate;

public final class APICommunication
{
    private static CloseableHttpClient client = HttpClients.createDefault();
    private static HttpPost httpPost;
    private static HttpGet httpGet;
    private static HttpPut httpPut;
    private static HttpDelete httpDelete;
    private static Gson gson=new Gson();


    private static void trustAllHosts() {
        // Create a trust manager that does not validate certificate chains
        TrustManager[] trustAllCerts = new TrustManager[] { new X509TrustManager() {
            public java.security.cert.X509Certificate[] getAcceptedIssuers() {
                return new java.security.cert.X509Certificate[] {};
            }

            public void checkClientTrusted(X509Certificate[] chain, String authType) {
            }

            public void checkServerTrusted(X509Certificate[] chain, String authType) {
            }
        } };
        // Install the all-trusting trust manager
        try {
            SSLContext sc = SSLContext.getInstance("TLS");
            sc.init(null, trustAllCerts, new java.security.SecureRandom());
            HttpsURLConnection.setDefaultSSLSocketFactory(sc.getSocketFactory());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private final static HostnameVerifier DO_NOT_VERIFY = new HostnameVerifier() {
        public boolean verify(String hostname, SSLSession session) {
            return true;
        }
    };




    public static synchronized JSONObject Login(String username, String password) throws IOException {
        String responseBody = null;
        System.out.println("loging tier2 API");
         trustAllHosts();
        httpPost = new HttpPost("https://localhost:500/users/Login");

        String json = "{\"username\": \"" + username + "\",\"password\": \"" + password + "\"}";
        StringEntity entity = null;
        try
        {
            entity = new StringEntity(json);

        } catch (UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }
        httpPost.setEntity(entity);
        httpPost.setHeader("Accept", "application/json");
        httpPost.setHeader("Content-type", "application/json");
        CloseableHttpResponse response = null;
        try
        {
            response = client.execute(httpPost);
            responseBody = new String(response.getEntity().getContent().readAllBytes());
        } catch (IOException e)
        {
            e.getMessage();
        }
        if (responseBody == null)
        {
            return new JSONObject("{\"ResponseCode\": \"Can't connect to T3 \"}");
        } else
        {
            return new JSONObject("{\"ResponseCode\": \"connect to T3 \"}");
//            return new JSONObject(responseBody);
        }
    }




    public static synchronized JSONObject Register(JSONObject user)
    {

        httpPost = new HttpPost("https://localhost:5000/users");
        String json = gson.toJson(user);
        StringEntity entity = null;
        try
        {
            entity = new StringEntity(json);

        } catch (UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }
        httpPost.setEntity(entity);
        httpPost.setHeader("Accept", "application/json");
        httpPost.setHeader("Content-type", "application/json");
        CloseableHttpResponse response = null;
        try
        {
            response = client.execute(httpPost);
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        int responseCodeInt = response.getStatusLine().getStatusCode();
        JSONObject responseCode = new JSONObject("{\"ResponseCode\": \"" + responseCodeInt + "\"}");
        System.out.println("api tier2  register");
        return responseCode;
    }


    public static synchronized JSONObject getUserInfo(String username)
    {
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:5000/users/getUserByInfo/" + username);
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection conn = null;
        try
        {
            conn = (HttpURLConnection) url.openConnection();
            try
            {
                conn.setRequestProperty("Content-Type", "application/json");
                conn.setRequestMethod("GET");

            } catch (ProtocolException e)
            {
                e.printStackTrace();
            }
            BufferedReader rd;
            rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
            String line;
            while ((line = rd.readLine()) != null)
            {
                result.append(line);
            }
            rd.close();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        try
        {
            if (conn.getResponseCode() != 200)
            {
                JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}");
                return JSONResult;
            } else
            {
                JSONObject JSONResult = new JSONObject(result.toString());
                return JSONResult;
            }
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        return null;
    }




    public static synchronized JSONObject getUser(String username)
    {
        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:5000/users/getuser/" + username);
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection conn = null;
        try
        {
            conn = (HttpURLConnection) url.openConnection();
            try
            {

                conn.setRequestProperty("Content-Type", "application/json");
                conn.setRequestMethod("GET");

            } catch (ProtocolException e)
            {
                e.printStackTrace();
            }
            BufferedReader rd;
            rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
            String line;
            while ((line = rd.readLine()) != null)
            {
                result.append(line);
            }
            rd.close();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        try
        {
            if (conn.getResponseCode() != 200)
            {
                JSONObject JSONResult = new JSONObject("{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}");
                return JSONResult;
            } else
            {
                JSONObject JSONResult = new JSONObject(result.toString());
                return JSONResult;
            }
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        return null;
    }




    public static synchronized JSONObject storeMessage(ChatMessage message)
    {

        httpPost = new HttpPost("https://localhost:5000/chatMessages");
        String json = gson.toJson(message);
        StringEntity entity = null;
        try
        {
            entity = new StringEntity(json);

        } catch (UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }
        httpPost.setEntity(entity);
        httpPost.setHeader("Accept", "application/json");
        httpPost.setHeader("Content-type", "application/json");
        CloseableHttpResponse response = null;
        try
        {
            response = client.execute(httpPost);
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        int responseCodeInt = response.getStatusLine().getStatusCode();
        JSONObject responseCode = new JSONObject("{\"ResponseCode\": \"" + responseCodeInt + "\"}");
        return responseCode;
    }



    public static synchronized JSONObject editUser(String username, JSONObject data)
    {

        URL url = null;
        try
        {
            url = new URL("https://localhost:5000/users/" + username);
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection httpCon = null;
        try
        {
            httpCon = (HttpURLConnection) url.openConnection();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        httpCon.setDoOutput(true);
        try
        {
            httpCon.setRequestProperty("Content-Type", "application/json");
            httpCon.setRequestMethod("PUT");
        } catch (ProtocolException e)
        {
            e.printStackTrace();
        }
        try
        {
            OutputStreamWriter out = new OutputStreamWriter(httpCon.getOutputStream());
            User user=new User();
            user.username=username;
            user.password=data.getString("password");
            user.sex=data.getString("sex");
            user.lastname=data.getString("lastname");

            user.hometown=data.getString("hometown");
            user.firstname=data.getString("firstname");

            user.description=data.getString("description");
            user.age=data.getInt("age");
            user.major=data.getString("major");
            user.hobbies=data.getString("hobbies");

            String jsondata=gson.toJson(user);
            out.write(jsondata);
            out.close();
            httpCon.getInputStream();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        JSONObject JSONResult = null;
        try
        {
            JSONResult = new JSONObject("{\"ResponseCode\": \"" + httpCon.getResponseCode() + "\"}");
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        return JSONResult;
    }




    public static synchronized JSONObject sendFriendRequest(JSONObject friend)
    {
        URL url = null;
        try
        {
            url = new URL("https://localhost:5000/friends");
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection httpCon = null;
        try
        {
            httpCon = (HttpURLConnection) url.openConnection();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        httpCon.setDoOutput(true);
        try
        {
            httpCon.setRequestProperty("Content-Type", "application/json");
            httpCon.setRequestMethod("POST");
        } catch (ProtocolException e)
        {
            e.printStackTrace();
        }
        try
        {
            OutputStreamWriter out = new OutputStreamWriter(httpCon.getOutputStream());
            String Jsondata = friend.toString();
            out.write(Jsondata);
            out.close();
            httpCon.getInputStream();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        JSONObject JSONResult = null;
        try
        {
            JSONResult = new JSONObject("{\"ResponseCode\": \"" + httpCon.getResponseCode() + "\"}");
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        return JSONResult;
    }




    public static synchronized JSONArray searchUsers(String firstname, String lastname, String sex,
                                                           String major, String hometown, int maxage, int minage, String hobbies)
    {

        StringBuilder result = new StringBuilder();
        URL url = null;
        try
        {
            url = new URL("https://localhost:5000/users/SearchUsers");
        } catch (MalformedURLException e)
        {
            e.printStackTrace();
        }
        HttpURLConnection conn = null;
        try
        {
            conn = (HttpURLConnection) url.openConnection();
            try
            {

                conn.setRequestProperty("Content-Type", "application/json");
                conn.setRequestMethod("GET");
            } catch (ProtocolException e)
            {
                e.printStackTrace();
            }
            BufferedReader rd;
            rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
            String line;
            while ((line = rd.readLine()) != null)
            {
                result.append(line);
            }
            rd.close();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
        try
        {
            if (conn.getResponseCode() != 200)
            {
                JSONArray JSONResult = new JSONArray("[{\"ResponseCode\": \"" + conn.getResponseCode() + "\"}]");
                return JSONResult;
            } else
            {
                JSONArray JSONResult = new JSONArray(result.toString());
                return JSONResult;
            }
        } catch (IOException e)
        {
            e.printStackTrace();
        }

        return null;

    }





}

