package Model;

import java.util.Date;

public class ChatMessage {
    public String nameSend ;
    public String nameRecv ;
    public String message ;
    public Date date ;
    public byte[] image;
    public boolean online;

    public ChatMessage() {
    }

    public String getNameSend() {
        return nameSend;
    }

    public void setNameSend(String nameSend) {
        this.nameSend = nameSend;
    }

    public String getNameRecv() {
        return nameRecv;
    }

    public void setNameRecv(String nameRecv) {
        this.nameRecv = nameRecv;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public byte[] getImage() {
        return image;
    }

    public void setImage(byte[] image) {
        this.image = image;
    }

    public boolean isOnline() {
        return online;
    }

    public void setOnline(boolean online) {
        this.online = online;
    }
}
