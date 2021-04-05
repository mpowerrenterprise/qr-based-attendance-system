import cv2
import ctypes
import pyttsx3
import datetime
import playsound
import numpy as np
from PIL import Image
from pyzbar.pyzbar import decode

engine = pyttsx3.init()
voices = engine.getProperty('voices')       #getting details of current voice
#engine.setProperty('voice', voices[0].id)  #changing index, changes voices. o for male
engine.setProperty('voice', voices[1].id)   #changing index, changes voices. 1 for female


user32 = ctypes.windll.user32
screensize = user32.GetSystemMetrics(0), user32.GetSystemMetrics(1)

Screen_Width = 820
Screen_Height = 620

Screen_Center_Width = int((screensize[0] - Screen_Width) / 2)
Screen_Center_Height = int((screensize[1] - Screen_Height) / 2) - 30

def greeting_function():
    currentHour = int(datetime.datetime.now().hour)
    basicGreeting = ""

    if currentHour >= 0 and currentHour < 12:
        basicGreeting = "Good Morning!"

    if currentHour >= 12 and currentHour < 18:
        basicGreeting = "Good Afternoon!"

    if currentHour >= 18 and currentHour != 0:
        basicGreeting = "Good Evening!"

    return basicGreeting


def talk_function(words):
	engine.say(words)
	engine.runAndWait()

cap = cv2.VideoCapture(0)
counter = 0

while True:
	
	ret, frame = cap.read()
	frame = cv2.resize(frame, (Screen_Width, Screen_Height))
	QRcodeData = decode(frame)

	if len(QRcodeData) !=0:
		
		CodeType = QRcodeData[0][1]

		if CodeType == "QRCODE":
			hiddenData = QRcodeData[0][0].decode('utf-8')

			if counter == 3:

				playsound.playsound("system-data\\QR-sound.mp3")
				counter = 0

			counter = counter + 1
			
			pts = np.array([QRcodeData[0][3]],np.int32)
			pts = pts.reshape((-1,1,2))
			cv2.polylines(frame,[pts],True,(0,255,0),5)


	cv2.imshow('Display_1',frame)
	cv2.moveWindow('Display_1', Screen_Center_Width, Screen_Center_Height) ##center window



	if cv2.waitKey(1) & 0xFF == ord('q'):
		break

cap.release()
cv2.destroyAllWindows()

