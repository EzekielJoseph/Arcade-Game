#include <Arduino.h>

const int buttonPin1 = 12;
const int buttonPin2 = 13;
const int ledPin = 2;    
const int blueLedPin = 4; // Pin untuk LED biru   

void setup() {
  Serial.begin(115200);
  pinMode(buttonPin1, INPUT_PULLUP);
  pinMode(buttonPin2, INPUT_PULLUP);
  pinMode(ledPin, OUTPUT);

  Serial.println("Siap menerima input dari tombol");
}

void loop() {
  int buttonState1 = digitalRead(buttonPin1);
  int buttonState2 = digitalRead(buttonPin2);

  if (buttonState1 == LOW) {
    Serial.println("Tombol 1 ditekan");
    digitalWrite(blueLedPin, HIGH); // Nyalakan LED
    delay(1000); // Tunggu 1 detik
    digitalWrite(blueLedPin, LOW); // Matikan LED
  } 
  
  else if(buttonState2 == LOW){
    digitalWrite(ledPin, HIGH); // Nyalakan LED
    Serial.println("Tombol 2 ditekan");
    delay(1000); // Tunggu 1 detik
    digitalWrite(ledPin, LOW); // Matikan LED
  } 
}

