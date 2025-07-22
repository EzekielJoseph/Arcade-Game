#include <Arduino.h>

const int buttonLeft = 25;
const int buttonRight = 33;
const int buttonSpace = 27;
const int ledPin = 2;    

bool spacePressed = false;

void setup() {
  Serial.begin(115200);
  pinMode(buttonLeft, INPUT_PULLUP);
  pinMode(buttonRight, INPUT_PULLUP);
  pinMode(buttonSpace, INPUT_PULLUP);
  pinMode(ledPin, OUTPUT);

  Serial.println("Siap menerima input dari tombol");
}

void loop() {
  int buttonState1 = digitalRead(buttonLeft);
  int buttonState2 = digitalRead(buttonRight);
  int buttonState3 = digitalRead(buttonSpace);

  //Left Button
  if (buttonState1 == LOW) {
    Serial.println("LEFT");
    delay(20);
  } 

  //Right Button
  if(buttonState2 == LOW ) {
    Serial.println("RIGHT");
    delay(20);
  }

  if(buttonState3 == LOW && !spacePressed) {
    Serial.println("SPACE");
    spacePressed = true; // Tandai bahwa tombol space sudah ditekan
    delay(100); // Debounce delay
  } else if (buttonState3 == HIGH && spacePressed) {
    spacePressed = false; // Reset status tombol space
  }
}

