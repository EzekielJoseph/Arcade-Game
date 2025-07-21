#include <Arduino.h>

const int buttonLeft = 25;
const int buttonRight = 33;
const int ledPin = 2;    

bool lefPressed = false;
bool rightPressed = false;

void setup() {
  Serial.begin(115200);
  pinMode(buttonLeft, INPUT_PULLUP);
  pinMode(buttonRight, INPUT_PULLUP);
  pinMode(ledPin, OUTPUT);

  Serial.println("Siap menerima input dari tombol");
}

void loop() {
  int buttonState1 = digitalRead(buttonLeft);
  int buttonState2 = digitalRead(buttonRight);

  //Left Button
  if (buttonState1 == LOW && !lefPressed) {
    Serial.println("LEFT");
    lefPressed = true;

    for(int i = 0; i < 2; i++) {
      digitalWrite(ledPin, HIGH); // Nyalakan LED
      delay(500); // Tunggu 0.5 detik
      digitalWrite(ledPin, LOW); // Matikan LED
      delay(500); // Tunggu 0.5 detik
    }

  } else if (buttonState1 == HIGH && lefPressed) {
    lefPressed = false; // Reset flag jika tombol kiri dilepas
  } 

  //Right Button
  if(buttonState2 == LOW && !rightPressed) {
    Serial.println("RIGHT");    
    rightPressed = true; // Set flag untuk tombol kanan ditekan


    for(int i = 0; i < 4; i++) {
      digitalWrite(ledPin, HIGH); // Nyalakan LED
      delay(500); // Tunggu 0.5 detik
      digitalWrite(ledPin, LOW); // Matikan LED
      delay(500); // Tunggu 0.5 detik
    }
    
  } else if (buttonState2 == HIGH && rightPressed) {
    rightPressed = false; // Reset flag jika tombol kanan dilepas
  } 
}

