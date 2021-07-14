import cv2
import random
import ctypes
import pyttsx3
import datetime
import playsound
import xlsxwriter
import numpy as np
from PIL import Image
import mysql.connector
from pyzbar.pyzbar import decode



Attendance_Already_Exit = ["your attendance has been already marked","your attendance has been already exited in the database", "your attendance is already in the database"]
Entering_Voice_Data = [" ","you look smart today","it's nice to see you","Wow, you are awesome today", "you are so beautiful today", "you are wearing a nice dress", "I like you, because, you are so attractive","you look smart today, and please focus on your studies","please study hard","please focus on your studies","I like you very much, because you are a hard worker"]
Entering_Attendance_Passed = ["your attendance has been marked, You are welcome and have a nice day", "your attendance has been marked, You are welcome and have a nice day","your attendance has been recorded successfully. have a nice day", "you are welcome, your attendance has been marked","you are warmly welcome and your attendance has been marked successfully","your attendance has been marked successfully. have a wonderful day", "your attendance has been marked. Please focus on your studies","your attendance has been noted, i hope, you would perform well on your studies today","thank you, your attendance has been marked","you are welcome, your attendance has been recorded","your attendance has been noted and you are warmly welcome","your attendance has been marked successfully, and please concentrate on your studies"]
unauthorized_IDcard_Voice_Data = ["unauthorized identity card found. access denied. access denied.", "access denied. access denied. unauthorized identity card found.", "your identity card is invalid. access denied", "invalid identity card access denied", "i can't accept your identity card. because it is invalid","Your identity card is incorrect, access denied"]


#Establish mysql connection
mydb = mysql.connector.connect(
  host="localhost",
  user="root",
  passwd="",
  database="dsa_attendance_system"
)

#Create mysql select object
SelectDataCursor = mydb.cursor()

#Output sound 
engine = pyttsx3.init()
voices = engine.getProperty('voices')       #Get details of current voices
#engine.setProperty('voice', voices[0].id)  #Change index, changes voices. o for male
engine.setProperty('voice', voices[1].id)   #Change index, changes voices. 1 for female


#Get the screen resolution
user32 = ctypes.windll.user32
screensize = user32.GetSystemMetrics(0), user32.GetSystemMetrics(1)

#defined the window's width and height
Screen_Width = 820
Screen_Height = 620

#Get the center width and hight
Screen_Center_Width = int((screensize[0] - Screen_Width) / 2)
Screen_Center_Height = int((screensize[1] - Screen_Height) / 2) - 30


# Return the corresponding greeting value based on the time (hour) input
def greeting_function():
    currentHour = int(datetime.datetime.now().hour) #Get current hour
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

#Save the attendance details as excel sheet 
def excel_convert_and_copy_to_google_drive():

	current_date_object = datetime.datetime.today()
	current_date = current_date_object.strftime('%m-%d-%Y')

	SelectDataCursor.execute("SELECT DISTINCT student_data.department,student_data.batch_no FROM student_data, attendance_data WHERE attendance_data.student_id = student_data.student_id AND attendance_data._date = '{}'".format(current_date))
	dep_batch_data = SelectDataCursor.fetchall()
	mydb.commit()

	for x in dep_batch_data:

		sheet_name = x[0].lower()
		sheet_name = sheet_name.replace(" ","-")

		workbook = xlsxwriter.Workbook(f'{sheet_name}-batch-no-{x[1]}.xlsx')
		worksheet = workbook.add_worksheet()

		format1 = workbook.add_format({'align': 'center', 'bold': True,'font_size': 13, 'bg_color': '#e4e7ed'})

		worksheet.write('A1', 'Student ID', format1)
		worksheet.write('B1', 'First Name', format1)
		worksheet.write('C1', 'Last Name', format1)
		worksheet.write('D1', 'Email', format1)
		worksheet.write('E1', 'Phone Number', format1)
		worksheet.write('F1', 'Attendance Status', format1)


		worksheet.set_column(0, 5, 25)


		
		present_students = []
		absent_students = []
		all_students = []
		
		sql_code0 = "SELECT attendance_data.student_id FROM attendance_data, student_data WHERE attendance_data.student_id = student_data.student_id and student_data.department = '{}' and student_data.batch_no = '{}' and attendance_data._date = '{}'".format(x[0],x[1],current_date);
		SelectDataCursor.execute(sql_code0)
		attendance_present_data = SelectDataCursor.fetchall()
		mydb.commit()

		if attendance_present_data != 0:
			for mx in attendance_present_data:
				present_students.append(mx[0])


		sql_code_1 = "SELECT student_id FROM student_data"
		SelectDataCursor.execute(sql_code_1)
		all_student_ids = SelectDataCursor.fetchall()
		mydb.commit()

		if all_student_ids != 0:
			for mx in all_student_ids:
				all_students.append(mx[0])

		absent_students = list(set(all_students) - set(present_students))

		print(all_students)
		print(present_students)
		print(absent_students)
		workbook.close()

excel_convert_and_copy_to_google_drive()
	


cap = cv2.VideoCapture(0)

counter = 0

while True:
	
	ret, frame = cap.read()
	frame = cv2.resize(frame, (Screen_Width, Screen_Height))
	QRcodeData = decode(frame)
	

	if len(QRcodeData) !=0:
		
		CodeType = QRcodeData[0][1]
		

		if CodeType == "QRCODE":
			
			student_id = QRcodeData[0][0].decode('utf-8')
			
			current_date_object = datetime.datetime.today()

			current_date = current_date_object.strftime('%m-%d-%Y')
			current_time = current_date_object.strftime('%H:%M:%S')

			if counter == 3:

				playsound.playsound("system-data\\QR-sound.mp3")

				SelectDataCursor.execute("SELECT * FROM student_data WHERE student_id = '{}'".format(student_id))
				collecttedData_1 = SelectDataCursor.fetchall()
				mydb.commit()

				if len(collecttedData_1) != 0:

		
					SelectDataCursor.execute("SELECT * FROM attendance_data WHERE student_id = '{}' AND _date = '{}'".format(student_id,current_date))
					collecttedData = SelectDataCursor.fetchall()
					mydb.commit()
					

					SelectDataCursor.execute("SELECT firstname, lastname FROM student_data WHERE student_id = '{}'".format(student_id))
					collecttedData_names = SelectDataCursor.fetchall()
					mydb.commit()
					fullname = f"{collecttedData_names[0][0]} {collecttedData_names[0][1]}"
					
					if len(collecttedData) == 0:

						insert_cursor = mydb.cursor()
						sqlCode = "INSERT INTO attendance_data VALUES ('{}', '{}', '{}', '{}')".format("",student_id, current_date, current_time)
						insert_cursor.execute(sqlCode)
						mydb.commit()

						talk_function(f"{greeting_function()} {fullname}, {random.choice(Entering_Attendance_Passed)}, {random.choice(Entering_Voice_Data)}")

					else:
						talk_function(f"Sorry, {fullname}, {random.choice(Attendance_Already_Exit)}")
		
				else:
					talk_function(f"sorry, {random.choice(unauthorized_IDcard_Voice_Data)}")

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

