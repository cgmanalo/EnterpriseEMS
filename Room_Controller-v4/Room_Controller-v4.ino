//Enterprise EMS
//EE200D- Capstone Project
//Copyright (c) 2019-2020, J. Calingasan, A. Eugenio, Cesar G. Manalo, Jr. (Adviser)

#include <EEPROM.h>
#include <avr/wdt.h>

#define START_FLAG '~'
#define END_FLAG '^'
#define VALID true

char ROOM_CONTROLLER_ADDR;
char Room_Addr;
unsigned long Start_Timer;
unsigned long Start_Timer2;
char Data_Field[20];
char Data_Char;

char firstCharRcvd;
char secondCharRcvd;
char thirdCharRcvd;
char fourthCharRcvd;
String Device_Name;
String Device_Command;
String Appliance_Stat;
int brightness = 0;
int fadeamount = 1;
int ROOM_COUNT;
int ctlrAddrMap = 10; //address of memory where controller address is stored
int ctlrAddrCountMap = 15; //address of number of addresses in this Controller
int timeDelayLightingAddr = 30;
int timeDelayACUAddr = 31;
int transmitWaitAddr = 32;
int receiveWaitAddr = 33;
int timeDelayLighting = 0;
int timeDelayACU = 0;
int transmitWait = 0;
int receiveWait = 200;
String serialData;

//ISR variables
volatile unsigned long last_micros;
long debouncingTime = 200;
const byte Addr0 = 2;
const byte Addr1 = 3;
const byte Enable = 4;

const byte lighting1Pin = 5;
const byte ACU1A = 6;
const byte ACU1B = 7;

const byte lighting2Pin = 8;
const byte ACU2A = 9;
const byte ACU2B = 10;

const byte lighting3Pin = 9;
const byte ACU3A = 10;
const byte ACU3B = 11;

const byte HeartBeat = 11;
const byte interruptPin = 2;
void(* resetFunc) (void) = 0;

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


void setup() {
 Serial.begin(9600);
// pinMode(lighting1Pin, OUTPUT);
 pinMode(Addr0, OUTPUT);
 pinMode(Addr1, OUTPUT);
 pinMode(Enable, OUTPUT);

 pinMode(lighting1Pin, OUTPUT);
 pinMode(ACU1A, OUTPUT);
 pinMode(ACU1B, OUTPUT);
 
 pinMode(lighting2Pin, OUTPUT);
 pinMode(ACU2A, OUTPUT);
 pinMode(ACU2B, OUTPUT);
 
 pinMode(lighting3Pin, OUTPUT);
 pinMode(ACU3A, OUTPUT);
 pinMode(ACU3B, OUTPUT);
 
 pinMode(HeartBeat, OUTPUT);

 PORTD = (PORTD & B11101111) | B00001100; //set comms. channel to UART/PLC
 
 digitalWrite(lighting1Pin, HIGH);
 digitalWrite(ACU1A,HIGH);
 digitalWrite(ACU1B,HIGH);
 
 digitalWrite(lighting2Pin,HIGH);
 digitalWrite(ACU2A,HIGH);
 digitalWrite(ACU2B,HIGH);
 
 digitalWrite(lighting3Pin,HIGH);
 digitalWrite(ACU3A,HIGH);
 digitalWrite(ACU3B,HIGH);
 
 getConfiguration();
 Preamble();
 //watchdogSetup();
}

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

void loop() {
  //wdt_reset();
  brightness = brightness + fadeamount;
  analogWrite(ACU3B,brightness);
  delay(5);
  if (brightness == 1 || brightness == 255){
    fadeamount = -fadeamount;
  }

  if (GetSerialData() == VALID) {
    serialData = (String)Data_Field;
    Device_Name = extractField(serialData,1);
    Device_Command = extractField(serialData,2);
    if(Device_Name == "PA1"){
        sendReply(Device_Name + "|" + Device_Command + "|" + (String)ReadPA1(Device_Command));
    }
    else if(Device_Name == "PA2"){
        sendReply(Device_Name + "|" + Device_Command + "|" + (String)ReadPA2(Device_Command));
    }
    else if(Device_Name == "PA3"){
        sendReply(Device_Name + "|" + Device_Command + "|" + (String)ReadPA3(Device_Command));
    }
    else if(Device_Name == "LIGHT1"){
        if (OPERLight1(Device_Command)){
            sendReply(Device_Name + "|ON");
        }
        else{
            sendReply(Device_Name + "|OFF");
        }
    }
    else if(Device_Name == "ACU1A"){
        if (OPERACU1A(Device_Command)){
            sendReply(Device_Name + "|ON");
        }
        else{
            sendReply(Device_Name + "|OFF");
        }
    }
    else if(Device_Name == "ACU1B"){
        if (OPERACU1B(Device_Command)){
            sendReply(Device_Name + "|ON");
        }
        else{
            sendReply(Device_Name + "|OFF");
        }
    }
    else if (Device_Name == "CONTROL1"){
      if (Device_Command == "RST"){
        sendReply(Device_Name + "|RST");
        resetFunc();
      }
        sendReply(Device_Name + "|OK");
    }
    else{
        sendReply("Unrecognize Device Name or Instruction.");
    }
  }
}

//***** SUBROUTINES *****//
bool GetSerialData(){
  if (Serial.read() == START_FLAG){
    Start_Timer = millis();
    while(millis()-Start_Timer < 100){
      if(Serial.read() == START_FLAG){
        Start_Timer = millis();
        while(millis()-Start_Timer < 100){
          if(Serial.read() == START_FLAG){ //<<<<<

            int i=0;
            Data_Field[0] = '\0';
            Start_Timer2 = millis();
            while(millis()-Start_Timer2 < 3000){
              Start_Timer = millis();
              while(millis()-Start_Timer < 100){
                Data_Char = Serial.read();
                if(Data_Char == END_FLAG){
                  Start_Timer = millis();
                  while(millis()-Start_Timer < 100){
                    Data_Char = Serial.read();
                    if(Data_Char == END_FLAG){
                      Start_Timer = millis();
                      while(millis()-Start_Timer < 100){
                        Data_Char = Serial.read();
                        if(Data_Char == END_FLAG){
                          Data_Field[i++] = '\0';
                          return true;
                        }
                        else if(Data_Char != -1){
                          Data_Field[i++] = Data_Char;
                          break;
                        }
                      }
                    }
                    else if(Data_Char != -1){
                      Data_Field[i++] = Data_Char;
                      break;
                    }
                  }
                  break;
                }
                else if(Data_Char != -1){
                  Data_Field[i++] = Data_Char;
                  break;
                }
              }
            }
            break;
          } //<<<<<
        }
        break;
      }
    }
  }
  return false;
}

void serialFlush(){
  while(Serial.available() > 0) {
    char t = Serial.read();
  }
}

double ReadPA1(String Operation){
  setPA1Channel();
  serialFlush();
  if (Operation == "VOLT"){
    Serial.print("\002D00\003");
  }
  else if(Operation == "CURR"){
    Serial.print("\002D01\003");
  }
  else if(Operation == "ALL"){
    ;
  }
  delay(200);
  return Serial.readString().substring(3).toFloat();
}

double ReadPA2(String Operation){
  setPA2Channel();
  serialFlush();
  if (Operation == "VOLT"){
    Serial.print("\002D00\003");
  }
  else if(Operation == "CURR"){
    Serial.print("\002D01\003");
  }
  else if(Operation == "ALL"){
    ;
  }
  delay(200);
  return Serial.readString().substring(3).toFloat();
}

double ReadPA3(String Operation){
  setPA3Channel();
  serialFlush();
  if (Operation == "VOLT"){
    Serial.print("\002D00\003");
  }
  else if(Operation == "CURR"){
    Serial.print("\002D01\003");
  }
  else if(Operation == "ALL"){
    ;
  }
  delay(200);
  return Serial.readString().substring(3).toFloat();
}

bool OPERLight1(String Operation){
  if (Operation == "ON"){
      digitalWrite(lighting1Pin,HIGH);
  }
  else if(Operation == "OFF"){
      digitalWrite(lighting1Pin,LOW);
  }
  else if(Operation == "TOG"){
      digitalWrite(lighting1Pin,!digitalRead(lighting1Pin));
  }
  delay(10);
  return(digitalRead(lighting1Pin));
  
}
bool OPERACU1A(String Operation){
  if (Operation == "ON"){
      digitalWrite(ACU1A,HIGH);
  }
  else if(Operation == "OFF"){
      digitalWrite(ACU1A,LOW);
  }
  else if(Operation == "TOG"){
      digitalWrite(ACU1A,!digitalRead(ACU1A));
  }
  delay(10);
  return(digitalRead(ACU1A));
}
bool OPERACU1B(String Operation){
  if (Operation == "ON"){
      digitalWrite(ACU1B,HIGH);
  }
  else if(Operation == "OFF"){
      digitalWrite(ACU1B,LOW);
  }
  else if(Operation == "TOG"){
      digitalWrite(ACU1B,!digitalRead(ACU1B));
  }
  delay(10);
  return(digitalRead(ACU1B));
}

void sendReply(String replyMessage){
  setPLCChannel();
  Serial.print("~~~" + replyMessage + "^^^");
}

void setPA1Channel(){
  PORTD = (PORTD & B11100011);
  delay(100);
}

void setPA2Channel(){
  PORTD = (PORTD & B11100111) | B00000100;
  delay(100);
}

void setPA3Channel(){
  PORTD = (PORTD & B11101011) | B00001000;
  delay(100);
}

void setPLCChannel(){
  PORTD = (PORTD & B11101111) | B00001100;
  delay(100);
}

void sendCharToPowerLine(char charToSend){
  Serial.print(charToSend);
  delay(transmitWait);
}

void sendCharDirect(char charToSend){
  Serial.print(charToSend);
}

String extractSerialData2(){
  Serial.setTimeout(10);
  return Serial.readStringUntil('\n');
}

void watchdogSetup(void)
{
cli();       // disable all interrupts
wdt_reset(); // reset the WDT timer
/*
 WDTCSR configuration:
 WDIE = 1: Interrupt Enable
 WDE = 1 :Reset Enable
 WDP3 = 1 :For 8000ms Time-out
 WDP2 = 0 :For 8000ms Time-out
 WDP1 = 0 :For 8000ms Time-out
 WDP0 = 1 :For 8000ms Time-out
*/
// Enter Watchdog Configuration mode:
WDTCSR |= (1<<WDCE) | (1<<WDE);
// Set Watchdog settings:
 WDTCSR = (1<<WDIE) | (1<<WDE) | (1<<WDP3) | (0<<WDP2) | (0<<WDP1) | (1<<WDP0);
sei();
}

void Preamble()
{
  Serial.println("\nRoom Controller ver. 2.1 - Model A\n");
  Serial.println("EE200D-2019 Capstone Project");
  Serial.println("Copyright (c) 2019-2020, J. Calingasan, A. Eugenio, Cesar G. Manalo, Jr. (Adviser)");
}

void getConfiguration()
{
 ROOM_CONTROLLER_ADDR = EEPROM.read(ctlrAddrMap); //retrieve first address
 if (ROOM_CONTROLLER_ADDR < 65 || ROOM_CONTROLLER_ADDR > 90){ROOM_CONTROLLER_ADDR = 65;}
 ROOM_COUNT = EEPROM.read(ctlrAddrCountMap)-48; //retrieve number of addresses
 if (ROOM_COUNT < 1 || ROOM_COUNT > 3){ROOM_COUNT = 3;}
 timeDelayLighting = (EEPROM.read(timeDelayLightingAddr)-48)*500;
 if (timeDelayLighting < 0 || timeDelayLighting > 2500){timeDelayLighting = 0;}
 timeDelayACU = (EEPROM.read(timeDelayACUAddr)-48)*500;
 if (timeDelayACU < 0 || timeDelayACU > 2500){timeDelayACU = 0;}
 transmitWait = (EEPROM.read(transmitWaitAddr)-48)*200;
 if (transmitWait < 0 || transmitWait > 1800){transmitWait = 0;}
 receiveWait = (EEPROM.read(receiveWaitAddr)-48)*200;
 if (receiveWait < 200 || receiveWait > 1000){receiveWait = 200;}
}

String extractField(String rawString, int fieldNum){
   char dataArray[30];
   char fieldArray[25];   
   char inChar;
   
   rawString.toCharArray(dataArray,rawString.length()+1);

   //first field
   if (fieldNum == 1){
     int i=0;
     for(i;i<rawString.length();i++){
       inChar = dataArray[i];
       if (inChar == '|'){
         break;
       }
       fieldArray[i] = inChar;
     } 
     fieldArray[i]='\0';
     return fieldArray;
   }

   //second field
   else if (fieldNum == 2) {
     int i = rawString.indexOf('|')+1;
     int j=i;
     for(i;i<rawString.length();i++){
       inChar = dataArray[i];
       if (inChar == '|'){
         break;
       }
       fieldArray[i-j] = inChar;
     }
     fieldArray[i-j]='\0';
     return fieldArray;
   }

  //third field
   else if (fieldNum == 3) {
     int i = rawString.indexOf('|',rawString.indexOf('|')+1)+1;
     int j=i;
     for(i;i<rawString.length();i++){
       inChar = dataArray[i];
       if (inChar == '|'){
         break;
       }
       fieldArray[i-j] = inChar;
     }
     fieldArray[i-j]='\0';
     return fieldArray;
   }
   else if (fieldNum == 4) {
     int i = rawString.indexOf('|',rawString.indexOf('|',rawString.indexOf('|')+1)+1)+1;
     int j=i;
     for(i;i<rawString.length();i++){
       inChar = dataArray[i];
       if (inChar == '|'){
         break;
       }
       fieldArray[i-j] = inChar;
     }
     fieldArray[i-j]='\0';
     return fieldArray;
   }
     
   return "";
}
/*

boolean onDemandMode(){
  delay(1000);
  if (Serial.available()){
    delay(10);
    //empty receive buffer 
    while (Serial.available()) {
        Serial.read(); 
        delay(1);
    }
  }
  //send on-demand command once buffer is empty
  Serial.write(0x02); // correct way to send [STX]
  Serial.print("M3"); // ON-DEMAND
  Serial.write(0x03); // [ETX] marker
  delay(1000);
  if (!Serial.available()){
    return 1;
  }
  else{
    return 0; 
  }
}

String getVoltRMS(){
  int i;
  String tempString1 = "";
  String tempString2 = getPAParameter(VoltRMS);
  char tempCharArray[tempString2.length()];
  tempString2.toCharArray(tempCharArray,tempString2.length());
  for (i=0; i < tempString2.length(); i++){
    if (tempCharArray[i] == ','){
      break;
    }
  }
  for (i=i+1; i < tempString2.length()-4; i++){
    tempString1 +=  tempCharArray[i];
  }
  //return (String)  (((float) round(1000*tempString1.toFloat()))/1000.000);
  return tempString1;
}

String getAmpRMS(){
  int i;
  String tempString1 = "";
  String tempString2 = getPAParameter(AmpRMS);
  char tempCharArray[tempString2.length()];
  tempString2.toCharArray(tempCharArray,tempString2.length());
  for (i=0; i < tempString2.length(); i++){
    if (tempCharArray[i] == ','){
      break;
    }
  }
  for (i=i+1; i < tempString2.length()-2; i++){
    tempString1 +=  tempCharArray[i];
  }
  return tempString1;
}

String getPAParameter(String request){
  String serialString = "";
  Serial.write(0x02); // correct way to send [STX]
  Serial.print(request); // send request
  Serial.write(0x03); // [ETX] marker
  delay(1000);
  if (Serial.available()){
    delay(10);
    while (Serial.available()) {
        serialString = serialString + (char)Serial.read();
        delay(1);
    }
 }
 return serialString;
}

String dayAsString(const Time::Day day) {
  switch (day) {
    case Time::kSunday: return "Sun";
    case Time::kMonday: return "Mon";
    case Time::kTuesday: return "Tue";
    case Time::kWednesday: return "Wed";
    case Time::kThursday: return "Thu";
    case Time::kFriday: return "Fri";
    case Time::kSaturday: return "Sat";
  }
  return "???";  //unknown day
}
String getWeekday (int dayNumber){
  String Weekday;  
  switch (dayNumber) {
      case 0:
        Weekday = "Sun";
        break;
      case 1:
        Weekday = "Mon";
        break;
      case 2:
        Weekday = "Tue";
        break;
      case 3:
        Weekday = "Wed";
        break;
      case 4:
        Weekday = "Thu";
        break;
      case 5:
        Weekday = "Fri";
        break;
      case 6:
        Weekday = "Sat";
        break;
      default:
        break;
  }
  return Weekday;
}
String getAMPM(int hourNumber){
  if (hourNumber < 12)
  {
      return "AM";
  }
  else
  {
      return "PM";
  }
}
String getNormalizedHour(int hourNumber){
  String hourString;
 
  if (hourNumber < 13)
  {
    hourString = String(hourNumber); 
  }
  else
  {
    hourString = String(hourNumber-12); 
  }
  if (hourString.length()==1)
  {
      return "0"+hourString;
  }
  else
  {
      return hourString;
  }
}

String getNormalizedMinute(int minuteNumber){
  String minuteString;
 
  minuteString = String(minuteNumber);
  if (minuteString.length()==1)
  {
      return "0"+minuteString;
  }
  else
  {
      return minuteString;
  }
}

String getNormalizedSecond(int secondNumber){
  String secondString;
 
  secondString = String(secondNumber);
  if (secondString.length()==1)
  {
      return "0"+secondString;
  }
  else
  {
      return secondString;
  }
}

unsigned int timeValue(String timeString){

   int AMPMAddress = timeString.length()-2;
   //return timeString.substring(3,5).toInt();

   if (timeString.substring(AMPMAddress)=="AM"){
     return 60*timeString.substring(0,2).toInt()+timeString.substring(3,5).toInt();
   }
   else{
     if (timeString.substring(0,2).toInt()==12){
       return 60*12+timeString.substring(3,5).toInt();
     }
     else{
       return 60*(12+timeString.substring(0,2).toInt())+timeString.substring(3,5).toInt();
     }
   }
}

void blink() {
  if ((long)(micros()-last_micros) > debouncingTime*1000){
    digitalWrite(lighting1Pin,!digitalRead(lighting1Pin));
    last_micros = micros();
  }
}
*/
