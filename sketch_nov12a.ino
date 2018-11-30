#include <ESP8266WiFi.h>
#include <WiFiClientSecure.h>
#include <SPI.h>
#include "MFRC522.h"
#include <Arduino.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266HTTPClient.h>
#include <QueueList.h>

ESP8266WiFiMulti WiFiMulti;
QueueList <String> queue;
const char* ssid = "Shen";
const char* password = "perushenoy";

const char* host = "maker.ifttt.com";
const int httpsPort = 443;
constexpr uint8_t RST_PIN = 0;         
constexpr uint8_t SS_PIN = 2;         // Configurable, see typical pin layout above
//String rfid="";

MFRC522 mfrc522(SS_PIN, RST_PIN);  // Create MFRC522 instance

void setup() {
     Serial.begin(9600);    // Initialize serial communications
     delay(250);
      WiFi.begin("Shen", "perushenoy");
 
     SPI.begin();           // Init SPI bus
     mfrc522.PCD_Init();    // Init MFRC522
     queue.setPrinter (Serial);
}

void loop() {
  
 
   if(queue.count()==2)
  { 
    while(!queue.isEmpty())
      {
        Serial.print(queue.pop ());
      }
       Serial.println();
    }
   
   if ( ! mfrc522.PICC_IsNewCardPresent()) {
      delay(50);
      return;
     }
     
      // Select one of the cards
    if ( ! mfrc522.PICC_ReadCardSerial()) {
    delay(50);
    return;
     }

String content= "";
  byte letter;
  
  for (byte i = 0; i < mfrc522.uid.size; i++) 
  { 
     //Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
     //Serial.print(mfrc522.uid.uidByte[i], HEX);
     content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " "));
     content.concat(String(mfrc522.uid.uidByte[i], HEX));
  }
  content.toUpperCase();
  if (content.substring(1) == "D2 D9 90 79") //change here the UID of the card/cards that you want to give access
  {
    if(queue.isEmpty())
    {
    queue.push("RAMESH");
    delay(50);
    }
    else if(queue.peek()!="RAMESH")
    {
      queue.push("RAMESH");
    delay(50);
    sms();
    }
    
    return;
  }
  else if (content.substring(1) == "F1 85 53 2D")
  {
    if(queue.isEmpty())
    {
    queue.push("SURESH");
    delay(50);
    }
    else if(queue.peek()!="SURESH")
    {
      queue.push("SURESH");
    delay(50);
    }
    
    return;
  }
  
}

void sms()
{
  WiFiClientSecure client;
  //Serial.print("connecting to ");
  //Serial.println(host);
  if (!client.connect(host, httpsPort)) {
    //Serial.println("connection failed");
    return;
  }
   String url = "/trigger/ESP/with/key/ielZ9jfWNQwSZ0jUxVCmqsPe4sn_HxCNWUIYfeCxbGU";
  //Serial.print("requesting URL: ");
  //Serial.println(url);

  client.print(String("GET ") + url + " HTTP/1.1\r\n" +
               "Host: " + host + "\r\n" +
               "User-Agent: BuildFailureDetectorESP8266\r\n" +
               "Connection: close\r\n\r\n");

  //Serial.println("request sent");
  while (client.connected()) {
    String line = client.readStringUntil('\n');
    if (line == "\r") {
      //Serial.println("headers received");
      break;
    }
  }
  String line = client.readStringUntil('\n');
  //Serial.println("reply was:");
  //Serial.println("==========");
  //Serial.println(line); // when this line gets printed an sms is sent to the user's phone
  //Serial.println("==========");
  //Serial.println("closing connection");
  //Serial.println("high");
  
}

