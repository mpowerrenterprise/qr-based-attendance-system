import qrcode

qr = qrcode.QRCode(
	version=2,
	box_size=10,
	border=2
)


student_id = input("Enter student ID? ")

qr.add_data(student_id)
qr.make(fit=True)
img = qr.make_image(fill='black', back_color='white')
img.save(f'{student_id}.png')