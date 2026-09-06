# Roll of Duty 🎯

![Ball Balancer](https://github.com/user-attachments/assets/8920b256-2ba8-4988-b824-5351134eb4bd)

## Basic Details

### Team Name

**Kaelix**

### Team Members

* **Team Lead:** Hari Prasad T S - SSET
* **Member:** Muhammed Faheem P A - SSET

## Project Description

**Ball Balancer** is a hardware-based game controller that converts real-world physical inputs into in-game actions.

Using an Arduino, gyroscope, joystick, and buttons, the system reads movements and user inputs and sends them to the game as controls.

Real-world utility? Almost zero.

Learning value? Surprisingly high. 😭

We got hands-on experience with sensors, Arduino, serial communication, hardware integration, input mapping, debugging, and connecting the physical world to software.

## The Problem That Doesn't Exist

Normal keyboards and controllers work perfectly fine.

Unfortunately, that wasn't complicated enough for us.

Mainstream games don't always feel physically immersive, so we decided to build a controller where actual movement directly influences the game.

## The Solution Nobody Asked For

We connected physical sensors to an Arduino and converted their readings into game controls.

Tilt the controller → the game reacts.

Move the joystick → the game reacts.

Press a button → something hopefully happens.

The result is a more physical and unnecessarily complicated way to control a game.

And that's exactly why we built it.

---

# Technical Details

## Technologies / Components Used

### Software

* **Arduino C/C++**
* **Arduino IDE**
* Serial Communication
* Custom input mapping and game-control logic
* Git & GitHub for version control and documentation

### Hardware

* Arduino Uno
* MPU6050 Gyroscope / Accelerometer
* Joystick Module
* Push Buttons
* Breadboard
* Jumper Wires
* USB Cable
* Laptop / PC

---

# Implementation

## How It Works

1. The **gyroscope** detects tilt and rotational movement.
2. The **joystick** provides directional input.
3. **Buttons** provide additional game actions.
4. The **Arduino** reads all sensor values.
5. Sensor data is processed and converted into usable control values.
6. The Arduino sends the data to the computer through serial communication.
7. The game converts these inputs into player or ball movement.

In simple terms:

**Real-world movement → Sensors → Arduino → Serial Data → Game Action**

---

## Software

### Installation

1. Install the Arduino IDE.
2. Connect the Arduino Uno to the computer.
3. Install the required sensor libraries.
4. Open the project Arduino sketch.
5. Select:

```text
Tools → Board → Arduino Uno
```

6. Select the correct COM port.
7. Upload the program to the Arduino.

### Required Arduino Library

For the MPU6050, install a compatible MPU6050 library through:

```text
Arduino IDE → Library Manager → Search "MPU6050"
```

### Run

Upload the Arduino code and start the game/application.

Ensure the Arduino remains connected through USB so sensor data can continuously reach the computer.

---

# Project Documentation

## Software Screenshots

### Screenshot 1

![Screenshot1](Add screenshot 1 here)

*Arduino code used to read and process sensor, joystick, and button inputs.*

### Screenshot 2

![Screenshot2](Add screenshot 2 here)

*Serial output showing real-time values received from the physical controller.*

### Screenshot 3

![Screenshot3](Add screenshot 3 here)

*Ball Balancer game running with hardware-based controls.*

---

# System Architecture

## Workflow

```text
         ┌─────────────────┐
         │   Gyroscope     │
         │    MPU6050      │
         └────────┬────────┘
                  │
                  │
┌──────────┐      │      ┌──────────────┐
│ Joystick │──────┼─────▶│ Arduino Uno  │
└──────────┘      │      └──────┬───────┘
                  │             │
┌──────────┐      │             │ USB / Serial
│ Buttons  │──────┘             ▼
└──────────┘              ┌──────────────┐
                          │   Computer   │
                          │     Game     │
                          └──────┬───────┘
                                 │
                                 ▼
                          ┌──────────────┐
                          │ Game Action  │
                          │ Ball Control │
                          └──────────────┘
```

*Physical inputs are captured by sensors, processed by the Arduino, transmitted to the computer, and converted into game actions.*

---

# Hardware

## Circuit

![Circuit](Add your circuit diagram here)

### Main Connections

**MPU6050**

* VCC → Arduino 5V
* GND → Arduino GND
* SDA → Arduino SDA / A4
* SCL → Arduino SCL / A5

**Joystick**

* VCC → 5V
* GND → GND
* VRx → Analog Input
* VRy → Analog Input
* SW → Digital Input

**Buttons**

* Connected to Arduino digital pins
* Configured using digital input / internal pull-up logic

---

## Schematic

![Schematic](Add your schematic diagram here)

*The schematic shows how the MPU6050, joystick, and buttons communicate with the Arduino Uno.*

---

# Build Photos

## Components

![Components](Add photo of your components here)

### Components Used

* Arduino Uno
* MPU6050
* Joystick Module
* Push Buttons
* Breadboard
* Jumper Wires
* USB Cable

## Build

![Build](Add photos of build process here)

### Build Process

1. Connected the MPU6050 to the Arduino.
2. Tested accelerometer and gyroscope readings.
3. Connected and calibrated the joystick.
4. Added physical buttons.
5. Combined all input readings into one Arduino program.
6. Sent data to the computer through serial communication.
7. Mapped sensor values to game controls.
8. Tested everything.
9. Broke everything.
10. Fixed it again. 😭

## Final Build

![Final](Add photo of final product here)

*The final prototype acts as a physical controller for the Ball Balancer game.*

---

# Project Demo

## Video

https://drive.google.com/drive/folders/1lPMRgCKHzCMi0nr4uXL7iPYcHevMNNp7?usp=sharing

The demo shows the Arduino reading real-world motion and controller inputs and translating them into actions inside the Ball Balancer game.

# Team Contributions

### Hari Prasad T S

* Hardware integration
* Arduino programming
* Sensor setup and calibration
* Controller logic
* Testing and debugging

### Muhammed Faheem P A

* Game integration
* Input mapping
* Hardware assembly
* Testing and debugging
* Documentation and project presentation

---

# What We Learned

Even though the project probably won't revolutionize gaming, it taught us quite a lot:

* Arduino programming
* Gyroscope and accelerometer data handling
* Analog and digital input processing
* Serial communication
* Hardware-software integration
* Sensor calibration
* Input mapping
* Debugging hardware
* Debugging software
* Debugging hardware that we thought was software
* Debugging software that we thought was hardware 😭

---

Made with ❤️ and questionable engineering decisions at **TinkerHub Useless Projects**

![Static Badge](https://img.shields.io/badge/TinkerHub-24?color=%23000000\&link=https%3A%2F%2Fwww.tinkerhub.org%2F)

![Static Badge](https://img.shields.io/badge/UselessProjects--26-26?link=https%3A%2F%2Ftinkerhub.org%2Fevents%2F1M8ORET9A1%2Fuseless-projects-3.0)
