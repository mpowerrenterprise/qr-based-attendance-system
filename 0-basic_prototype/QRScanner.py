from pyzbar.pyzbar import decode
from PIL import Image
import cv2
import pyttsx3
import datetime
import playsound

engine = pyttsx3.init()
voices = engine.getProperty('voices')       #getting details of current voice
#engine.setProperty('voice', voices[0].id)  #changing index, changes voices. o for male
engine.setProperty('voice', voices[1].id)   #changing index, changes voices. 1 for female


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

while True:
	
	ret, frame = cap.read()
	cv2.imshow('frame',frame)
	cv2.imwrite("cache_img.png",frame)
	d = decode(Image.open("cache_img.png"))
	#print()

	try:
		if d[0][0].decode('utf-8') == "guna123":

			playsound.playsound("QRSound.mp3")
			
			greeting = greeting_function()
			talk_function(f"{greeting}, Gunarakulan, you are warmly welcome")

	except Exception as e:
		pass


	if cv2.waitKey(1) & 0xFF == ord('q'):
		break

cap.release()
cv2.destroyAllWindows()

